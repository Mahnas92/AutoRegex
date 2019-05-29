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
            parse(fm.ReadRegexes())

            // Read the input data
            String[] input = { "9207112898", "user@sub.mail.com", "9207112898@testmail.com" };

            // For each squence item, execute on all input lines
            String[] output = new String[input.Length];
            for (int i = 0; i < output.Length; ++i)
            {
                output[i] = input[i];
            }
            foreach (FindReplace fr in regexSequence)
            {
                for (int i = 0; i < output.Length; ++i)
                {
                    output[i] = fr.Execute(output[i]);
                }
            }
            /* START DEBUG */
            for (int i = 0; i < output.Length; ++i)
            {
                Console.WriteLine(input[i] + "\n--->\n" + output[i] + "\n");
            }
            /* END DEBUG */

            // Print results to file

            PressEnter("to Quit");
        }

        private static void PressEnter(string motivation)
        {
            Console.WriteLine("Press Enter " + motivation + "...");
            Console.ReadLine();
        }

        private void parse(String[] lines)
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
        }
    }
}
