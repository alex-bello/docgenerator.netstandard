using System;
using System.Text;
using System.Text.RegularExpressions;

namespace DocsGenerator.Utils
{
    /// <summary>
    /// Removes all newline characters from string.
    /// </summary>
    public static partial class StringExtensions 
    {
        public static string RemoveNewLines(this string s)
        {
            return Regex.Replace(s,"\n", "");
        }
    }

}