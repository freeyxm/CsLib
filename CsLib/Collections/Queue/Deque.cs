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

            mArray[mTail] = item;
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

            mArray[mHead] = item;
            mCount++;
        }

        public T Dequeue()
        {
            return PopFront();
        }

        public T PopFront()
        {
            if (mCount == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            int head = mHead;
            if (mCount > 1)
            {
                mHead++;
                if (mHead >= mArray.Length)
                {
                    mHead -= mArray.Length;
                }
            }
            else
            {
                mHead = mTail = 0;
            }

            var item = mArray[head];
            mArray[head] = default(T); // Clear the reference to allow garbage collection
            mCount--;
            return item;
        }

        public T PopBack()
        {
            if (mCount == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            int tail = mTail;
            if (mCount > 1)
            {
                mTail--;
                if (mTail < 0)
                {
                    mTail += mArray.Length;
                }
            }
            else
            {
                mHead = mTail = 0;
            }

            var item = mArray[tail];
            mArray[tail] = default(T); // Clear the reference to allow garbage collection
            mCount--;
            return item;
        }

        public T Peek()
        {
            return PeekFront();
        }

        public T PeekFront()
        {
            if (mCount == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }
            return mArray[mHead];
        }

        public T PeekBack()
        {
            if (mCount == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }
            return mArray[mTail];
        }

        public bool Remove(T item)
        {
            if (mCount == 0)
            {
                return false;
            }

            if (mHead <= mTail)
            {
                for (int i = mHead; i <= mTail; i++)
                {
                    if (Equals(mArray[i], item))
                    {
                        if (i == mHead)
                        {
                            PopFront();
                            return true;
                        }

                        for (int j = i; j < mTail; j++)
                        {
                            mArray[j] = mArray[j + 1];
                        }

                        mArray[mTail] = default(T); // Clear the reference to allow garbage collection
                        mCount--;
                        if (mCount > 0)
                        {
                            mTail--;
                        }
                        else
                        {
                            mHead = mTail = 0;
                        }
                        return true;
                    }
                }
            }
            else
            {
                int length = mArray.Length;
                int count = mCount;
                for (int i = 0; i < count; i++)
                {
                    int index = mHead + i;
                    if (index >= length)
                    {
                        index -= length;
                    }

                    if (Equals(mArray[index], item))
                    {
                        if (index == mHead)
                        {
                            PopFront();
                            return true;
                        }

                        for (int j = i; j < count - 1; j++)
                        {
                            int index1 = mHead + j;
                            int index2 = index1 + 1;

                            if (index1 >= length)
                            {
                                index1 -= length;
                                index2 -= length;
                            }
                            else if (index2 >= length)
                            {
                                index2 -= length;
                            }

                            mArray[index1] = mArray[index2];
                        }

                        mArray[mTail] = default(T); // Clear the reference to allow garbage collection
                        mCount--;
                        if (mCount > 0)
                        {
                            mTail--;
                            if (mTail < 0)
                            {
                                mTail += mArray.Length;
                            }
                        }
                        else
                        {
                            mHead = mTail = 0;
                        }
                        return true;
                    }
                }
            }

            return false;
        }

        public bool Remove(Predicate<T> match, out T target)
        {
            if (mCount == 0)
            {
                target = default(T);
                return false;
            }

            if (mHead <= mTail)
            {
                for (int i = mHead; i <= mTail; i++)
                {
                    if (match(mArray[i]))
                    {
                        target = mArray[i];

                        if (i == mHead)
                        {
                            PopFront();
                            return true;
                        }

                        for (int j = i; j < mTail; j++)
                        {
                            mArray[j] = mArray[j + 1];
                        }

                        mArray[mTail] = default(T); // Clear the reference to allow garbage collection
                        mCount--;
                        if (mCount > 0)
                        {
                            mTail--;
                        }
                        else
                        {
                            mHead = mTail = 0;
                        }
                        return true;
                    }
                }
            }
            else
            {
                int length = mArray.Length;
                int count = mCount;
                for (int i = 0; i < count; i++)
                {
                    int index = mHead + i;
                    if (index >= length)
                    {
                        index -= length;
                    }

                    if (match(mArray[index]))
                    {
                        target = mArray[index];

                        if (index == mHead)
                        {
                            PopFront();
                            return true;
                        }

                        for (int j = i; j < count - 1; j++)
                        {
                            int index1 = mHead + j;
                            int index2 = index1 + 1;

                            if (index1 >= length)
                            {
                                index1 -= length;
                                index2 -= length;
                            }
                            else if (index2 >= length)
                            {
                                index2 -= length;
                            }

                            mArray[index1] = mArray[index2];
                        }

                        mArray[mTail] = default(T); // Clear the reference to allow garbage collection
                        mCount--;
                        if (mCount > 0)
                        {
                            mTail--;
                            if (mTail < 0)
                            {
                                mTail += mArray.Length;
                            }
                        }
                        else
                        {
                            mHead = mTail = 0;
                        }
                        return true;
                    }
                }
            }

            target = default(T);
            return false;
        }

        public int RemoveAll(Predicate<T> match, Action<T> onRemove = null)
        {
            if (mCount == 0)
            {
                return 0;
            }

            int rCount = 0;
            if (mHead <= mTail)
            {
                for (int i = mTail; i >= mHead; i--)
                {
                    var target = mArray[i];
                    if (match(target))
                    {
                        if (i == mHead)
                        {
                            PopFront();
                            rCount++;
                            onRemove?.Invoke(target);
                            break;
                        }

                        for (int j = i; j < mTail; j++)
                        {
                            mArray[j] = mArray[j + 1];
                        }

                        mArray[mTail] = default(T); // Clear the reference to allow garbage collection
                        rCount++;
                        mCount--;
                        if (mCount > 0)
                        {
                            mTail--;
                        }
                        else
                        {
                            mHead = mTail = 0;
                        }

                        onRemove?.Invoke(target);
                    }
                }
            }
            else
            {
                int length = mArray.Length;
                int count = mCount;
                int tail = mTail;
                for (int i = 0; i < count; i++)
                {
                    int index = tail - i;
                    if (index < 0)
                    {
                        index += length;
                    }

                    var target = mArray[index];
                    if (match(target))
                    {
                        if (index == mHead)
                        {
                            PopFront();
                            rCount++;
                            onRemove?.Invoke(target);
                            break;
                        }

                        for (int j = i; j > 0; j--)
                        {
                            int index1 = tail - j;
                            int index2 = index1 + 1;

                            if (index2 < 0)
                            {
                                index2 += length;
                                index1 += length;
                            }
                            else if (index1 < 0)
                            {
                                index1 += length;
                            }

                            mArray[index1] = mArray[index2];
                        }

                        mArray[mTail] = default(T); // Clear the reference to allow garbage collection
                        rCount++;
                        mCount--;
                        if (mCount > 0)
                        {
                            mTail--;
                            if (mTail < 0)
                            {
                                mTail += mArray.Length;
                            }
                        }
                        else
                        {
                            mHead = mTail = 0;
                        }

                        onRemove?.Invoke(target);
                    }
                }
            }

            return rCount;
        }

        public bool Find(Predicate<T> match, out T target)
        {
            if (mCount == 0)
            {
                target = default(T);
                return false;
            }

            if (mHead <= mTail)
            {
                for (int i = mHead; i <= mTail; i++)
                {
                    if (match(mArray[i]))
                    {
                        target = mArray[i];
                        return true;
                    }
                }
            }
            else
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
                        return true;
                    }
                }
            }

            target = default(T);
            return false;
        }

        public bool Exists(T item)
        {
            if (mCount == 0)
            {
                return false;
            }

            if (mHead <= mTail)
            {
                for (int i = mHead; i <= mTail; i++)
                {
                    if (Equals(mArray[i], item))
                    {
                        return true;
                    }
                }
            }
            else
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
                        return true;
                    }
                }
            }

            return false;
        }

        public void Clear()
        {
            if (mArray != null)
            {
                for (int i = 0; i < mArray.Length; i++)
                {
                    mArray[i] = default(T); // Clear the reference to allow garbage collection
                }
            }
            mHead = mTail = 0;
            mCount = 0;
        }

        private bool Equals(T x, T y)
        {
            return object.Equals(x, y);
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
            mTail = mCount - 1;
        }
    }
}
