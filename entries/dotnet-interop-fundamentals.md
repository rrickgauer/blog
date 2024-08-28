
## Introduction

* .NET interopability is about calling from .net to native code and maybe from native to .NET as well

### Execution Modes

#### Managed execution
* code running under the control of the CLR
  * the CLR knows about variables, types, stack frames, objects, etc

#### Unmananged execution
* code the CLR knows nothing about

#### Managed vs Native Code

|  | Managed (.NET) | Native Programming Languages|
| ------ | --- | ----- |
| Code execution | Safety ensured by the CLR | No safety guarantees |
| Memory management | Garbage collection | manual |
| Error handling | execption handling | return values / SEH / C++ exceptions |

### Interoperability Scenarios

* calling Windows API ("Win32") functions that don't have a managed wrapper
* using existing native code
  * using existing native code that needs to be leveraged
    * by choice or necessity
    * third party components that don't have a managed equivalent
* plugging into native hosts
  * writing a .NET component to be loaded by the host as a COM component


## Interoperability Mechanisms

* the CLR provides built in support for certain mechanisms
  * platform invoke ("P/Invoke")
    * calling C-style functions in DLLs
  * COM interop
    * calling COM objects from .NET
    * creating .NET classes to be consumed by COM clients
* Interoperating with C++ code
  * C++/CLI
    * managed language 
    * capable of mixing native and managed code
     
## P/Invoke: The Basics

* P/Invoke allows calling C functions in DLLs
* C-functions have practically no metadata
  * execept the function name itself
  * this means everything must be set correctly by the developer
* using P/Invoke
  * mark method as static and extern
  * add **DllImport** attribute on the method specifying at least DLL name
* P/Invoke engine will call ```LoadLibrary``` and ```GetProcAccess``` to invoke the function
  * if a filename only is specified, ```LoadLibrary``` rules apply

### Finding Entry Points

* ```DllImport``` has a bunch of properties that can be used to customize function invocation
* function name can be aliased
  * specify real name with the ```EntryPoint``` property
* Win32 function names that have string arguments are mostly macros with "A" and "W" appended to the base name for the actual functions
  * E.g. ```CreateFileA``` vs ```CreateFileW```
* P/Invoke willt try several possibilities for locating the entry point
  * Specify ```ExactSpelling = true``` to skip the heuristics and use the specified name
  * ```CharSet``` indicates ANSI or Unicode default for function name and string argument marshalling

### Calling Convention

* C functions use one of two calling conventions:
  1. ```cdecl```
      * caller responsible for cleaning arguments
      * allows functions with variable number of arguments
  2. ```stdcall```
      * callee responsible for cleaning arguments
      * most windows API functions are _stdcall
      * the default calling convention on today's Windows Platforms
* specify calling convention with the ```CallingConvention``` property
* messing up the calling convention may corrupt the stack

### Type Conversion

* P/Invoke may need to convert parameters from their managed to their unmanaged representation and back
* the ```MarshalAs``` attribute can be used on arguments
  * accepts the ```UnmanagedType``` enumeration
* useful for numbers, strings, arrays, and others

```c#
void _stdcall DoWork(LPCWSTR s1, LPCSTR s2, LPCTSTR s3, BSTR s4);

[DllImport("somelib")]
static extern void DoWork(
  [MarshalAs(UnmangedType.LPWStr)] string s1,
  [MarshalAs(UnmangedType.LPStr)] string s2,
  [MarshalAs(UnmangedType.LPTStr)] string s3,
  [MarshalAs(UnmangedType.BStr)] string s4,
);
```

## P/Invoke: Digging Deeper

### Error Handling
* C functions frequently return integer values to indicate success or some kind of failure
  * C has no notion of exceptions
* in particular, Windows API functions return a Boolean to indicate success
  * native code calls ```GetLastError``` to retrieve the last error on the current thread
* The last error code is lost after a P/Invoke call unless the ```DllImportAttribute``` property ```SetLastError``` is set to true
  * to get an actual error code, call ```Marshal.GetLastWin32Error```
  * or throw an exception in a helper method with ```Marshal.ThrowExceptionForHR```

