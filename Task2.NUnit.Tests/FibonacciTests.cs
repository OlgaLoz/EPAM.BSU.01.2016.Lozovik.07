using System;
using System.Collections.Generic;
using static Task2.Fibonacci;
using NUnit.Framework;

namespace Task2.NUnit.Tests
{
    [TestFixture]
    public class FibonacciTests
    {
        [TestCase(ExpectedException = typeof(ArgumentException))]
        public void CountFibonacci_BadIndex()
        {
            IEnumerable<int> actual = CountFibonacci(0);
            Assert.AreEqual(new List<int>(), actual);
        }

        [TestCase]
        public void CountFibonacci_OneNumber()
        {
            IEnumerable<int> expected = new List<int> { 1 };
            IEnumerable<int> actual = CountFibonacci(1);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void CountFibonacci_ManyNumbers()
        {
            IEnumerable<int> expected = new List<int> {1, 1, 2, 3, 5, 8, 13, 21, 34};
            IEnumerable<int> actual = CountFibonacci(9);
            Assert.AreEqual(expected, actual);
        }
    }
}
