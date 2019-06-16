using System;
using System.Collections.Generic;

namespace AutoRegex
{
    class Program
    {
        private List<FindReplace> regexSequence = new List<FindReplace>();

        static void Main(string[] args)
        {
            new Program("default.txt");
        }

        public Program(String inputFilePath)
        {
            // Init structures
            FileManager fm = new FileManager(inputFilePath);
            regexSequence = new List<FindReplace>();

            // Read Sequence of Regex Operations and save in regexSequence
            parseRegexes(fm.ReadRegexes());

            // Read the input data
            String[] input = fm.ReadInput();

            String[] output = new String[input.Length];

            // Necessary step, in order to simplify logic in below nesteled for-foreach statement.
            for (int i = 0; i < output.Length; ++i)
            {
                // Set initial value of each Output item to input.
                output[i] = input[i];
            }

            // Executes Find & Replace operation on all lines, for each FindReplace pattern-set
            foreach (FindReplace fr in regexSequence)
            {
                for (int i = 0; i < output.Length; ++i)
                {
                    output[i] = fr.Execute(output[i]);
                }
            }

            // Print results to file
            fm.PrintOutput(output);

            Console.WriteLine("All is good, check output-file to see results!");
            PressEnter("to Quit");
        }

        private static void PressEnter(string motivation)
        {
            Console.WriteLine("Press Enter " + motivation + "...");
            Console.ReadLine();
        }

        private void parseRegexes(String[] lines)
        {
            bool willHavePairNextTime = false;
            String RegexMatchPattern = "";
            foreach (String l in lines)
            {
                // Break this itteration if line is empty.
                if (l.Trim().Equals("")) continue;

                if (!willHavePairNextTime) RegexMatchPattern = l;
                else regexSequence.Add(new FindReplace(RegexMatchPattern, l));

                willHavePairNextTime = !willHavePairNextTime;
            }

            if (regexSequence.Count == 0)
            {
                Console.WriteLine("Regex File either is empty, has invalid/incomplete match-replace patterns or does not exist...");
                PressEnter("to Quit");
                System.Environment.Exit(0);
            }
        }
    }
}