### Structures and Unions
* C stucture members reside in the order of declaration
* CLR structures may be reorderd by the CLR for performance reasons
  * member alignment is determined by the CLR as well
* For P/Invoke this is unacceptable
* the ```StructLayout``` attribute can be used to control order and alignment
  * ```LayoutKind.Auto```
    * default - CLR determines order and alignment
  * ```LayoutKind.Sequential```
    * layout order is order of decleration
  * ```LayoutKind.Explicit```
    * each member's offset is specified explicitly

### Function Pointers
* some C functions require a pointer to a function as a parameter
* a delegate can be used to convey the same information
  * delegate signature must match
* cannot use generic delegates (such as Func<> or Action<>)

### Object Lifetime
* managed objects may move around after a garbage collection
* the P/Invoke engine pins all managed objects in memory prior to the native call
  * unpins the objects after the call returns
* if objects are to be used after the particular call, they must be pinned so the GC won't move them
  * otherwise, potential memory corruption or access violation exception may occur
* pinning is done by calling ```GCHandle.Alloc()``` with the pinned flag
  * call ```GCHandle.Free()``` when pinning is no longer needed

### Guidelines

* use Unicode strings for Windows APIs
* pin objects that may be used for post method access
  * don't forget to release pinning
  * otherwise, this is a memory leak
  * look for "# pinned objects" in ".NET CLR Memory" performance counter
* don't use "AnyCPU" for non-windows API DLL's
  * cross architecture DLL usage is not allowed
* create function wrappers for easier .NET consumption

## COM Interop: Foundations

### The Component Object Model (COM)

* binary standard interface specification for objects
  * based closely on C++ vtable mechanism for dispatch
  * ideally language independent
* a set of rules and a supporting runtie for building component based systems
* interface based programming
* location transparency
  * fast access to in-process objects
  * seamless inter-proces communication to out-of-process objects

### COM Object

* seperates its interface(s) from its implementation
* provides multiple services through seperate interfaces
* all COM objects must implement the ```IUnknown``` interface
  * includes a ```QueryInterface()``` function that clients can use to acquire pointers to other interfaces
* also includes ```AddRef()``` and ```Release()``` functions for managing object lifetime
* every interface must inherit from ```IUnknown```
* function/method order matters

### GUIDs

* every entity in COM is identified by a GUID
  * 128 bit Global Unique Identifiers, statistically unique across space and time
* used to identify interfaces, classes, type libraries and more
* can generate with the ```Guidgen.exe``` tool
  * calls ```CoCreateGuid``` internally
  * several formats available
* can be executed from Visual Studio's *Tools menu*

### HRESULTs

* interface functions should not throw Win32 or C++ exceptions
  * not meaningful to all types of clients
  * cannot cross process boundaries
* interface methods should return an HRESULT
  * 32-bit value that contains success or error code
  * Bit 31 indicates success (0) or failure (1)
* ```AddRed``` and ```Release``` are only exceptions to this rule
* with .NET interop
  * a failed HRESULT turns into a thrown ```COMException``` exception

#### Common HRESULTs

HRESULT | Meaning 
--- | --- 
**S_OK** | standard success code (=0) 
**S_FALSE** | partial success in some sense (=1) 
**E_FAIL** | generic failure code
**E_POINTER** | bad pointer supplied
**E_UNEXPECTED** | unexpected call at this time
**E_NOINTERFACE** | the requested interface is not supported
**E_NOTIMPL** | functionality not implemented
**E_OUTOFMEMORY** | not enough memory to complete the operation
**E_INVALIDARG** | argument is invalid

### Activation APIs

* client wants to create an instance of a COM class
  * calls ```CoGetClasObject``` to get a class object (class factory)
    * provides the class ID (CLSID)
    * typically requesting the ```IClassFactory``` interface
  * calls ```IClassFactory::CreateInstance``` to get an actual instance
* if ```IClassFactory``` is indeed the factory instance
  * client can call ```CoCreateInstance``` to get the above 2 steps in one stroke
* for .NET interop - .NET can only use ```IClassFactory``` directly
  * extra work for custom clas factories

### COM Registration

* COM classes must be registered in the system Registry
  * minimum is the CLSID to DLL/EXE mapping
  * can provide a "user-friendly" ProgID
