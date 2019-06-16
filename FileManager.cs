using System;

namespace AutoRegex
{
    class FileManager
    {

        private FilePathSet fileSets;

        public FileManager(string inputFilePath)
        {
            fileSets = new FilePathSet(inputFilePath);
        }

        public string[] ReadRegexes() { return ReadFile(fileSets.RegexFile); }
        public string[] ReadInput() { return ReadFile(fileSets.InputFile); }
        public void PrintOutput(String[] content) { WriteFile(fileSets.OutputFile, false, content); }

        /// <summary>
        /// Reads all lines in the file of given file-path
        /// </summary>
        /// <param name="filePath">Absolute path of file to be read</param>
        /// <returns>Returns an Array of strings, one item for each line</returns>
        private static string[] ReadFile(String filePath)
        {
            // Console.WriteLine("Reading " + filePath);
            string[] lines = { "" };
            try
            {
                lines = System.IO.File.ReadAllLines(filePath);
            }
            catch (Exception e)
            {
                String errorMsg =  e.Message + "\n" + e.StackTrace;
                if (!log(errorMsg))
                {
                    Console.WriteLine(errorMsg);
                }
            }
            
            return lines;
        }

        /// <summary>
        /// Logs messages to a text file
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Boolean log(String message)
        {
            try
            {
                String[] msg = {
                    "[" + System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToLongTimeString() + "]",
                    "----------------------------------------" ,
                    message,
                    "----------------------------------------",
                    ""};
                WriteFile("error.log", true, msg);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Write to a file
        /// </summary>
        /// <param name="filePath">File-path of the file to write to</param>
        /// <param name="append">Decides if file should be re-written, or appended</param>
        /// <param name="output">Lines that should be written to file</param>
        private static void WriteFile(String filePath, Boolean append, params String[] output)
        {
            if (append) System.IO.File.AppendAllLines(filePath, output);
            else System.IO.File.WriteAllLines(filePath, output);
        }

        struct FilePathSet
        {
            public String InputFile { get; set; }
            public String RegexFile { get; set; }
            public String OutputFile { get; set; }

            public FilePathSet(String inputFilePath)
            {
                InputFile = inputFilePath;
                RegexFile = inputFilePath.Replace(".txt", "") + ".regex";
                OutputFile = inputFilePath.Replace(".txt", "") + ".output.txt";
            }

        }
    }
}
