namespace FilesApp
{
    public static class FileHelper
    {
        private const string FileExtension = ".txt";
        private const string DefaultName = "Test";


        /// <summary>
        /// Creates a new file with a unique name.
        /// </summary>
        /// <returns>The filename of the created file, or null if an error occurs.</returns>
        public static string? CreateMyFile(string? DirectoryPath = null)
        {
            Console.WriteLine($"Enter the filename to create (default: {DefaultName}):");
            string? input = Console.ReadLine();
            string FileName = Path.Combine(DirectoryPath ?? string.Empty,GetFileName(input) + FileExtension);

            try
            {
                FileStream fs = File.Create(path: FileName);
                fs.Close();
                Console.WriteLine($"File {FileName} successfully created");
                Console.WriteLine();
                return FileName;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to create file {FileName} (Exception: {ex.Message})");
                Console.WriteLine();
                return null;
            }
        }


        /// <summary>
        /// Writes content to the specified file if it exists.
        /// </summary>
        /// <param name="pathWithFileName">The path and filename of the file to write content to.</param>
        public static void WriteToMyFile(string pathWithFileName)
        {
            if (File.Exists(pathWithFileName))
            {
                Console.WriteLine($"Do you want to append some content to {pathWithFileName}?\nContent to append:");
                string? content = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(content))
                {
                    File.WriteAllText(pathWithFileName, content);
                    Console.WriteLine("Added content to file successfully");
                }
                else
                {
                    Console.WriteLine("No content to write");
                }
            }
            else
            {
                Console.WriteLine("File did not exist!");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Appends content to the specified file if it exists.
        /// </summary>
        /// <param name="pathWithFileName">The path and filename of the file to append content to.</param>
        public static void AppendContentToMyFile(string pathWithFileName)
        {
            if (File.Exists(pathWithFileName))
            {
                Console.WriteLine($"Do you want to write some content to {pathWithFileName}?\nContent:");
                string? content = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(content))
                {
                    File.AppendAllText(pathWithFileName,$"\n{content}");
                    Console.WriteLine("Added content to file successfully");
                }
                else
                {
                    Console.WriteLine("No content to append");
                }
            }
            else
            {
                Console.WriteLine("File did not exist!");
            }
            Console.WriteLine();
        }
        
        /// <summary>
        /// Reads the content of the specified file.
        /// </summary>
        /// <param name="pathWithFilename">The path and filename of the file to read.</param>
        /// <returns>The content of the file, or null if an error occurs.</returns>
        public static string? ReadMyFile(string pathWithFilename)
        {
            try
            {
                if (File.Exists(pathWithFilename))
                {
                    string content = File.ReadAllText(pathWithFilename);
                    Console.WriteLine($"File {pathWithFilename} read!\nContent:\n{content}");
                    Console.WriteLine();
                    return content;
                }
                else
                {
                    Console.WriteLine("File or Directory did not exist!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to read {pathWithFilename} (Exception: {ex.Message})");
            }
            Console.WriteLine();
            return null;
        }

        /// <summary>  
        /// Copies the specified file to a new location and returns the destination path.  
        /// </summary>  
        /// <param name="sourcePath">The path and filename of the file to copy.</param>  
        /// <returns>The destination path and filename of the copied file, or null if an error occurs.</returns>  
        public static string? CopyMyFile(string sourcePath)
        {
            Console.Write("Enter the destination path and filename:");
            string? destinationInput = GetFileName(Console.ReadLine());
            string destinationPath = destinationInput == DefaultName ? destinationInput + '1' + FileExtension : destinationInput + FileExtension;
            DirectoryHelper.CreateMyDirectory(destinationPath);
            try
            {
                File.Copy(sourcePath,Path.Combine(Path.GetDirectoryName(sourcePath)!, destinationPath), overwrite: true);
                Console.WriteLine($"File copied from {sourcePath} to {destinationPath}");
                Console.WriteLine();
                return destinationPath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to copy {sourcePath} to {destinationPath} (Exception: {ex.Message})");
                Console.WriteLine();
                return null;
            }
        }

        /// <summary>
        /// Generates a unique filename by appending an index if the file already exists.
        /// </summary>
        /// <param name="baseName">The base name of the file.</param>
        /// <param name="extension">The file extension.</param>
        /// <returns>A unique filename with the specified extension.</returns>
        private static string GetUniqueFileName(string baseName, string extension)
        {
            int index = 1;
            string fileName = Path.ChangeExtension(baseName, extension);
            while (File.Exists(fileName))
            {
                fileName = Path.ChangeExtension($"{baseName}_{index}", extension);
                index++;
            }
            return fileName;
        }

        /// <summary>
        /// Returns the filename from the input or the default name if the input is null or whitespace.
        /// </summary>
        /// <param name="input">The input filename.</param>
        /// <returns>The input filename or the default name.</returns>
        private static string GetFileName(string? input)
        {
            return !string.IsNullOrWhiteSpace(input) ? Path.GetFileNameWithoutExtension(input) : DefaultName;
        }
    }
}