* seperate registrations for 32 and 64-bit

### Typical DOM DLL

* provides a type library
  * metadata for the various interfaces, classes, GUIDs, etc.
  * sometimes provided as seperate TLB file
* must implement one function
  * ```DllGetClassObject```
    * returns a clas factory for a particular CLSID
* optionally also implements:
  * ```DllRegisterServer```
  * ```DllUnregisteredServer```
    * actual registration typically done with the ```RegSvr32.exe``` tool
  * ```DllCanUnloadNow```

### Basic COM Interop

* .NET can read a COM type library and build a wrapper .NET assembly
  * ```TypeLibConverter.ConvertTypeLibToAssembly```
* wrapped in the ```TlbImp.exe``` command line tool
* with visual studio - add a reference from the *COM* tab
* runtime callable wrapper (RCW)
  * managed wrapper for a COM object
  * looks like a regular .NET object

### Summary

* COM is about components interfacing via well defined interfaces
* ```IUnknown``` is the base interface that must be supported
  * manages lifetime and provides a way to get other interfaces
* COM components reside in DLLs (in-proc server) or EXEs (out-of-proc server)
* simple COM interop is indeed simple 

## COM Interop: Digging Deeper

### IUnknown in .NET

* RCWs do not expose ```IUnknow``` directly
  * ```QueryInterface``` is achieved with casting (or the ```as``` operator)
  * ```AddRef``` is implicitly called as part of the ```QueryInterface```
  * ```Release``` is called whe the RCW is garbage collected

```c#
ISimpleCalculator calc = new Calculator();
int sum = calc.Add(3, 4);

ITrigCalculator trig = calc as ITrigCalculator;
if (trig != null) {
  double result = trig.Sin(30);
  // use result
}
```

### Memory Management

* memory (lifetime) management is different in COM and .NET
  * COM uses reference counting
    * **pro:** deterministic destuction
    * **con:** cylic references
  * .NET uses a garbage collector
    * **pros:**
      * no need to manually destroy objects
      * cycles dealt with automatically
    * **cons:** 
      * non deterministic object destruction
      * may be time consuming
* RCWs don't implement ```IDisposable```
* use ```Marshal.ReleaseComObject``` to forcefully call ```Relase``` on a COM object
  * makes the RCW an empty shell

### Interop with no Type Library

* a type library in COM is not mandatory
  * may or may not exist
* if not, cannot adda a reference in Visual Studio
* however, interfaces and classes can be specified explicitly with attributes
  * based on some other form of documentation
  * somewhat similar to P/Invoke

### Dynamic Dispatch

* COM supports the notion of dynamic invocation with the ```IDispatch``` interface
  * typically used by scripting clients
* .NET can leverage the Dynamic Language Runtime (DLR) to invoke such interface members dynamically
  * using the C# ```dynamic``` keyword

```c#
interface IDispatch : IUnkown {
  // ...
  HRESULT _stdcall GetIDsOfNames(...);
  HRESULT _stdcall Invoke(...);
}
```

### Exposing .NET types as COM types

* COM interop can go in the other way as well
* a .NET type can expose itself as COM class for native client consumption
* the COM client recieves a COM Callable Wrapper (CCW)
  * looks like a regular COM object to the native client
* assembly must be marked as ```ComVisible(true)```
* .NET classes can be exposed as COM classes
  * must be public 
  * must be marked with ```ComVisible(true)``` attribute
  * members must be public
  * must have a public default constructor
  * must have a ```Guid``` attribute
    * if not, GUID generated automatically
* resulting asembly needs to be registered as a COM component
  * use ```regasm.exe``` tool
    * add the ```/tlb:``` option to register a type library seperately for COM client consumption
    * or use Visual Studio

### Summary

* .NET hides most of the low level COM details
* most of the time adding a type library reference is all that's needed
* dynamic dispatch is possible using the dynamic C# keyword
* .NET types can be exposed as COM classes

## COM Interop: Threading

### Processses and Threads

#### Process 
* a management and containment object, providing resources to execute a program
* manages a private virtual address space
  * by default 2GB (32 bit), 8 TB (64 bit)

