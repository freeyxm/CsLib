﻿using System;
using System.Collections.Generic;

namespace CsLib.Common
{
    class ObjectPool<T> where T : new()
    {
        protected Queue<T> m_cacheQueue;

        public ObjectPool(int capacity)
        {
            m_cacheQueue = new Queue<T>(capacity);
            for (int i = 0; i < capacity; ++i)
            {
                m_cacheQueue.Enqueue(NewNode());
            }
        }

        public virtual T AllocNode()
        {
            if (m_cacheQueue.Count > 0)
                return m_cacheQueue.Dequeue();
            else
                return NewNode();
        }

        public virtual void FreeNode(T obj)
        {
            m_cacheQueue.Enqueue(obj);
        }

        protected virtual T NewNode()
        {
            return new T();
        }

        public int Count { get { return m_cacheQueue.Count; } }
    }
}
