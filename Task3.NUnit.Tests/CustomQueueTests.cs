using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Task3.NUnit.Tests
{
    [TestFixture]
    public class CustomQueueTests
    {
        [TestCase(ExpectedException = typeof(InvalidOperationException))]
        public void DequeueFromEmptyQueue_Test()
        {
            CustomQueue<int> actual = new CustomQueue<int>();
            actual.Dequeue();
        }

        [TestCase(ExpectedException = typeof(InvalidOperationException))]
        public void PeekFromEmptyQueue_Test()
        {
            CustomQueue<int> actual = new CustomQueue<int>();
            actual.Peek();
        }

        [TestCase(-2)]
        [TestCase(0)]
        [TestCase(4)]
        public void Enqueue_Dequeue_Capacity_Test(int capacity)
        {
            CustomQueue<int> actual = new CustomQueue<int>(capacity);
            int[] expected = new int[10];
            for (int i = 0; i < 10; i++)
            {
                actual.Enqueue(i);
                expected[i] = i;
            }
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(expected[i], actual.Dequeue());
            }
        }

        [TestCase]
        public void Enqueue_Peek_Test()
        {
            CustomQueue<int> actual = new CustomQueue<int>();
            int expected = 0;
            actual.Enqueue(0);
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(expected, actual.Peek());
            }
        }

        [TestCase(ExpectedException = typeof(InvalidOperationException))]
        public void Enqueue_Clear_Dequeue_Test()
        {
            CustomQueue<int> actual = new CustomQueue<int>();
            actual.Enqueue(0);
            actual.Clear();
            actual.Dequeue();
        }

        [TestCase(ExpectedException = typeof(InvalidOperationException))]
        public void Iterator_ByForeach_TryToEnqueue()
        {
            CustomQueue<string> actual = new CustomQueue<string>();
            actual.Enqueue("q");

            foreach (var t in actual)
            {
                actual.Enqueue(t);
            }
        }

        [TestCase(ExpectedException = typeof(InvalidOperationException))]
        public void Iterator_ByForeach_TryToDequeue()
        {
            CustomQueue<string> actual = new CustomQueue<string>();
            actual.Enqueue("q");

            foreach (var t in actual)
            {
                actual.Dequeue();
            }
        }

        [TestCase(ExpectedException = typeof(InvalidOperationException))]
        public void Iterator_ByForeach_TryToClear()
        {
            CustomQueue<string> actual = new CustomQueue<string>();
            actual.Enqueue("q");

            foreach (var t in actual)
            {
                actual.Clear();
            }
        }

        [TestCase]
        public void Iterator_ByWhile_TryToPeek()
        {
            CustomQueue<int> actual = new CustomQueue<int>();
            int expected = 9;
            for (int i = 0; i < 10; i++)
            {
                actual.Enqueue(i);
            }

            IEnumerator<int> iterator= actual.GetEnumerator();
            while (iterator.MoveNext())
            {
                Assert.AreEqual(actual.Peek(), expected);
            }
        }
    }
}