#### Thread
* entity scheduled by the kernel to execute code
* has a stack, priority, optional message queue
* has a scheduling state (running, ready, waiting)


### COM and Threading

* client code may have multiple threads
  * may create objects on many threads
  * may access an object concurrently from mulitple threads
  * object may call back to the client
* objects may have mutliple threads
  * worker threads
  * may access object state
* some objects are thread safe, some are not
* COM apartments provide a solution

### Threads and Apartments

* in .NET, objects are expected to be thread safe, or state that they are not in some way
  * mulithreading is common and the norm
* for historical reasons, COM provides an abstraction called Apartments to provide object automatic protection if requested
  * an apartment groups objects with the same concurrency requirements
  * a process may have any number of apartments
  * every objecrt is associated with exactly one thread
  * objects may be called by threads in their apartment only
  * cross apartment access required a proxy

### Objects and Apartments

* objects may have their own concurrency requirements
* a COM class residing in a DLL indicated its threading model via the registry

Setting | Apartment Type | Notes
--- | --- | ---
**Single** | Main STA | first STA in process (legacy setting)
**Apartment** | STA | 
**Free** | MTA | 
**Both** | STA or MTA | in the calling thread's apartment
**Neutral** | TNA | 

### Apartments and the CLR

* COM used the "Apartments" model to help manage concurrency
  * **STA** &mdash; Single Threaded Apartment
  * **MTA** &mdash; Multithreaded Apartment 
* the CLR does not use apartments
  * conceptually, only an MTA exists
* when calling COM objects, apartments matter
* a managed thread is created by default in the MTA
  * call ```Thread.SetApartmentState``` on the thread object before the thread is started
  * can change by the ```STAThread``` attribute on the **Main** method only

### "Both" and FTM

* "both" means object is always created in the apartment of the caller (no COM proxy)
* however, if passed to another apartment, it will be marshalled and a proxy created
  * despite object's best intentions to avoid a proxy
* such objects can aggregate the Free Threaded Mashalar (FTM) to guarantee they will never be used with a proxy in process

### Summary

* COM apartments are a way to control object concurrency
* if client and object apartments don't match: a proxy is created
* COM classes state their concurrency requirements through the registry

## Interop With C++/CLI

### What is C++/CLI?

* C++ is orginally a native language
  * knows nothing about the CLR
  * the CLR itself is actually implemented as a set of COM classes written in unmanaged C++
* C++/CLI is a set of extensions to the C++ language to support .NET programming
  * includes new keywords and concepts to support CLR programming
* main benefit is to mix native and managed code

### C++/CLI Usage Scenarios

* mix managed and unmanaged code to get eachothers's benefits
  * better performance for unmanaged code
  * easier and faster calls to native functions, COM components, etc...
* wrap unmanaged classes/code as managed types for managed clients
* wrap managed types with unmanaged classes to expose native clients

### C++/CLI Basics

* can declare and use managed types
  * reference types
  * value types
  * enums
  * interfaces
  * delegates
  * events
* managed types may contain unmanaged types and vice versa 
* need to compile with one of the /clr compiler switches
  * /clr is the most common
* single inheritance only in managed types
  * cross inheritance is not allowed
* C++ and CLI fundamental types are automatically mapped to eachother
* native semantics remain where it makes sense

### Hello World - C++/CLI Demo

