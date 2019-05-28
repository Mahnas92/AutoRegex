using System;
using System.Text.RegularExpressions;

namespace AutoRegex
{
    class FindReplace
    {
        private String MatchPattern { get; }
        private String ReplacePattern { get; }

        public FindReplace(String matchPattern, String replacePattern)
        {
            MatchPattern = matchPattern;
            ReplacePattern = replacePattern;
        }

        public String Execute(String strInput)
        {
            return Regex.Replace(strInput, MatchPattern, ReplacePattern);
        }
    }
}
