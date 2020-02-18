# CSCI 480 - Operating Systems - Exam 1 Review Sheet
This is a study guide I wrote to help myself review for my first exam in my [operating systems class](http://faculty.cs.niu.edu/~hutchins/csci480/main.htm).

# Table of Content
1. Introduction and OS Structures*
2. [Process Management](#process-management)
    1. [Process Control Block](#process-control-block)
    2. [Schedulers](#schedulers)
    3. [Scheduling Queues](#scheduling-queues)
    4. [Context Switch](#context-switch)
    5. [Interprocess Communication](#interprocess-communication)
    6. [Zombie and Orphan Processes](#zombie-and-orphan-processes)

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
* the primary distinction between the 2 schedulers lies in frequence of execution
* the short term scheduler selects processes frequently
* the long term scheduler select processes much less frequently
  * minutes may seperate the creation of one new process and the next

### Degree of Multiprogramming
* the **degree of multiprogramming** is the number of processes in memory
* it is controlled by the long term scheduler
* if the degree of multiprogramming is stable, then the average rate of process creation must be equal to the average departure rate of processes leaving the system

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
* occurs when switching the cpu to another process
* when a context switch occurs, the kernel saves the context of the old process in its PCB and loads the saved context of the new process that is scheduled to run
* pure overhead since the system does no useful work while switching

## Interprocess Communication
* processes executing concurrently may be either independent or cooperating processes
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





















