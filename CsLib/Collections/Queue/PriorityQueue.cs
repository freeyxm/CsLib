using System;
using System.Collections.Generic;

namespace CsLib.Collections
{
    public class PriorityQueue<T>
    {
        private SortedDictionary<int, Deque<T>> mDict = new SortedDictionary<int, Deque<T>>(); // priority => queue
        private int mCount = 0;

        public int Count => mCount;

        public void Enqueue(int priority, T item)
        {
            if (!mDict.TryGetValue(priority, out var queue))
            {
                queue = new Deque<T>(2, true);
                mDict.Add(priority, queue);
            }
            queue.Enqueue(item);
            mCount++;
        }

        public T Dequeue()
        {
            if (mCount <= 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            foreach (var kvp in mDict)
            {
                var queue = kvp.Value;
                if (queue.Count > 0)
                {
                    var item = queue.Dequeue();
                    mCount--;
                    return item;
                }
            }

            throw new InvalidOperationException("The queue is empty.");
        }

        public T Peek()
        {
            if (mCount <= 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            foreach (var kvp in mDict)
            {
                var queue = kvp.Value;
                if (queue.Count > 0)
                {
                    var item = queue.PeekFront();
                    return item;
                }
            }

            throw new InvalidOperationException("The queue is empty.");
        }

        public bool Remove(T item)
        {
            foreach (var kvp in mDict)
            {
                var queue = kvp.Value;
                if (queue.Remove(item))
                {
                    mCount--;
                    return true;
                }
            }
            return false;
        }

        public bool Remove(Predicate<T> match)
        {
            foreach (var kvp in mDict)
            {
                var queue = kvp.Value;
                if (queue.Remove(match, out _))
                {
                    mCount--;
                    return true;
                }
            }
            return false;
        }

        public void RemoveAll(Predicate<T> match)
        {
            foreach (var kvp in mDict)
            {
                var queue = kvp.Value;
                int count = queue.RemoveAll(match);
                if (count > 0)
                {
                    mCount -= count;
                }
            }
        }
    }
}
