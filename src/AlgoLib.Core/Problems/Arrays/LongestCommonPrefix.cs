using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLib.Core.Problems.Arrays
{
    /// <summary>
    /// Easy
    /// String Builder does work the best in most senarios 
    /// </summary>
    public static class LongestCommonPrefix
    {
        public static string FindLongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0) return string.Empty;

            ReadOnlySpan<char> first = strs[0];
            int minLen = strs.Min(s => s.Length);

            for (int i = 0; i < minLen; i++)
            {
                char c = first[i];
                for (int j = 1; j < strs.Length; j++)
                {
                    if (strs[j][i] != c)
                        return first.Slice(0, i).ToString(); 
                }
            }

            return first.Slice(0, minLen).ToString(); 
        }

        public static string FindLongestCommonPrefixStringBuilder(string[] strs)
        {
            if (strs == null || strs.Length == 0) return string.Empty;

            int minLen = strs.Select(str => str.Length).Min();
            StringBuilder sb = new();
            for(int i = 0; i < minLen; i++)
            {
                char s = ' ';
                foreach(var str in strs)
                {
                    if(s == ' ')
                    {
                       s = str[i];
                    }
                    if(s != str[i])
                    {
                        s = ' ';
                        break;
                    } 
                    
                }
                if (s == ' ')
                {
                    break;
                }
                else
                {
                    sb.Append(s);
                }

            }
            return sb.ToString();
        }

        public static string FindLongestCommonPrefixOptimized(string[] strs)
        {
            if (strs == null || strs.Length == 0) return string.Empty;

            int minLen = strs.Min(str => str.Length);
            for (int i = 0; i < minLen; i++)
            {
                char currentChar = strs[0][i];
                for (int j = 1; j < strs.Length; j++)
                {
                    if (strs[j][i] != currentChar)
                    {
                        return strs[0][..i];
                    }
                }
            }

            return strs[0].Substring(0, minLen);
        }
    }
}
