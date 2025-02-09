namespace FilesApp;

class Program
{
    static void Main(string[] args)
    {
        string DesktopPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) , "files");
        string? pathWithFileName = FileHelper.CreateMyFile(DirectoryHelper.CreateMyDirectory(DesktopPath));

        if (!string.IsNullOrWhiteSpace(pathWithFileName))
        {
            FileHelper.WriteToMyFile(pathWithFileName);
            
            string? fileContent = FileHelper.ReadMyFile(pathWithFileName);
            FileHelper.AppendContentToMyFile(pathWithFileName);
            
            var newContent = FileHelper.ReadMyFile(pathWithFileName);
            if (newContent != null)
            { 
                fileContent = newContent;
            }
            FileHelper.CopyMyFile(pathWithFileName);
        }
        string currentDirectory = DirectoryHelper.GetMyCurrentDirectory();
        Console.WriteLine($"The current Directory is: {currentDirectory}");


        if (!string.IsNullOrWhiteSpace(DesktopPath))
        {
           var filesInDir = DirectoryHelper.ListFilesInDirectory(DesktopPath);
           var directorysInDir = DirectoryHelper.ListDirectorysInDirectory(DesktopPath);
        }
       
        Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
    }

    

    ///// <summary>
    ///// Lists all files in the specified directory.
    ///// </summary>
    ///// <param name="directoryPath">The path of the directory to list files from.</param>
    ///// <returns>An array of file paths in the specified directory.</returns>
    //private static string[] ListFilesInDirectory(string directoryPath)
    //{
    //    string[] filesInDir = Directory.GetFiles(directoryPath);
    //    for (int i = 0; i < filesInDir.Length; i++)
    //    {
    //        Console.WriteLine(filesInDir[i]);
    //    }
    //    return filesInDir;
    //}

    ///// <summary>
    ///// Lists all directories in the specified directory.
    ///// </summary>
    ///// <param name="directoryPath">The path of the directory to list directories from.</param>
    ///// <returns>An array of directory paths in the specified directory.</returns>
    //private static string[] ListDirectorysInDirectory(string directoryPath)
    //{
    //    var dirsInDir = Directory.GetDirectories(directoryPath);
    //    for (int i = 0; i < dirsInDir.Length; i++)
    //    {
    //        Console.WriteLine(dirsInDir[i]);
    //    }
    //    return dirsInDir;
    //}

    ///// <summary>
    ///// Creates a new directory with the specified name.
    ///// </summary>
    ///// <returns>The path of the created directory, or null if an error occurs.</returns>
    //private static string? CreateMyDirectory()
    //{
    //    Console.WriteLine("Enter the Name of the required Directory:");
    //    string? DirectoryPath = Console.ReadLine();
    //    if (!string.IsNullOrWhiteSpace(DirectoryPath))
    //    {
    //        if (Directory.Exists(DirectoryPath))
    //        {
    //            Console.WriteLine("Directory exists already");
    //        }
    //        else
    //        {
    //            Directory.CreateDirectory(DirectoryPath);
    //            Console.WriteLine("Successfully created Directory: " + DirectoryPath);
    //        }
    //    }
    //    else
    //    {
    //        Console.WriteLine("Invalid Directory Path!");
    //    }
    //    return DirectoryPath;
    //}

    ///// <summary>
    ///// Appends content to the specified file if it exists.
    ///// </summary>
    ///// <param name="pathWithFileName">The path and filename of the file to append content to.</param>
    //private static void AppendContentToMyFile(string pathWithFileName)
    //{
    //    if (File.Exists(pathWithFileName))
    //    {
    //        Console.WriteLine($"Do you want to write some content to {pathWithFileName}?\nContent:");
    //        string? content = Console.ReadLine();
    //        if (!string.IsNullOrWhiteSpace(content))
    //        {
    //            File.AppendAllText(pathWithFileName, content);
    //            Console.WriteLine("Added content to file successfully");
    //        }
    //    }
    //    else
    //    {
    //        Console.WriteLine("File did not exist!");
    //    }
    //}

    ///// <summary>
    ///// Writes content to the specified file if it exists.
    ///// </summary>
    ///// <param name="pathWithFileName">The path and filename of the file to write content to.</param>
    //private static void WriteToMyFile(string pathWithFileName)
    //{
    //    if (File.Exists(pathWithFileName) && Directory.Exists(Path.GetDirectoryName(pathWithFileName)))
    //    {
    //        Console.WriteLine($"Do you want to append some content to {pathWithFileName}?\nContent to append:");
    //        string? content = Console.ReadLine();
    //        if (!string.IsNullOrWhiteSpace(content))
    //        {
    //            File.WriteAllText(pathWithFileName, content);
    //            Console.WriteLine("Added content to file successfully");
    //        }
    //    }
    //    else
    //    {
    //        Console.WriteLine("File did not exist!");
    //    }
    //}

    ///// <summary>
    ///// Creates a new file with a unique name.
    ///// </summary>
    ///// <returns>The filename of the created file, or null if an error occurs.</returns>
    //private static string? CreateMyFile()
    //{
    //    Console.WriteLine($"Enter the path and filename of the file to create (default: {DefaultName}):");
    //    string? input = Console.ReadLine();
    //    string FileName = GetUniqueFileName(GetFileName(input), FileExtension);

    //    try
    //    {
    //        FileStream fs = File.Create(path: FileName);
    //        fs.Close();
    //        Console.WriteLine("File created");
    //        return FileName;
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"Failed to create file {FileName} (Exception: {ex.Message})");
    //        return null;
    //    }
    //}

    ///// <summary>
    ///// Reads the content of the specified file.
    ///// </summary>
    ///// <param name="pathWithFilename">The path and filename of the file to read.</param>
    ///// <returns>The content of the file, or null if an error occurs.</returns>
    //private static string? ReadMyFile(string pathWithFilename)
    //{
    //    try
    //    {
    //        if (File.Exists(pathWithFilename) && Directory.Exists(Path.GetDirectoryName(pathWithFilename)))
    //        {
    //            string content = File.ReadAllText(pathWithFilename);
    //            Console.WriteLine($"File {pathWithFilename} read!\nContent:\n\t {content}");
    //            return content;
    //        }
    //        else
    //        {
    //            Console.WriteLine("File or Directory did not exist!");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"Failed to read {pathWithFilename} (Exception: {ex.Message})");
    //    }
    //    return null;
    //}

    ///// <summary>  
    ///// Copies the specified file to a new location and returns the destination path.  
    ///// </summary>  
    ///// <param name="sourcePath">The path and filename of the file to copy.</param>  
    ///// <returns>The destination path and filename of the copied file, or null if an error occurs.</returns>  
    //private static string? CopyMyFile(string sourcePath)
    //{
    //    Console.Write("Enter the destination path and filename:");
    //    string? destinationInput = Console.ReadLine();
    //    string destinationPath = GetFileName(destinationInput) + '1' + FileExtension;
    //    try
    //    {
    //        File.Copy(sourcePath, destinationPath, overwrite: true);
    //        Console.WriteLine($"File copied from {sourcePath} to {destinationPath}");
    //        return destinationPath;
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"Failed to copy {sourcePath} to {destinationPath} (Exception: {ex.Message})");
    //        return null;
    //    }
    //}

    ///// <summary>
    ///// Generates a unique filename by appending an index if the file already exists.
    ///// </summary>
    ///// <param name="baseName">The base name of the file.</param>
    ///// <param name="extension">The file extension.</param>
    ///// <returns>A unique filename with the specified extension.</returns>
    //private static string GetUniqueFileName(string baseName, string extension)
    //{
    //    int index = 1;
    //    string fileName = Path.ChangeExtension(baseName, extension);
    //    while (File.Exists(fileName))
    //    {
    //        fileName = Path.ChangeExtension($"{baseName}_{index}", extension);
    //        index++;
    //    }
    //    return fileName;
    //}

    ///// <summary>
    ///// Returns the filename from the input or the default name if the input is null or whitespace.
    ///// </summary>
    ///// <param name="input">The input filename.</param>
    ///// <returns>The input filename or the default name.</returns>
    //private static string GetFileName(string? input)
    //{
    //    return !string.IsNullOrWhiteSpace(input) ? input : DefaultName;
    //}
}
