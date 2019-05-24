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
            testPrep1();
            testPrep2();

            // Quit
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();
        }

        private void testPrep1()
        {
            FindReplace fnr = new FindReplace("([0-9][0-9][0-9][0-9][0-9][0-9])([0-9][0-9][0-9][0-9])", "$1-$2");
            string orig = "9207112898";
            string result = fnr.ExecuteOperation(orig);
            Console.WriteLine("Original:\t{0} \nResult: \t{1}", orig, result);
        }

        private void testPrep2()
        {
            FindReplace fnr = new FindReplace("([0-9]{6,6})([0-9]{2,2})", @"\$1-$2");
            string orig = "9207112898";
            string result = fnr.ExecuteOperation(orig);
            Console.WriteLine("Original:\t{0} \nResult: \t{1}", orig, result);
        }
    }
}
