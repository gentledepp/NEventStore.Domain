using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEventStore.Domain
{
    internal static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> e, Action<T> action)
        {
            foreach (var item in e)
            {
                action(item);
            }
        }
    }
}