* [Link to the video](https://app.pluralsight.com/course-player?clipId=342be8fe-792e-47c0-8e86-2b3f8572398c)

### Declaration Syntax

*.NET Class (reference type)*
```c++
ref class Book { /* */ };
```

*.NET Struct (value type)*
```c++
value class Point { /* */ };
```

*.NET interface*
```c++
interface class ILearn { /* */ };
```

*.NET enum*
```c++
enum class Gender { /* */ };
```

#### Properties, Methods, and Events

* methods are declared as regular C++ member functions
* properties are declared with the ```property``` keyword
* events are declared with the ```event``` keyword

```c++
public ref class Book {
public:
  Book(String^ path);
  
  String^ ReadPage(int pageNumber);
  void GoToNextPage();

  property int length {
    int get();
  }

  event EventHandler^ PageTurned;
};
```

### Objects and References

* managed reference type variables end with ```^```
  * a handle to the GC heap
  * access members with ```->``` operator
* to allocate a managed object, use the ```gcnew``` operator
* a null reference is indicated by the keyword ```nullptr```
* arguments to the methods pased by value, unless ```%``` is used
  * same as the ```ref``` C# keyword
* managed value types are used similarly to C++ native types
* can call ```delete()``` on reference
  * calls ```IDisposable::Dispose``` (the "destructor")


#### Demo 

```c++
#include "stdafx.h"

using namespace System;
using namespace System::Linq;

int main(array<System::String ^> ^args)
{
  Console::WriteLine(L"Hello Word");

  auto rnd = gcnew Random;
  Console::WriteLine(rnd->Next(1, 100));

  array<int>^ numbers = gcnew array<int>(100);
  for (int i = 0; i < numbers->Length; i++)
    numbers[i] = rnd->Next(0, 100);
  
  int sum = Enumerable::Sum(numbers);
  int average = Enumerable::Average(numbers);

  Console::WriteLine(sum);
  Console::WriteLine(average);

  {
    System::ID::MemoryStream ms(100);
    auto len = ms.Length;
  }

  return 0;
}
```

### Exposing Native Types to .NET

* create a managed type
  * store a pointer as a private member
  * expose managed properties/methods as appropriate
    * may need to marshal arguments
    * use the ```Marshal``` class and other built in helpers
* any .NET client (C#, VB, F#, etc.) can reference the resulting assembly and access the type as usual
* native types can hold references to .NET types
  * must be wrapped with the ```gcroot<T>``` template class
  * otherwise, object may be garbage collected
* [Demo of a Native type to a .NET type](https://app.pluralsight.com/course-player?clipId=f187d64f-706a-43b4-afd0-614dca8876a3)
* [Demo of a C# Client](https://app.pluralsight.com/course-player?clipId=30d0b106-d71f-4098-8260-597fc8a567ad)

### Summary

* C++/CLI is a fully managed language like any other
* easy mixing of managed and native code
* useful where control or performance matter

## Tips and Tidbits

### Unsafe Code

#### Normal C# is safe

* runs entirely under the control of the CLR
* verifiable

#### Unmanaged Code (Native Code)

* runs completely outside the control of the CLR
* CLR knows nothing about it

#### Unsafe Code

* code that runs without the normal protection of the CLR, within other CLR-controlled code
* the CLR turns its head away hoping no damage is done during the unsafe execution
* can only execute in a full-trust assembly

### The Unsafe Keyword

* the C# ```unsafe``` keyword declares a block, a method, or a type to contain unsafe code
  * C/C++ style native pointers may be used to manipulate data
  * must compile with the /unsafe compiler switch
* resulting code is still IL
* use the ```fix``` keyword to lock objects in place
  * necessary because the garbage collector may move objects around

### Bitness

* pure .NET code can be complied as "Any-CPU"
  * "bitness" agnostic
* native code is always tied to a particular "bitness"
* when interop is involved, it's best to compile x86 or x64 explicitly

### Properties in COM

* natively COM deals with methods only
* COM supports the notion of properties with a pair of methods named ```get_PropertyName()``` and ```put_PropertyName()```
* when importing such a type library, the .NET interop assembly created turns these into .NET properties
* this also goes in the other direction

```c++
[propget] HRESULT Degrees([out, retval] VARIANT_BOOL* pVal);
[propget] HRESULT Degrees([in] VARIANT_BOOL newVal);
```

### COM Events

* COM provides a standard way of providing events with the ```IConnectionPointContainer``` Interface
  * client provides a sink object that implements an event interface
* when importing to .NET
  * RCW exposes the enet as a regular .NET event
  * sink provides behind the scenes
  * register as usual

```C++
coclass RPN Calculator {
  [default] interface IRPNCalculator;
  [default, source] dispinterface _IRPNCalculatorEvents;
}
```

### Summary

* .NET interop is sometimes required - native code is not going anywhere
* P/Invoke - call C functions in DLLs
* COM interop - use COM classes and interfaces
* C++/CLI - the most powerful interop mechanism