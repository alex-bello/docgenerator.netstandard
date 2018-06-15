using System;
using System.Text;

namespace DocsGenerator.Utils
{
    public static class StringExtensions 
    {
        public static string Repeat(this string s, int n)
        {
            return new StringBuilder(s.Length * n).Insert(0, s, n).ToString();
        }
    }

}