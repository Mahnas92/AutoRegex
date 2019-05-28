using System;
using System.Collections.Generic;

namespace AutoRegex
{
    class Program
    {
        private List<FindReplace> regexSequence = new List<FindReplace>();

        static void Main(string[] args)
        {
            new Program();
        }

        public Program()
        {
            regexSequence = new List<FindReplace>();
            // Read Sequence of Regex Operations and save in regexSequence
            // Read the input data
            // For each squence item, execute on all input lines
            // Print result

            testPrep1();
            testPrep2();

            PressEnter("to Quit");
        }

        private static void PressEnter(string motivation)
        {
            Console.WriteLine("Press Enter " + motivation + "...");
            Console.ReadLine();
        }

        private void testPrep1()
        {
            FindReplace fnr = new FindReplace("([0-9]{6,6})([0-9]{2,2})", @"$1-$2");
            string orig = "9207112898";
            string result = fnr.Execute(orig);
            Console.WriteLine("Original:\t{0} \nResult: \t{1}", orig, result);
        }

        private void testPrep2()
        {
            FindReplace fnr = new FindReplace("(.*)@(.*\\.com)", "Mail-user: \"$1\" and Mail-server: \"$2$3\" on the domain: \"$3\"");
            string orig = "user@sub.mail.com";
            string result = fnr.Execute(orig);
            Console.WriteLine("Original:\t{0} \nResult: \t{1}", orig, result);
        }
    }
}
