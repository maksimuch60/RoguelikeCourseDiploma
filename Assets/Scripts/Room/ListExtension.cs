using System;
using System.Collections.Generic;

namespace RogueLike.Room
{
    public static class ListExtension
    {
        public static IList<T> RandomSort<T>(this IList<T> list)
        {
            if (list == null || list.Count == 0)
            {
                return default;
            }
            Random random = new Random();
            
            for (int i = list.Count - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                (list[j], list[i]) = (list[i], list[j]);
            }

            return list;
        }
    }
}