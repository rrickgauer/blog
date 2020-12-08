My computer at work is a Windows. Lately I have been having to use batch files for moving documents around. I wanted a way to pin a batch file to my taskbar, but Windows doesn't have a way to do this. After some research, the answered offered [here](https://superuser.com/questions/100249/how-to-pin-either-a-shortcut-or-a-batch-file-to-the-new-windows-7-8-and-10-task/193255#193255) is one that works for me.

1. Create a shortcut to your batch file.
1. Get into shortcut property and change target to something like: `cmd.exe /C "path-to-your-batch"`
1. Simply drag your new shortcut to the taskbar. It should now be pinnable.