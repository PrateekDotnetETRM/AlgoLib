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
    /// </summary>
    public static class GroupAnagrams
    {
        public static List<List<string>> FindGroupAnagramsWithLinq(string[] strs)
        {

            return [.. strs
                  .GroupBy(s => new string([.. s.OrderBy(c => c)]))
                  .Select(g => g.ToList())];


        }

        public static List<List<string>> FindGroupAnagramsWithDictionary(string[] strs)
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
            return map.Values.ToList();
        }
    }
}
