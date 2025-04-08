using System;

namespace CsLib.Collections
{
    public class Deque<T>
    {
        private T[] mArray;
        private int mCount;
        private int mHead;
        private int mTail;
        private bool mAutoResize;

        public Deque(int capacity, bool autoResize)
        {
            mArray = new T[capacity];
            mHead = mTail = 0;
            mCount = 0;
            mAutoResize = autoResize;
        }

        public int Count => mCount;

        public void Enqueue(T item)
        {
            PushBack(item);
        }

        public void PushBack(T item)
        {
            if (mCount >= mArray.Length)
            {
                if (mAutoResize)
                    Resize();
                else
                    throw new InvalidOperationException("The queue is full.");
            }

            if (mCount > 0)
            {
                mTail++;
                if (mTail >= mArray.Length)
                {
                    mTail -= mArray.Length;
                }
            }

            int tail = mTail;
            mArray[tail] = item;
            mCount++;
        }

        public void PushFront(T item)
        {
            if (mCount >= mArray.Length)
            {
                if (mAutoResize)
                    Resize();
                else
                    throw new InvalidOperationException("The queue is full.");
            }

            if (mCount > 0)
            {
                mHead--;
                if (mHead < 0)
                {
                    mHead += mArray.Length;
                }
            }

            int head = mHead;
            mArray[head] = item;
            mCount++;
        }

        public T Dequeue()
        {
            return PopFront();
        }

        public T PopFront()
        {
            if (mCount <= 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            int head = mHead++;
            if (mHead >= mArray.Length)
            {
                mHead -= mArray.Length;
            }
            var item = mArray[head];
            mArray[head] = default(T); // Clear the reference to allow garbage collection
            mCount--;
            return item;
        }

        public T PopBack()
        {
            if (mCount <= 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            int tail = mTail--;
            if (mTail < 0)
            {
                mTail += mArray.Length;
            }
            var item = mArray[tail];
            mArray[tail] = default(T); // Clear the reference to allow garbage collection
            mCount--;
            return item;
        }

        public T PeekFront()
        {
            if (mCount <= 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }
            return mArray[mHead];
        }

        public T PeekBack()
        {
            if (mCount <= 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }
            return mArray[mTail];
        }

        public bool Remove(T item)
        {
            int length = mArray.Length;
            for (int i = 0; i < mCount; i++)
            {
                int index = mHead + i;
                if (index >= length)
                {
                    index -= length;
                }

                if (Equals(mArray[index], item))
                {
                    for (int j = i; j < mCount - 1; j++)
                    {
                        int index1 = mHead + j;
                        int index2 = index1 + 1;

                        if (index1 >= length)
                            index1 -= length;
                        if (index2 >= length)
                            index2 -= length;

                        mArray[index1] = mArray[index2];
                    }

                    mTail--;
                    if (mTail < 0)
                    {
                        mTail += mArray.Length;
                    }
                    mCount--;
                    return true;
                }
            }
            return false;
        }

        public bool Remove(Predicate<T> match, out T target)
        {
            int length = mArray.Length;
            for (int i = 0; i < mCount; i++)
            {
                int index = mHead + i;
                if (index >= length)
                {
                    index -= length;
                }

                if (match(mArray[index]))
                {
                    target = mArray[index];

                    for (int j = i; j < mCount - 1; j++)
                    {
                        int index1 = mHead + j;
                        int index2 = index1 + 1;

                        if (index1 >= length)
                            index1 -= length;
                        if (index2 >= length)
                            index2 -= length;

                        mArray[index1] = mArray[index2];
                    }

                    mTail--;
                    if (mTail < 0)
                    {
                        mTail += mArray.Length;
                    }
                    mCount--;
                    return true;
                }
            }

            target = default(T);
            return false;
        }

        public int RemoveAll(Predicate<T> match)
        {
            int rCount = 0;
            int length = mArray.Length;
            for (int i = 0; i < mCount; i++)
            {
                int index = mHead + i;
                if (index >= length)
                {
                    index -= length;
                }

                if (match(mArray[index]))
                {
                    for (int j = i; j < mCount - 1; j++)
                    {
                        int index1 = mHead + j;
                        int index2 = index1 + 1;

                        if (index1 >= length)
                            index1 -= length;
                        if (index2 >= length)
                            index2 -= length;

                        mArray[index1] = mArray[index2];
                    }

                    mTail--;
                    if (mTail < 0)
                    {
                        mTail += mArray.Length;
                    }
                    mCount--;
                    rCount++;
                }
            }
            return rCount;
        }

        private void Resize()
        {
            int length = mArray.Length;
            int newSize = length * 2;
            T[] newArray = new T[newSize];
            for (int i = 0; i < mCount; i++)
            {
                int index = mHead + i;
                if (index >= length)
                {
                    index -= length;
                }
                newArray[i] = mArray[index];
            }
            mArray = newArray;
            mHead = 0;
            mTail = mCount;
        }
    }
}
