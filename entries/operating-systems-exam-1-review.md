# CSCI 480 - Operating Systems - Exam 1 Review Sheet
This is a study guide I wrote to help myself review for my first exam in my [operating systems class](http://faculty.cs.niu.edu/~hutchins/csci480/main.htm). The majority of information used to write this guide comes from our [textbook](http://www.uobabylon.edu.iq/download/M.S%202013-2014/Operating_System_Concepts,_8th_Edition%5BA4%5D.pdf). I tried to cover all the topics listed on the [review sheet](http://faculty.cs.niu.edu/~hutchins/csci480/t1review.doc).

### Additional Readings
* https://www2.cs.uic.edu/~jbell/CourseNotes/OperatingSystems/
* [Google Doc](https://docs.google.com/document/d/1HUubUp2dN4TCJZpxeQt0L9g-ZHQPnUBCcqx6mRVtftY/edit) created by another student in my class

# Content

1. [Exam Information](#exam-information)
2. [Introduction and OS Structures](#introduction-and-os-structures)
   1. [Operating System Components](#operating-system-components)
   2. [System Calls](#system-calls)
   3. [Linux System Calls](#linux-system-calls)
   4. [System Programs](#system-programs)
3. [Process Management](#process-management)
    1. [Process Control Block](#process-control-block)
    2. [Schedulers](#schedulers)
    3. [Scheduling Queues](#scheduling-queues)
    4. [Context Switch](#context-switch)
    5. [Interprocess Communication](#interprocess-communication)
    6. [Zombie and Orphan Processes](#zombie-and-orphan-processes)
4. [Threads](#threads)
   1. [Differences Between Threads And Processes](#differences-between-threads-and-processes)
   2. [Kernel And User Threads](#kernel-and-user-threads)
   3. [Threading Models](#threading-models)
5. [CPU Scheduling](#cpu-scheduling)
   1. [Performance Criteria](#performance-criteria)
   2. [Preemptive And Non-Preemptive Scheduling](#preemptive-and-non-preemptive-scheduling)
   3. [Scheduling Algorithms](#scheduling-algorithms)
6. [Process Synchronization](#process-synchronization)
   1. [Race Condition](#race-condition)
   2. [Critical Section Problem](#critical-section-problem)
   3. [Semaphores](#semaphores)
7. [Deadlock](#deadlock)
8. [Additional Notes](#additional-notes)





# Exam Information
* **Date:** Monday, 2/24/2020
* **Time:** 11:00am - 11:50am
* **Location:** PM 253
* Covers material over:
  * chapters 1-7 in our [textbook](http://www.uobabylon.edu.iq/download/M.S%202013-2014/Operating_System_Concepts,_8th_Edition%5BA4%5D.pdf)
  * Assignments 1, 2, and 3
* Test includes a few true-false questions, short answer, and some longer written answers
  * Does *not* include long coding questions

[&uarr; Back to top](#table-of-content)

# Introduction and OS Structures

## Operating System Components
<table>
<tr>
<td><b>User Interface</b></td>
<td>means by which users can issue commands to the system</td>
</tr>
<tr>
<td><b>Program Execution</b></td>
<td>the OS must be able to load a program into RAM, run the program, and terminate the program, either normally or abnormally</td>
</tr>
<tr>
<td><b>I/O Operations</b></td>
<td>transferring data to and from I/O devices, including keyboards, terminals, printers, and storage devices</td>
</tr>
<tr>
<td><b>File-System Manipulation</b></td>
<td>maintaining directory and subdirectory structures, mapping file names to specific blocks of data storage, and providing tools for navigating and utilizing the file system</td>
</tr>
<tr>
<td><b>Communications</b></td>
<td>inter-process communications, IPC, either between processes running on the same processor, or between processes running on separate processors or separate machines</td>
</tr>
<tr>
<td><b>Error Detection</b></td>
<td>both hardware and software errors must be detected and handled appropriately, with a minimum of harmful repercussions</td>
</tr>
</table>

## System Calls
* provide a means for user or application programs to call upon the services of the OS
* generally written in C or C++
* six types:
   1. process control
   2. file management
   3. device management
   4. information maintenance
   5. communications
   6. protection

## Linux System Calls

### getpid() and getppid()
* ```getpid()``` returns the process id of the calling process
* ```getppid()``` returns the process id of the parent of the calling process

### fork()
* ```fork()``` creates a new process (a child of the calling process) by duplicating the calling process
* the entire address space is duplicated:
   * code
   * variables
   * file descriptors
* return codes:
   * *-1* means an error occurred

### system() vs execlp()
* ```system()``` internally uses a fork and executes in the child process
* ```execlp()``` replaces the executable code for what its doing
   * when it terminates, the whole process terminates

## System Programs
* provide OS functionality through separate applications, which are not part of the kernel or command interpreters
* also known as system utilities or system applications
* can be provided into these categories:
   <table>
   <tr>
   <td><b>file management</b></td>
   <td>programs to create, delete, copy, rename, print, list, and generally manipulate files and directories</td>
   </tr>

   <tr>
   <td><b>status information</b></td>
   <td>utilities to check on the date, time, number of users, processes running, data logging, etc.</td>
   </tr>

   <tr>
   <td><b>file modification</b></td>
   <td>text editors and other tools which can change file contents.</td>
   </tr>

   <tr>
   <td><b>programming language support</b></td>
   <td>compilers, linkers, debuggers, profilers, assemblers, library archive management, interpreters for common languages, and support for make.</td>
   </tr>

   <tr>
   <td><b>program loading and execution</b></td>
   <td>loaders, dynamic loaders, overlay loaders, etc., as well as interactive debuggers.</td>
   </tr>

   <tr>
   <td><b>communications</b></td>
   <td>programs for providing connectivity between processes and users, including mail, web browsers, remote logins, file transfers, and remote command execution.</td>
   </tr>

   <tr>
   <td><b>background services</b></td>
   <td>system daemons are commonly started when the system is booted, and run for as long as the system is running, handling necessary services</td>
   </tr>
   </table>

[&uarr; Back to top](#table-of-content)

# Process Management
* a **process** is a program in execution
* as a process executes, it changes **state**
  * the state of a process is defined by that process' current activity
* each process can be in one of the following states:
  <table>
    <tr>
      <td><b>new</b></td>
      <td>the process is being created</td>
    </tr>
    <tr>  
      <td><b>ready</b></td>
      <td>the process is waiting to be assigned to a processor</td>
    </tr>
    <tr>
      <td><b>running</b></td>
      <td>instructions are being executed</td>
    </tr>
    <tr>
      <td><b>waiting</b></td>
      <td>the process is waiting for some event to occur</td>
    </tr>
    <tr>
      <td><b>terminated</b></td>
      <td>the process has finished execution</td>
    </tr>
  </table>

## Process Control Block
* a **process control block (PCB)** represents each process in the operating system

  <table>
    <tr>
      <td><b>process state</b></td>
      <td>can be new, ready, running, waiting, etc...</td>
    </tr>
    <tr>
      <td><b>program counter</b></td>
      <td>indicates the addess of the next instruction to be executed in this process</td>
    </tr>
    <tr>
      <td><b>cpu registers</b></td>
      <td>can include accumulators, index registers, stack pointers, and general purpose registers</td>
    </tr>
    <tr>
      <td><b>cpu scheduling info</b></td>
      <td>includes a process priority, pointers to scheduling queues, and other scheduling parameters</td>
    </tr>
    <tr>
      <td><b>memory management info</b></td>
      <td>may include the value of the base and limit registers, page tables</td>
    </tr>
    <tr>
      <td><b>accounting info</b></td>
      <td>amount of cpu and real time used, time limits, account numbers, job and process numbers</td>
    </tr>
    <tr>
      <td><b>I/O status</b></td>
      <td>the list of I/O devices allocated to the process, a list of open files</td>
    </tr>
  </table>

## Schedulers
* the **process scheduler** selects an available process for program execution on the CPU
* often, on a batch system, more processes are submitted than can be executed
  * these processes are spooled to a storage device where they are kept for later execution
* the **long term scheduler** selects processes from this pool and loads them into memory
* the **short term scheduler** selects from the process that are ready to execute and allocates the CPU to one of them
  * also called the cpu scheduler

### Short Term vs Long Term
* the primary distinction between the 2 schedulers lies in *frequency of execution*
* the short term scheduler selects processes frequently
* the long term scheduler select processes much less frequently
  * minutes may separate the creation of one new process and the next

### Degree of Multiprogramming
* the **degree of multiprogramming** is the number of processes in memory
* controlled by the long term scheduler
* if the degree of multiprogramming is stable, then the average rate of process creation must be equal to the average departure rate of processes leaving the system
   * *average process creation rate = average departure rate*

### Medium Term Scheduler
* some OS use an additional level of scheduling called a **medium term scheduler**
* the idea is to remove a process from memory for a time, then later reintroduce it into memory in order to reduce the degree of multiprogramming
  * this scheme is called **swapping**

## Scheduling Queues
* as processes enter the system, they are put into a **job queue**
* the **ready queue** is a list of the processes residing in main memory and are waiting to execute
* the **device queue** is a list of processes waiting for a particular I/O device
  * each device has its own device queue

## Context Switch
* a **context switch** is where a state save of the current process and a state restore of a different process is performed
* occurs when switching the CPU to another process
* when a context switch occurs, the kernel saves the context of the old process in its PCB and loads the saved context of the new process that is scheduled to run
* pure overhead since the system does no useful work while switching

## Interprocess Communication
* processes executing concurrently may be either independent *or* cooperating
* **independent processes** cannot affect or be affected by other processes
  * does not share data with other processes
* **cooperating processes** can affect or be affected by other processes
  * can share data with other processes
* reasons for allowing process cooperation:
  * information sharing
  * computation speedup
  * modularity
  * convenience

### Interprocess Communication
* cooperating processes require an **interprocess communication (IPC)** mechanism that will allow them exchange data
* 2 fundamental models for IPC:
  * shared memory
  * message passing

#### Shared Memory
* **shared memory** models have a region of memory that is shared by cooperating processes
* info can be read and written to by the processes in the shared region
* advantages:
  * allows maximum speed and convenience of communication
  * faster than message passing

#### Message Passing
* **message passing** models communicate by means of message exchanges between cooperating processes
* advantages:
  * smaller amounts of data
  * easier to implement

## Zombie and Orphan Processes

### Zombie processes
* **zombie processes** are processes that have completed execution, but still has an entry in the process table
* entry is still needed to allow the parent process to read ints child exit status
* cannot directly kill a zombie process because its already dead
* to kill a zombie process you should kill the parent process

### Orphan processes
* a process whose parent has finished, though remains running itself
* parent process id is change to init which is 1

[&uarr; Back to top](#table-of-content)


# Threads
* a **thread** is a basic unit of CPU utilization
* it is comprised of:
   * thread ID
   * program counter
   * register set
   * a stack
* if a process has multiple threads of control, it can perform more than one task at a time

## Differences Between Threads And Processes
<table>
<thead>
<tr><th>Process</th><th>Thread</th></tr>
</thead>
<tbody>
<tr>
<td>typically independent</td>
<td>Subset of a process</td>
</tr>
<tr>
<td>has considerably more state information than thread</td>
<td>multiple threads within a process</td>
</tr>
<tr>
<td>separate address spaces</td>
<td>share their address space</td>
</tr>
<tr>
<td>interact only through system IPC</td>
<td></td>
</tr>
</tbody>
</table>

## Kernel And User Threads
* **kernel threads** are supported and managed directly by the OS
* **user threads** are supported by above the kernel and are managed without kernel support

## Threading Models
* a relationship must exist between user and kernel threads
* three common ways of establishing these relationships:
   1. Many-to-One
   2. One-to-One
   3. Many-to-Many

### Many-to-One
* maps many user level threads to one kernel thread
* thread management is done by the thread library in user space

![many to one model image](https://www.cs.uic.edu/~jbell/CourseNotes/OperatingSystems/images/Chapter4/4_05_ManyToOne.jpg)

### One-to-One
* maps each user thread to a kernel thread
* provides more concurrency than many-to-one by allowing another thread to run when a thread makes a system blocking call
* allows multiple threads to run in parallel on multiprocessors

![one to one model image](https://www.cs.uic.edu/~jbell/CourseNotes/OperatingSystems/images/Chapter4/4_06_OneToOne.jpg)

### Many-to-Many
* multiplexes many user level threads to a smaller or equal number of kernel threads
* the number of kernel threads may be specific to either a particular application or machine

![many to many model image](https://www.cs.uic.edu/~jbell/CourseNotes/OperatingSystems/images/Chapter4/4_07_ManyToMany.jpg)


[&uarr; Back to top](#table-of-content)

# CPU Scheduling
* when the CPU becomes idle, the **CPU scheduler** is tasked with selecting another process from the ready queue to run next
* a scheduling system allows one process to use the CPU while another is waiting for I/O
   * this makes full use of otherwise lost CPU cycles
* the challenge is to make the overall system as efficient and fair as possible

## Performance Criteria

Criteria            | Description
--------------------|------------------------------------------
**CPU Utilization** | percentage of used cycles
**Throughput**      | jobs completed per time unit
**Turnaround Time** | time from submission to completion
**Waiting Time**    | time waiting in ready queue
**Response Time**   | time from submission until first response

## Preemptive and Non-Preemptive Scheduling
* CPU scheduling decisions take place under one of the four conditions:

Non Preemptive            | Preemptive
--------------------|------------------------------------------
When a process switches from the running state to the waiting state, such as for an I/O request or invocation of the wait( ) system call. | When a process switches from the running state to the ready state, for example in response to an interrupt.
When a process terminates.   | When a process switches from the waiting state to the ready state, say at completion of I/O or a return from wait( ).

### Non Preemptive
* also called cooperative
* in these conditions, there is no choice
* a new process must be selected
* once a process starts, it keeps running until either voluntarily blocks or until it finishes

### Preemptive
* scheduler *has* a choice

## Scheduling Algorithms
* Six common CPU scheduling algorithms:
   * First Come First Serve
   * Shortest Job First
   * Priority Based
   * Round Robin
   * Multi-Level Queue
   * Multi-Level Feedback

### First Come First Serve (FCFS)
* first in first out queue
* like customers waiting in line at the bank or the post office
* can yield very long average wait times
   * particularly if the first process to get there takes a long time
* can be bad because of the **convoy effect** that results as I/O bound jobs pile up behind CPU-bound jobs

### Shortest Job First (SJF)
* picks the quickest, fastest, little job that needs to be done, then moves on to the next quickest
* gives the minimum *average* waiting time for

### Priority
* more general case of SJF
* each job is assigned a priority and the job with the highest priority gets scheduled first
* problems include indefinite blocking which can be solved by aging

### Round Robin
* similar to FCFS scheduling, except that CPU bursts are assigned with limits called **time quantum**
* gives everything a time slice
* when a process is given to the CPU, a timer is set for whatever value has been set for a time quantum
   * if the process finishes its burst before the time quantum expires, then it is swapped out the CPU
   * if the timer goes off first, then the process is swapped out of the CPU and moved to the back end of the ready queue
* maintained as a circular queue

### Multi-Level Queue
* When processes can be readily categorized, then multiple separate queues can be established, each implementing whatever scheduling algorithm is most appropriate for that type of job, and/or with different parametric adjustments.
* Scheduling must also be done between queues, that is scheduling one queue to get time relative to other queues
* two common options:
   * **strict priority:** no job in a lower priority queue runs until all higher priority queues are empty
   * **round robin:** each queue gets a time slice in turn, possibly of different sizes

### Multi-Level Feedback
* similar to the ordinary multilevel queue scheduling described above, except jobs may be moved from one queue to another for a variety of reasons:
   * if the characteristics of a job change between CPU-intensive and I/O intensive, then it may be appropriate to switch a job from one queue to another
   * aging can also be incorporated, so that a job that has waited for a long time can get bumped up into a higher priority queue for a while
* most flexible because it can be turned on for any situation
* most complex to implement
* parameters that define these systems include:
   * number of queues
   * the scheduling algorithm for each queue
   * methods used to upgrade or demote processes from one queue to another
   * method used to determine which queue a process enters initially

[&uarr; Back to top](#table-of-content)

# Process Synchronization

## Race Condition
* **race condition** is when two or more processes run in parallel and output depends on order in which they are executed
* to guard against the race condition, we need to ensure that only one process at a time can be manipulating shared data that is crucial to the outcome of the program
* to do this, we use **process synchronization**

## Critical Section Problem
* each process has a segment of code called a **critical section** where the process may be changing common variables, updating a table, writing a file, etc...
* the OS needs a feature that, when one process is executing in its critical section, no other process is to be allowed to execute in its critical section
   * *no two processes should be executing in their critical sections at the same time*
* solutions to the critical section problem must satisfy the following three requirements:
   1. **mutual exclusion:** if a process is executing in its critical section, then no other processes can be executing in their critical sections
   2. **progress:** if not process is executing in its critical section and some processes wish to enter their critical sections, then only those processes that are not executing their remainder sections can participate in deciding which will enter its critical section next, and this selection cannot be postponed indefinitely
   3. **bounded waiting:** there exists a limit on the number of times that other processes are allowed to enter their critical sections after a process has made a request to enter its critical section and before that request is granted

## Semaphores
* **semaphores** are integer variables for which only two atomic operations are defined:
   * *wait* - allows the process to use a resource
   * *post* - stops locking everything out after it's done with the resource
* the main disadvantage of the semaphore is that it requires **busy waiting**
   * while a process is in critical section, any other process that tries to enter its critical section must loop continuously in the entry code

### Implementation

Define a semaphore as a "C" struct:
```
typedef struct {
   int value;
   struct process *list;
} semaphore;
```

The ```wait()``` semaphore operation can now be defined as:
```
wait(semaphore *S) {
   S->Value--;

   if (S->Value < 0) {
      add this process to S->list;
      block();
   }
}
```

The ```post()``` semaphore operation can now be defined as:
```
post(semaphore *S) {
   S->Value++;

   if (S->Value <= 0) {
      remove a process P from S->list;
      wakeup(P);
   }
}
```

[&uarr; Back to top](#table-of-content)


# Deadlock
* a set of processes is **deadlocked** when every process in the set is waiting for a resource that is currently allocated to another process in the set

There are four necessary conditions for deadlock.

<table>
<tbody>
<tr>
<td><b>Mutual Exclusion</b></td>
<td>The resources involved are non-shareable</td>
</tr>
<tr>
<td><b>Hold and Wait</b></td>
<td>A process must be simultaneously holding at least one resource and waiting for at least one resource that is currently being held by some other process.</td>
</tr>
<tr>
<td><b>No Preemption</b></td>
<td>Once a process is holding a resource then that resource cannot be taken away from that process until the process voluntarily releases it.</td>
</tr>
<tr>
<td><b>Circular Wait</b></td>
<td>The processes in the system form a circular list or chain where each process in the list is waiting for a resource held by the next process in the list.</td>
</tr>
</tbody>
</table>

## Prevention
* we can try to detect it and recover
* deadlocks can be avoided by preventing one of the four required conditions
* to prevent the *Hold and Wait*:
   * require that all processes request all resources at one time
   * require that processes holding resources must release them before requesting new resources
* to prevent *No Preemption*:
   * require that if a process is forced to wait when requesting a new resource, then all other resources held by this process are implicitly released
* to prevent *Circular Wait*:
   * number all resources, and require that processes request resources only in strictly increasing or decreasing order

## Example of a Deadlock
![example of deadlock](https://media.geeksforgeeks.org/wp-content/cdn-uploads/gq/2015/06/deadlock.png)

[&uarr; Back to top](#table-of-content)

# Additional Notes


[&uarr; Back to top](#table-of-content)



<script>
  
  $(document).ready(function() {

    var content = $('#content').next();

    console.log(content).html();


  });


</script>
