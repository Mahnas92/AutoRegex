using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void PrintOutput(String[] content) { WriteFile(fileSets.OutputFile, content); }

        private string[] ReadFile(String filePath)
        {
            string[] lines = { "" };
            lines = System.IO.File.ReadAllLines(filePath);
            return lines;
        }

        private void WriteFile(String filePath, String[] output)
        {
            System.IO.File.WriteAllLines(filePath, output);
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
