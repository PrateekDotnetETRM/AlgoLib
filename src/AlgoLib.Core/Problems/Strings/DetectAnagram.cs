using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLib.Core.Problems.Strings
{
    /// <summary>
    /// Detect Angram (Return true if both strings are anagram)
    /// Linq code seems to be the best in terms of execution time . Posibaly due to optimized internal implementation of native code
    /// </summary>
    public static class DetectAnagram
    {

        public static bool IsAnagram(string s, string t)
        {
            s = s.Normalize(NormalizationForm.FormC);
            t = t.Normalize(NormalizationForm.FormC);

            if (s.Length == 0 || t.Length == 0 || s.Length != t.Length)
            {
                return false;
            }

            Dictionary<char, int> dict = new();
            for (int i = 0; i < s.Length; i++)
            {
                if (dict.TryGetValue(s[i], out int c))
                {
                    dict[s[i]] = c + 1;
                }
                else
                {
                    dict[s[i]] = 1;
                }
                if (dict.TryGetValue(t[i], out int p))
                {
                    dict[t[i]] = p - 1;
                }
                else
                {
                    dict[t[i]] = -1;
                }
            }
            foreach (var c in dict)
            {
                if (c.Value != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsAnagramDifferent(string s, string t)
        {
            s = s.Normalize(NormalizationForm.FormC);
            t = t.Normalize(NormalizationForm.FormC);

            if (s.Length != t.Length)
                return false;

            Dictionary<char, int> counts = [];

            for (int i = 0; i < s.Length; i++)
            {
                char sc = s[i];
                char tc = t[i];

                counts[sc] = counts.GetValueOrDefault(sc) + 1;
                counts[tc] = counts.GetValueOrDefault(tc) - 1;
            }

            return counts.Values.All(v => v == 0);
        }




        public static bool IsAnagramLinq(string s, string t)
        {
            s = s.Normalize(NormalizationForm.FormC);
            t = t.Normalize(NormalizationForm.FormC);

            if (s.Length != t.Length)
                return false;

            return s.GroupBy(c => c)
                    .ToDictionary(g => g.Key, g => g.Count())
                    .OrderBy(kvp => kvp.Key)
                    .SequenceEqual(
                        t.GroupBy(c => c)
                         .ToDictionary(g => g.Key, g => g.Count())
                         .OrderBy(kvp => kvp.Key)
                    );
        }
    }
}
