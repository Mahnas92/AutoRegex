using System;
using System.Text.RegularExpressions;

namespace AutoRegex
{
    class FindReplace
    {
        private String FindExpression { get; }
        private String ReplacePattern { get; }

        public FindReplace(String findExpression, String replacePattern)
        {
            FindExpression = findExpression;
            ReplacePattern = replacePattern;
        }

        public String ExecuteOperation(String strInput)
        {
            return Regex.Replace(strInput, FindExpression, ReplacePattern);
        }
    }
}
