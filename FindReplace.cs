using System;
using System.Text.RegularExpressions;

namespace AutoRegex
{
    /// <summary>
    /// A Find & Replace object with a defined Match & Replace pattern
    /// </summary>
    class FindReplace
    {
        private String MatchPattern { get; }
        private String ReplacePattern { get; }

        public FindReplace(String matchPattern, String replacePattern)
        {
            MatchPattern = matchPattern;
            ReplacePattern = replacePattern;
        }
        /// <summary>
        /// Execute given string by defined Match & Replace patterns
        /// </summary>
        /// <param name="strInput">String to be moddified</param>
        /// <returns>Returns new moddified String value</returns>
        public String Execute(String strInput)
        {
            return Regex.Replace(strInput, MatchPattern, ReplacePattern);
        }
    }
}
