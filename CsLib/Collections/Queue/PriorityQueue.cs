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
            if (mCount == 0)
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

            throw new Exception("An unexpected exception occurred.");
        }

        public T Peek()
        {
            if (mCount == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            foreach (var kvp in mDict)
            {
                var queue = kvp.Value;
                if (queue.Count > 0)
                {
                    var item = queue.Peek();
                    return item;
                }
            }

            throw new Exception("An unexpected exception occurred.");
        }

        public int GetCount(int priority)
        {
            if (mDict.TryGetValue(priority, out var queue))
            {
                return queue.Count;
            }
            return 0;
        }

        public void PushBack(int priority, T item)
        {
            if (!mDict.TryGetValue(priority, out var queue))
            {
                queue = new Deque<T>(2, true);
                mDict.Add(priority, queue);
            }
            queue.PushBack(item);
            mCount++;
        }

        public void PushFront(int priority, T item)
        {
            if (!mDict.TryGetValue(priority, out var queue))
            {
                queue = new Deque<T>(2, true);
                mDict.Add(priority, queue);
            }
            queue.PushFront(item);
            mCount++;
        }

        public T PopBack(int priority)
        {
            if (!mDict.TryGetValue(priority, out var queue))
            {
                throw new InvalidOperationException("The queue is empty.");
            }
            if (queue.Count <= 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }
            var item = queue.PopBack();
            mCount--;
            return item;
        }

        public T PopFront(int priority)
        {
            if (!mDict.TryGetValue(priority, out var queue))
            {
                throw new InvalidOperationException("The queue is empty.");
            }
            if (queue.Count <= 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }
            var item = queue.PopFront();
            mCount--;
            return item;
        }

        public void MoveToBack(PriorityQueue<T> other)
        {
            foreach (var kvp in mDict)
            {
                int priority = kvp.Key;
                var queue = kvp.Value;
                while (queue.Count > 0)
                {
                    mCount--;
                    var item = queue.Dequeue();
                    other.PushBack(priority, item);
                }
            }
        }

        public void MoveToBack(int priority, PriorityQueue<T> other)
        {
            if (mDict.TryGetValue(priority, out var queue))
            {
                while (queue.Count > 0)
                {
                    mCount--;
                    var item = queue.PopFront();
                    other.PushBack(priority, item);
                }
            }
        }

        public void MoveToBack(Predicate<T> match, PriorityQueue<T> other)
        {
            foreach (var kvp in mDict)
            {
                int priority = kvp.Key;
                var queue = kvp.Value;
                while (queue.Count > 0 && queue.Remove(match, out var item))
                {
                    mCount--;
                    other.PushBack(priority, item);
                }
            }
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

        public bool Remove(int priority, T item)
        {
            if (mDict.TryGetValue(priority, out var queue))
            {
                if (queue.Remove(item))
                {
                    mCount--;
                    return true;
                }
            }
            return false;
        }

        public bool Remove(Predicate<T> match, out T target)
        {
            foreach (var kvp in mDict)
            {
                var queue = kvp.Value;
                if (queue.Remove(match, out target))
                {
                    mCount--;
                    return true;
                }
            }
            target = default(T);
            return false;
        }

        public void RemoveAll(Predicate<T> match, Action<T> onRemove = null)
        {
            foreach (var kvp in mDict)
            {
                var queue = kvp.Value;
                int count = queue.RemoveAll(match, onRemove);
                if (count > 0)
                {
                    mCount -= count;
                }
            }
        }

        public void RemoveAll(Action<T> onRemove = null)
        {
            foreach (var kvp in mDict)
            {
                var queue = kvp.Value;
                while (queue.Count > 0)
                {
                    mCount--;
                    var item = queue.Dequeue();
                    onRemove?.Invoke(item);
                }
            }
        }

        public bool Find(Predicate<T> match, out T target)
        {
            foreach (var kvp in mDict)
            {
                var queue = kvp.Value;
                if (queue.Find(match, out target))
                {
                    return true;
                }
            }

            target = default(T);
            return false;
        }

        public void FindAll(Predicate<T> match, ref List<T> result)
        {
            foreach (var kvp in mDict)
            {
                var queue = kvp.Value;
                queue.FindAll(match, ref result);
            }
        }

        public bool Contains(T item)
        {
            foreach (var kvp in mDict)
            {
                var queue = kvp.Value;
                if (queue.Contains(item))
                {
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            mDict.Clear();
            mCount = 0;
        }
    }
}
