using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Task5.NUnit.Tests
{
    [TestFixture]
    public class SorterTests
    {
        #region Comparers
        private class StringByLengthAscending : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                if (x == null || y != null && x.Length > y.Length)
                {
                    return 1;
                }
                return -1;
            }
        }

        private class IntDescending : IComparer<int>
        {
            public int Compare(int x, int y) => x < y ? 1 : -1;
        }

        private int IntArrayBySumAscending(int[] x, int[] y)
        {
            if (x == null || y != null && y.Length != 0 && (x.Length == 0 || x.Sum() > y.Sum()))
            {
                return 1;
            }
            return -1;
        }

        private int IntArrayByMaxDescending(int[] x, int[] y)
        {
            if (x == null || y != null && y.Length != 0 && (x.Length == 0 || x.Max() < y.Max()))
            {
                return 1;
            }
            return -1;
        }

        private int IntArrayByLengthDescending(int[] x, int[] y)
        {
            if (x == null || y != null && y.Length != 0 && (x.Length == 0 || x.Length < y.Length))
            {
                return 1;
            }
            return -1;
        }
        #endregion

        #region TestCases
        [TestCase(ExpectedException = typeof(ArgumentNullException))]
        public void Sort_NullArray()
        {
            Sorter<int[]>.Sort(null, IntArrayBySumAscending);
        }

        [TestCase]
        public void Sort_NullComparer_RefIComparableType()
        {
            string[] expected = {"a", "l", "t"};
            string[] actual = { "l", "t", "a" };
            Sorter<string>.Sort(actual, (Comparison<string>)null);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void Sort_NullComparer_ValIComparableType()
        {
            int[] expected = { 1, 2, 3 };
            int[] actual = { 2, 3, 1 };
            Sorter<int>.Sort(actual, (Comparison<int>)null);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(ExpectedException = typeof(ArgumentNullException))]
        public void Sort_NullComparer_RefTypeHasNotDefaulltCompaper()
        {
            Sorter<List>.Sort(new []{new List(), new List()}, (Comparison<List>)null);
        }

        [TestCase]
        public void Sort_IntAtrrayByMax_Descending_WithNullArray()
        {
            int[][] expected = { new[] { 1, 8 }, new[] { 2, 5 }, new[] { 0, 0 }, null, null };
            int[][] actual = { new[] { 2, 5 }, null, new[] { 1, 8 }, new[] { 0, 0 }, null };
            Sorter<int[]>.Sort(actual, IntArrayByMaxDescending);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void Sort_IntArrayByMax_Descending_WithNullAndEmptyArray()
        {
            int[][] expected = { new[] { 1, 8 }, new[] { 2, 5 }, new[] { 0, 0 }, new int[] { }, new int[] { }, new int[] { }, null, null };
            int[][] actual = { new int[] { }, new[] { 2, 5 }, new int[] { }, null, new[] { 1, 8 }, new int[] { }, new[] { 0, 0 }, null };
            Sorter<int[]>.Sort(actual, IntArrayByMaxDescending);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void Sort_IntArrayByMax_Ascending()
        {
            int[][] expected = { new[] { 3, 4 }, new[] { 1, 8 } };
            int[][] actual = { new[] { 1, 8 }, new[] { 3, 4 } };
            Sorter<int[]>.Sort(actual, IntArrayBySumAscending);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void Sort_StringByLength_Asscending()
        {
            string[] expected = {"q", "qq", "qqqq", "qqqqq"};
            string[] actual = { "qq", "q", "qqqqq", "qqqq" };
            Sorter<string>.Sort(actual, new StringByLengthAscending());
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void Sort_Int_Descending()
        {
            int[] expected = {25, 14, 8, 0, -3 };
            int[] actual = { 14, 8, -3, 0, 25 };
            Sorter<int>.Sort(actual, new IntDescending());
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void Sort_IntArrayByLength_Descending()
        {
            int[][] expected = { new[] { 1, 8, 5, 90, 64 }, new[] { 2, 5 }, new[] { 0 } };
            int[][] actual = { new[] { 2, 5 }, new[] { 1, 8, 5, 90, 64 }, new[] { 0} };
            Sorter<int[]>.Sort(actual, IntArrayByLengthDescending);
            Assert.AreEqual(expected, actual);
        }
        #endregion
    }
}
