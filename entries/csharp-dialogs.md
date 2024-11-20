

## Selecting a File

To select a folder, you can utilize the `OpenFileDialog` class. The following example demonstrates how to select a Markdown file:

```csharp
public static bool TrySelectingFile(out FileInfo? selectedFile)
{
    selectedFile = null;

    OpenFileDialog dialog = new()
    {
        DefaultExt = ".md",
        Filter = "Markdown (.md)|*.md",
        Multiselect = false,
    };

    if (!dialog.ShowDialog())
    {
        return false;
    }

    selectedFile = new(dialog.FileName);
    return true;
}
```

[Documentation](https://learn.microsoft.com/en-us/dotnet/api/microsoft.win32.openfiledialog)



## Selecting a Folder

To select a folder, you can utilize the `FolderBrowserDialog` class:

```csharp
public static bool TrySelectFolder(out DirectoryInfo selectedFolder)
{
    selectedFolder = default;

    // create an instance of a folder browser dialog
    using FolderBrowserDialog folderDialog = new();
    
    // display the dialog
    DialogResult result = folderDialog.ShowDialog();

    // if user did not hit ok return false
    if (result != DialogResult.OK)
    {
        return false;
    }

    // return the selected folder
    selectedFolder = new(folderDialog.SelectedPath);

    return true;
}
```


[Documentation](https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.folderbrowserdialog)



## Opening a Document

The provided function below opens the specified file using the user's default program. For instance, if the file was a Word Document, it would open the file in Microsoft Word. This also works for URL's. 

```csharp
public static void ViewDocument(string fileName)
{
    ProcessStartInfo startInfo = new(filename)
    {
        UseShellExecute = true,
    };

    Process.Start(startInfo);
}
```



















