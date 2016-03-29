using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Task4.NUnit.Tests
{
    public class BinarySearchLibTests
    {
        #region TestCases
        [TestCase(ExpectedException = typeof(ArgumentNullException))]
        public void BinarySearch_NullArray()
        {
            BinarySearchLib<int>.BinarySearch(null, 3, null);
        }

        [TestCase(0, Result = 0)]
        [TestCase(999, Result = 999)]
        [TestCase(1, Result = 1)]
        [TestCase(998, Result = 998)]
        [TestCase(-1, Result = -1)]
        [TestCase(1000, Result = -1)]
        [TestCase(500, Result = 500)]
        [TestCase(-15, Result = -1)]
        [TestCase(1001, Result = -1)]
        public int BinarySearch_IntDefaultComparer(int value)
        {
            int[] array = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                array[i] = i;
            }

            return BinarySearchLib<int>.BinarySearch(array, value, null);
        }

        [TestCase("0", Result = 0)]
        [TestCase("999", Result = 999)]
        [TestCase("1", Result = 1)]
        [TestCase("998", Result = 998)]
        [TestCase("-1", Result = -1)]
        [TestCase("1000", Result = -1)]
        [TestCase("500", Result = 447)]
        [TestCase("11", Result = 13)]
        [TestCase("-15", Result = -1)]
        [TestCase("1001", Result = -1)]
        public int BinarySearch_StringDefaultComparer(string value)
        {
            string[] array = new string[1000];
            for (int i = 0; i < 1000; i++)
            {
                array[i] = i.ToString();
            }

            List<string> temp = array.ToList();
            temp.Sort((IComparer<string>)null);
            array = temp.ToArray();
            
            return BinarySearchLib<string>.BinarySearch(array, value, null);
        }

        #endregion
    }
}
