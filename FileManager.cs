using System;

namespace AutoRegex
{
    class FileManager
    {

        private FilePath fileSets;

        public FileManager(string inputFilePath)
        {
            fileSets = new FilePath(inputFilePath);
        }

        public string[] ReadRegexes() { return ReadFile(fileSets.RegexFile); }
        public string[] ReadInput() { return ReadFile(fileSets.InputFile); }
        public void PrintOutput(String[] content) { WriteFile(fileSets.OutputFile, false, content); }

        private static string[] ReadFile(String filePath)
        {
            Console.WriteLine("Reading " + filePath);
            string[] lines = { "" };
            try
            {
                lines = System.IO.File.ReadAllLines(filePath);
            } catch (Exception e)
            {

            }
            
            return lines;
        }

        public Boolean log(String message)
        {
            try
            {
                String[] msg = { message };
                WriteFile("error.txt", true, msg);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        private static void WriteFile(String filePath, Boolean append, params String[] output)
        {
            if (append) System.IO.File.AppendAllLines(filePath, output);
            else System.IO.File.WriteAllLines(filePath, output);
        }

        struct FilePath
        {
            public String InputFile { get; set; }
            public String RegexFile { get; set; }
            public String OutputFile { get; set; }

            public FilePath(String inputFilePath)
            {
                InputFile = inputFilePath;
                RegexFile = inputFilePath.Replace(".txt", "") + ".regex";
                OutputFile = inputFilePath.Replace(".txt", "") + ".output.txt";
            }

        }
    }
}
