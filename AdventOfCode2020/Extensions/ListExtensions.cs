using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Extensions
{
    public static class ListExtensions
    {
        public static List<T> Slice<T>(this List<T> list, int start, int end = 0)
        {
            if (end == 0)
            {
                end = list.Count;
            }

            return list.GetRange(start, end - start);
        }
    }
}
