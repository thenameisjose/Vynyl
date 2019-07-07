using FlattenArrays.Extensions;
using System;
using System.Collections.Generic;

namespace FlattenArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var jaggedList = new List<object>() {
                new List<object>() { "one", "two", new List<object> { "three" } }, "four" };

            var flatList = jaggedList.Flatten();

            Console.WriteLine(String.Join(",", flatList));
        }
    }
}
