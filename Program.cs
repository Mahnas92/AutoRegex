using System;
using System.Collections.Generic;
using System.IO;

namespace AutoRegex
{
    class Program
    {
        private List<FindReplace> regexSequence = new List<FindReplace>();

        static void Main(string[] args)
        {
            String inputFilePath = "input.txt";
            String regexFilePath = "default.regex";
            String outputFilePath = "";

            for (int i = 0; i < args.Length; i++)
            {
                String arg = args[i];
                if (File.Exists(arg))
                {
                    switch (i)
                    {
                        case 0:
                            inputFilePath = arg;
                            break;
                        case 1:
                            regexFilePath = arg;
                                break;
                        case 2:
                            outputFilePath = arg;
                            break;
                    }
                }
            }

            Console.WriteLine("Initiating!\n\n");
            Console.WriteLine("Set to run Regex File:\n" + regexFilePath);
            Console.WriteLine("\n... on the Text File:\n" + inputFilePath);

            new Program(inputFilePath, regexFilePath, outputFilePath);
        }

        public Program(String inputFilePath, String regexFilePath , String outputFilePath)
        {
            // Init structures
            FileManager fm = new FileManager(inputFilePath, regexFilePath, outputFilePath);
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
            Console.WriteLine("\nOutput File:\n" + outputFilePath);

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
                if (l.Trim().Equals("") && !willHavePairNextTime) continue;

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
