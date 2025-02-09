namespace FilesApp
{
    public static class DirectoryHelper
    {
        /// <summary>
        /// Lists all files in the specified directory.
        /// </summary>
        /// <param name="directoryPath">The path of the directory to list files from.</param>
        /// <returns>An array of file paths in the specified directory.</returns>
        public static string[] ListFilesInDirectory(string directoryPath)
        {
            string[] filesInDir = Directory.GetFiles(directoryPath);
            for (int i = 0; i < filesInDir.Length; i++)
            {
                Console.WriteLine(filesInDir[i]);
            }
            return filesInDir;
        }

        /// <summary>
        /// Lists all directories in the specified directory.
        /// </summary>
        /// <param name="directoryPath">The path of the directory to list directories from.</param>
        /// <returns>An array of directory paths in the specified directory.</returns>
        public static string[] ListDirectorysInDirectory(string directoryPath)
        {
            var dirsInDir = Directory.GetDirectories(directoryPath);
            for (int i = 0; i < dirsInDir.Length; i++)
            {
                Console.WriteLine(dirsInDir[i]);
            }
            return dirsInDir;
        }

        /// <summary>
        /// Creates a new directory with the specified name.
        /// </summary>
        /// <returns>The path of the created directory, or null if an error occurs.</returns>
        public static string? CreateMyDirectory(string? TargetPath = null)
        {

            if (string.IsNullOrWhiteSpace(TargetPath))
            {
                Console.WriteLine("Enter the Name of the required Directory:");
                TargetPath = Console.ReadLine();
            }

            if (!string.IsNullOrWhiteSpace(TargetPath))
            {
                if (Directory.Exists(TargetPath))
                {
                    Console.WriteLine("Directory existed");
                }
                else
                {
                    Directory.CreateDirectory(TargetPath);
                    Console.WriteLine("Successfully created Directory: " + TargetPath);
                }
                return TargetPath;
            }
            else
            {
                Console.WriteLine("Invalid Directory Path!");
            }
            return null;
        }

        public static string GetMyCurrentDirectory()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
