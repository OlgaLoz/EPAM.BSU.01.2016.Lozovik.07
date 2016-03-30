using System;
using System.Collections;
using System.Collections.Generic;

namespace Task3
{
    interface IQueue<T>
    {
        void Enqueue(T value);
        T Dequeue();
        T Peek();
        void Clear();
    }

    public class CustomQueue<T> : IQueue<T>,IEnumerable<T>
    {
        private T[] items;
        private int capacity;
        private int count;
        private bool wasModifiing;

        public int Count => count;

        public CustomQueue(int capacity = 1)
        {
            capacity = capacity <= 0 ? 1 : capacity;
            this.capacity = capacity;
            items = new T[capacity];
        }
        
        #region Implementation of IEnumerable<T>
        public IEnumerator<T> GetEnumerator()
        {
            return  new CustomIterator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        #region Custom Iterator
        public struct CustomIterator:IEnumerator<T>
        {
            private int currentIndex;
            private readonly CustomQueue<T> container;

            internal CustomIterator(CustomQueue<T> container)
            {
                this.container = container;
                this.container.wasModifiing = false;
                currentIndex = -1;
            }

            public T Current
            {
                get
                {
                    if (currentIndex == -1 || currentIndex == container.Count)
                    {
                        throw new InvalidOperationException();
                    }
                    return container.items[currentIndex];
                }
            }

            public bool MoveNext()
            {
                if (container.wasModifiing)
                {
                    throw new InvalidOperationException("Queue was modified after creation iterator!");
                }
                if (currentIndex != container.Count)
                {
                    currentIndex++;
                }
                return currentIndex < container.Count;
            }

            public void Reset()
            {
                if (container.wasModifiing)
                {
                    throw new InvalidOperationException("Queue was modified after creation iterator!");
                }

                currentIndex = -1;
            }

            object IEnumerator.Current => Current;

            public void Dispose() { }
        }
        #endregion

        #region Implementation of IQueue<T>
        public void Enqueue(T value)
        {
            wasModifiing = true;
            if (count == items.Length)
            {
                capacity *= 2;
                var tempItems = new T[capacity];
                items.CopyTo(tempItems, 0);
                items = tempItems;
            }
            items[count] = value;
            count++;
        }

        public T Dequeue()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }
            wasModifiing = true;
            T result = items[0];
            for (int i = 0; i < count - 1; i++)
            {
                items[i] = items[i + 1];
            }
            count--;
            return result;
        }

        public T Peek()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }

            return items[count - 1];
        }

        public void Clear()
        {
            wasModifiing = true;
            items = new T[0];
            count = 0;
        }
        #endregion
    }
}
