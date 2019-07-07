using FlattenArrays;
using FlattenArrays.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class Extensions_Flatten_Should
    {
        [Test]
        public void ReturnFlatListOfStrings()
        {
            //arrange
            var nestedArray = new List<object>() {
                new List<object>() { "one", "two", new List<object> { "three" } }, "four" };

            //act
            var result = nestedArray.Flatten();

            //assert
            Assert.IsTrue(result is List<object>);
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(String.Join(",", result), "one,two,three,four");
        }

        [Test]
        public void ReturnFlatListOfIntegers()
        {
            //arrange
            var nestedArray = new List<object>() {
                new List<object>() { 1, 2, new List<object> { 3 } }, 4 };

            //act
            var result = nestedArray.Flatten();

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(String.Join(",", result), "1,2,3,4");
        }

        [Test]
        public void ReturnFlatListOfMixedTypes()
        {
            //arrange
            var nestedArray = new List<object>() {
                new List<object>() { 1, "three", new List<object> { 5 } }, "seven" };

            //act
            var result = nestedArray.Flatten();

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(String.Join(",", result), "1,three,5,seven");
        }

        [Test]
        public void SupportEmptyList()
        {
            //arrange
            var nestedArray = new List<object>();

            //act
            var result = nestedArray.Flatten();

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }
    }
}