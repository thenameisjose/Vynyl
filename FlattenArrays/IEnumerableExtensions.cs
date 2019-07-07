using System;
using System.Collections.Generic;
using System.Text;

namespace FlattenArrays.Extensions
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Flattens an IEnumerable collection of arbitrarily nested collections into a flat list.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static List<object> Flatten(this IEnumerable<object> items)
        {
            var result = new List<object>();
            foreach(var item in items)
            {
                if(item is IEnumerable<object>)
                {
                    var subList = (item as List<object>).Flatten();
                    if(null != subList && subList.Count > 0)
                        result.AddRange(subList);
                }
                else
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
