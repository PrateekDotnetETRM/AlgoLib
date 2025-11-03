using AlgoLib.Core.Problems.Strings;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLib.Core.Problems.Arrays
{
    /// <summary>
    /// Medium : Dictionary solution might be better , linq has overhead .
    ///  Tuple will work well as well :D
    /// </summary>
    public static class GroupAnagrams
    {
        public static List<List<string>> GroupAnagramsWithLinq(string[] strs)
        {

            return [.. strs
                  .GroupBy(s => new string([.. s.OrderBy(c => c)]))
                  .Select(g => g.ToList())];


        }

        public static List<List<string>> GroupAnagramsWithDictionary(string[] strs)
        {
            var map = new Dictionary<string, List<string>>();
            foreach (var str in strs)
            {
                var chars = str.ToCharArray();
                Array.Sort(chars);
                var key = new string(chars);

                if (!map.TryGetValue(key, out var list))
                {
                    list = new List<string>();
                    map[key] = list;
                }
                list.Add(str);
            }
            return [.. map.Values];
        }

        public static List<List<string>> GroupAnagramsWithFrequencyMap(string[] strs)
        {
            var map = new Dictionary<string, List<string>>();


            foreach (var str in strs)
            {
                var count = new int[26];

                foreach (var c in str)
                {
                    count[c - 'a'] += 1;
                }
                var key = string.Join("#", count);
                if (!map.TryGetValue(key, out var list))
                {
                    list = [];
                    map[key] = list;
                }
                list.Add(str);
            }
            return [.. map.Values];
        }

        public static List<List<string>> GroupAnagramsUsingTuple(string[] strs)
        {
            var map = new Dictionary<(int, int, int, int, int, int, int, int, int, int,
                                      int, int, int, int, int, int, int, int, int, int,
                                      int, int, int, int, int, int), List<string>>();

            foreach (var str in strs)
            {
                var count = new int[26];
                foreach (var c in str)
                {
                    count[c - 'a']++;
                }

                var key = (
                    count[0], count[1], count[2], count[3], count[4], count[5], count[6],
                    count[7], count[8], count[9], count[10], count[11], count[12],
                    count[13], count[14], count[15], count[16], count[17], count[18],
                    count[19], count[20], count[21], count[22], count[23], count[24], count[25]
                );

                if (!map.TryGetValue(key, out var list))
                {
                    list = new List<string>();
                    map[key] = list;
                }

                list.Add(str);
            }

            return map.Values.ToList();
        }
    }
}
