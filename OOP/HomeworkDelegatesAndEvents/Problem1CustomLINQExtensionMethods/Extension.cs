using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem1CustomLINQExtensionMethods
{
    public static class Extension
    {
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> func)
        {
            var result = new List<T>();

            foreach (var element in collection)
            {
                if (!func(element))
                {
                    result.Add(element);
                }
            }

            return result;
        }

        public static K Max<T, K>(this IEnumerable<T> collection, Func<T, K> func)
            where K : IComparable
        {
            if (collection == null || collection.Count() == 0)
            {
                throw new ArgumentNullException("Collection is null or emthy");
            }

            K max = default(K);
            bool isFirst = true;

            foreach (var element in collection)
            {
                if (isFirst)
                {
                    max = func(element);
                    isFirst = false;
                }

                K current = func(element);
                if (current.CompareTo(max) > 0)
                {
                    max = current;
                }
            }

            return max;
        }
    }
}
