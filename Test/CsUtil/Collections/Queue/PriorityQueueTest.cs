using CsLib.Collections;
using System;
using System.Collections.Generic;

namespace Test
{
    class PriorityQueueTest
    {
        private class DownInfo
        {
            public int Id = 0;

            public override string ToString()
            {
                return Id.ToString();
            }
        }

        private DownInfo NewDownInfo(int id)
        {
            return new DownInfo() { Id = id };
        }

        public void SetUp()
        {
        }

        public void Test1A()
        {
            var queue = new PriorityQueue<DownInfo>();
            queue.Enqueue(10, NewDownInfo(1));
            queue.Enqueue(20, NewDownInfo(2));
            queue.Enqueue(30, NewDownInfo(3));
            queue.Enqueue(40, NewDownInfo(4));
            queue.Enqueue(50, NewDownInfo(5));
            Assert.AreEqual(1, queue.Dequeue().Id);
            Assert.AreEqual(2, queue.Dequeue().Id);
            Assert.AreEqual(3, queue.Dequeue().Id);
            Assert.AreEqual(4, queue.Dequeue().Id);
            Assert.AreEqual(5, queue.Dequeue().Id);
        }

        public void Test1B()
        {
            var queue = new PriorityQueue<DownInfo>();
            queue.Enqueue(50, NewDownInfo(1));
            queue.Enqueue(40, NewDownInfo(2));
            queue.Enqueue(30, NewDownInfo(3));
            queue.Enqueue(20, NewDownInfo(4));
            queue.Enqueue(10, NewDownInfo(5));
            Assert.AreEqual(5, queue.Dequeue().Id);
            Assert.AreEqual(4, queue.Dequeue().Id);
            Assert.AreEqual(3, queue.Dequeue().Id);
            Assert.AreEqual(2, queue.Dequeue().Id);
            Assert.AreEqual(1, queue.Dequeue().Id);
        }

        public void Test1C()
        {
            var queue = new PriorityQueue<DownInfo>();
            queue.Enqueue(30, NewDownInfo(1));
            queue.Enqueue(20, NewDownInfo(2));
            queue.Enqueue(10, NewDownInfo(3));
            queue.Enqueue(50, NewDownInfo(4));
            queue.Enqueue(40, NewDownInfo(5));
            Assert.AreEqual(3, queue.Dequeue().Id);
            Assert.AreEqual(2, queue.Dequeue().Id);
            Assert.AreEqual(1, queue.Dequeue().Id);
            Assert.AreEqual(5, queue.Dequeue().Id);
            Assert.AreEqual(4, queue.Dequeue().Id);
        }

        public void Test1D()
        {
            var queue = new PriorityQueue<DownInfo>();
            queue.Enqueue(10, NewDownInfo(1));
            queue.Enqueue(20, NewDownInfo(2));
            queue.Enqueue(20, NewDownInfo(3));
            queue.Enqueue(10, NewDownInfo(4));
            queue.Enqueue(20, NewDownInfo(5));

            Assert.AreEqual(5, queue.Count);
            Assert.AreEqual(2, queue.GetCount(10));
            Assert.AreEqual(3, queue.GetCount(20));

            Assert.AreEqual(1, queue.Dequeue().Id);
            Assert.AreEqual(4, queue.Dequeue().Id);
            Assert.AreEqual(2, queue.Dequeue().Id);
            Assert.AreEqual(3, queue.Dequeue().Id);
            Assert.AreEqual(5, queue.Dequeue().Id);

            Assert.AreEqual(0, queue.Count);
            Assert.AreEqual(0, queue.GetCount(10));
            Assert.AreEqual(0, queue.GetCount(20));
            Assert.Catch<InvalidOperationException>(() => queue.Dequeue());
        }

        public void Test2A()
        {
            var queue = new PriorityQueue<DownInfo>();
            queue.Enqueue(30, NewDownInfo(1));
            Assert.AreEqual(1, queue.Peek().Id);
            queue.Enqueue(20, NewDownInfo(2));
            Assert.AreEqual(2, queue.Peek().Id);
            queue.Enqueue(10, NewDownInfo(3));
            Assert.AreEqual(3, queue.Peek().Id);
            queue.Enqueue(50, NewDownInfo(4));
            Assert.AreEqual(3, queue.Peek().Id);
            queue.Enqueue(40, NewDownInfo(5));
            Assert.AreEqual(3, queue.Peek().Id);

            queue.Dequeue();
            Assert.AreEqual(2, queue.Peek().Id);
            queue.Dequeue();
            Assert.AreEqual(1, queue.Peek().Id);
            queue.Dequeue();
            Assert.AreEqual(5, queue.Peek().Id);
            queue.Dequeue();
            Assert.AreEqual(4, queue.Peek().Id);
            queue.Dequeue();
            Assert.AreEqual(0, queue.Count);
        }

        public void Test3A()
        {
            var queue = new PriorityQueue<DownInfo>();
            queue.PushBack(10, NewDownInfo(1));
            queue.PushBack(20, NewDownInfo(2));
            queue.PushBack(30, NewDownInfo(3));
            queue.PushBack(30, NewDownInfo(4));
            queue.PushBack(20, NewDownInfo(5));
            queue.PushBack(10, NewDownInfo(6));
            queue.PushBack(10, NewDownInfo(7));
            queue.PushBack(20, NewDownInfo(8));
            queue.PushBack(30, NewDownInfo(9));

            Assert.AreEqual(9, queue.Count);
            Assert.AreEqual(3, queue.GetCount(10));
            Assert.AreEqual(3, queue.GetCount(20));
            Assert.AreEqual(3, queue.GetCount(30));

            Assert.AreEqual(1, queue.Dequeue().Id);
            Assert.AreEqual(6, queue.Dequeue().Id);
            Assert.AreEqual(7, queue.Dequeue().Id);
            Assert.AreEqual(0, queue.GetCount(10));
            Assert.AreEqual(3, queue.GetCount(20));
            Assert.AreEqual(3, queue.GetCount(30));
            Assert.AreEqual(6, queue.Count);

            Assert.AreEqual(2, queue.PopFront(20).Id);
            Assert.AreEqual(5, queue.PopFront(20).Id);
            Assert.AreEqual(8, queue.PopFront(20).Id);
            Assert.AreEqual(0, queue.GetCount(20));
            Assert.AreEqual(3, queue.GetCount(30));
            Assert.AreEqual(3, queue.Count);

            Assert.AreEqual(9, queue.PopBack(30).Id);
            Assert.AreEqual(4, queue.PopBack(30).Id);
            Assert.AreEqual(3, queue.PopBack(30).Id);
            Assert.AreEqual(0, queue.GetCount(30));
            Assert.AreEqual(0, queue.Count);
        }

        public void Test3B()
        {
            var queue = new PriorityQueue<DownInfo>();
            queue.PushFront(10, NewDownInfo(1));
            queue.PushFront(20, NewDownInfo(2));
            queue.PushFront(30, NewDownInfo(3));
            queue.PushFront(30, NewDownInfo(4));
            queue.PushFront(20, NewDownInfo(5));
            queue.PushFront(10, NewDownInfo(6));
            queue.PushFront(10, NewDownInfo(7));
            queue.PushFront(20, NewDownInfo(8));
            queue.PushFront(30, NewDownInfo(9));

            Assert.AreEqual(9, queue.Count);
            Assert.AreEqual(3, queue.GetCount(10));
            Assert.AreEqual(3, queue.GetCount(20));
            Assert.AreEqual(3, queue.GetCount(30));

            Assert.AreEqual(7, queue.Dequeue().Id);
            Assert.AreEqual(6, queue.Dequeue().Id);
            Assert.AreEqual(1, queue.Dequeue().Id);
            Assert.AreEqual(0, queue.GetCount(10));
            Assert.AreEqual(3, queue.GetCount(20));
            Assert.AreEqual(3, queue.GetCount(30));
            Assert.AreEqual(6, queue.Count);

            Assert.AreEqual(8, queue.PopFront(20).Id);
            Assert.AreEqual(5, queue.PopFront(20).Id);
            Assert.AreEqual(2, queue.PopFront(20).Id);
            Assert.AreEqual(0, queue.GetCount(20));
            Assert.AreEqual(3, queue.GetCount(30));
            Assert.AreEqual(3, queue.Count);

            Assert.AreEqual(3, queue.PopBack(30).Id);
            Assert.AreEqual(4, queue.PopBack(30).Id);
            Assert.AreEqual(9, queue.PopBack(30).Id);
            Assert.AreEqual(0, queue.GetCount(30));
            Assert.AreEqual(0, queue.Count);
        }

        public void Test3C()
        {
            var queue = new PriorityQueue<DownInfo>();
            queue.PushFront(10, NewDownInfo(1));
            queue.PushFront(20, NewDownInfo(2));

            queue.PushBack(20, NewDownInfo(3));
            queue.PushBack(10, NewDownInfo(4));

            queue.PushFront(10, NewDownInfo(5));
            queue.PushFront(20, NewDownInfo(6));

            queue.PushBack(20, NewDownInfo(7));
            queue.PushBack(10, NewDownInfo(8));

            // 10: 5 1 4 8
            // 20: 6 2 3 7

            Assert.AreEqual(8, queue.Count);
            Assert.AreEqual(4, queue.GetCount(10));
            Assert.AreEqual(4, queue.GetCount(20));

            Assert.AreEqual(5, queue.PopFront(10).Id);
            Assert.AreEqual(7, queue.Count);
            Assert.AreEqual(3, queue.GetCount(10));
            Assert.AreEqual(4, queue.GetCount(20));

            Assert.AreEqual(1, queue.PopFront(10).Id);
            Assert.AreEqual(6, queue.Count);
            Assert.AreEqual(2, queue.GetCount(10));
            Assert.AreEqual(4, queue.GetCount(20));

            Assert.AreEqual(4, queue.PopFront(10).Id);
            Assert.AreEqual(5, queue.Count);
            Assert.AreEqual(1, queue.GetCount(10));
            Assert.AreEqual(4, queue.GetCount(20));

            Assert.AreEqual(8, queue.PopFront(10).Id);
            Assert.AreEqual(4, queue.Count);
            Assert.AreEqual(0, queue.GetCount(10));
            Assert.AreEqual(4, queue.GetCount(20));

            Assert.AreEqual(7, queue.PopBack(20).Id);
            Assert.AreEqual(3, queue.Count);
            Assert.AreEqual(0, queue.GetCount(10));
            Assert.AreEqual(3, queue.GetCount(20));

            Assert.AreEqual(3, queue.PopBack(20).Id);
            Assert.AreEqual(2, queue.Count);
            Assert.AreEqual(0, queue.GetCount(10));
            Assert.AreEqual(2, queue.GetCount(20));

            Assert.AreEqual(2, queue.PopBack(20).Id);
            Assert.AreEqual(1, queue.Count);
            Assert.AreEqual(0, queue.GetCount(10));
            Assert.AreEqual(1, queue.GetCount(20));

            Assert.AreEqual(6, queue.PopBack(20).Id);
            Assert.AreEqual(0, queue.Count);
            Assert.AreEqual(0, queue.GetCount(10));
            Assert.AreEqual(0, queue.GetCount(20));
        }

        public void Test4A()
        {
            var queue1 = new PriorityQueue<DownInfo>();
            queue1.PushBack(10, NewDownInfo(1));
            queue1.PushBack(20, NewDownInfo(2));
            queue1.PushBack(20, NewDownInfo(3));
            queue1.PushBack(10, NewDownInfo(4));
            queue1.PushBack(10, NewDownInfo(5));
            queue1.PushBack(20, NewDownInfo(6));

            var queue2 = new PriorityQueue<DownInfo>();
            queue1.MoveToBack(queue2);

            Assert.AreEqual(6, queue2.Count);
            Assert.AreEqual(3, queue2.GetCount(10));
            Assert.AreEqual(3, queue2.GetCount(20));

            Assert.AreEqual(1, queue2.PopFront(10).Id);
            Assert.AreEqual(4, queue2.PopFront(10).Id);
            Assert.AreEqual(5, queue2.PopFront(10).Id);

            Assert.AreEqual(6, queue2.PopBack(20).Id);
            Assert.AreEqual(3, queue2.PopBack(20).Id);
            Assert.AreEqual(2, queue2.PopBack(20).Id);
        }

        public void Test4B()
        {
            var queue1 = new PriorityQueue<DownInfo>();
            queue1.PushBack(10, NewDownInfo(1));
            queue1.PushBack(20, NewDownInfo(2));
            queue1.PushBack(20, NewDownInfo(3));
            queue1.PushBack(10, NewDownInfo(4));
            queue1.PushBack(10, NewDownInfo(5));
            queue1.PushBack(20, NewDownInfo(6));

            var queue2 = new PriorityQueue<DownInfo>();
            queue1.MoveToBack(10, queue2);

            Assert.AreEqual(3, queue2.Count);
            Assert.AreEqual(3, queue2.GetCount(10));
            Assert.AreEqual(0, queue2.GetCount(20));

            Assert.AreEqual(1, queue2.PopFront(10).Id);
            Assert.AreEqual(4, queue2.PopFront(10).Id);
            Assert.AreEqual(5, queue2.PopFront(10).Id);
        }

        public void Test4C()
        {
            var queue1 = new PriorityQueue<DownInfo>();
            queue1.PushBack(10, NewDownInfo(1));
            queue1.PushBack(20, NewDownInfo(2));
            queue1.PushBack(20, NewDownInfo(3));
            queue1.PushBack(10, NewDownInfo(4));
            queue1.PushBack(10, NewDownInfo(5));
            queue1.PushBack(20, NewDownInfo(6));

            var queue2 = new PriorityQueue<DownInfo>();
            queue1.MoveToBack((a) => a.Id % 2 == 0, queue2);
            Assert.AreEqual(3, queue2.Count);
            Assert.AreEqual(1, queue2.GetCount(10));
            Assert.AreEqual(2, queue2.GetCount(20));

            Assert.AreEqual(4, queue2.PopFront(10).Id);
            Assert.AreEqual(0, queue2.GetCount(10));
            Assert.AreEqual(2, queue2.GetCount(20));
            Assert.AreEqual(2, queue2.Count);

            Assert.AreEqual(2, queue2.PopFront(20).Id);
            Assert.AreEqual(6, queue2.PopFront(20).Id);
            Assert.AreEqual(0, queue2.GetCount(20));
            Assert.AreEqual(0, queue2.Count);
        }

        public void Test5A()
        {
            var queue = new PriorityQueue<DownInfo>();
            var info1 = NewDownInfo(1);
            var info2 = NewDownInfo(2);
            var info3 = NewDownInfo(3);
            var info4 = NewDownInfo(4);
            var info5 = NewDownInfo(5);
            var info6 = NewDownInfo(6);

            queue.Enqueue(10, info1);
            queue.Enqueue(20, info2);
            queue.Enqueue(20, info3);
            queue.Enqueue(10, info4);
            queue.Enqueue(20, info5);

            Assert.AreEqual(false, queue.Remove(info6));
            Assert.AreEqual(5, queue.Count);
            Assert.AreEqual(2, queue.GetCount(10));
            Assert.AreEqual(3, queue.GetCount(20));

            Assert.AreEqual(true, queue.Remove(info1));
            Assert.AreEqual(4, queue.Count);
            Assert.AreEqual(1, queue.GetCount(10));
            Assert.AreEqual(3, queue.GetCount(20));

            Assert.AreEqual(true, queue.Remove(info2));
            Assert.AreEqual(3, queue.Count);
            Assert.AreEqual(1, queue.GetCount(10));
            Assert.AreEqual(2, queue.GetCount(20));

            Assert.AreEqual(true, queue.Remove(info3));
            Assert.AreEqual(2, queue.Count);
            Assert.AreEqual(1, queue.GetCount(10));
            Assert.AreEqual(1, queue.GetCount(20));

            Assert.AreEqual(true, queue.Remove(info4));
            Assert.AreEqual(1, queue.Count);
            Assert.AreEqual(0, queue.GetCount(10));
            Assert.AreEqual(1, queue.GetCount(20));

            Assert.AreEqual(true, queue.Remove(info5));
            Assert.AreEqual(0, queue.Count);
            Assert.AreEqual(0, queue.GetCount(10));
            Assert.AreEqual(0, queue.GetCount(20));
        }

        public void Test5B()
        {
            var queue = new PriorityQueue<DownInfo>();
            var info1 = NewDownInfo(1);
            var info2 = NewDownInfo(2);
            var info3 = NewDownInfo(3);
            var info4 = NewDownInfo(4);
            var info5 = NewDownInfo(5);
            var info6 = NewDownInfo(6);

            queue.Enqueue(10, info1);
            queue.Enqueue(20, info2);
            queue.Enqueue(20, info3);
            queue.Enqueue(10, info4);
            queue.Enqueue(20, info5);

            Assert.AreEqual(false, queue.Remove(10, info6));
            Assert.AreEqual(false, queue.Remove(20, info6));
            Assert.AreEqual(5, queue.Count);
            Assert.AreEqual(2, queue.GetCount(10));
            Assert.AreEqual(3, queue.GetCount(20));

            Assert.AreEqual(true, queue.Remove(10, info1));
            Assert.AreEqual(false, queue.Remove(20, info1));
            Assert.AreEqual(4, queue.Count);
            Assert.AreEqual(1, queue.GetCount(10));
            Assert.AreEqual(3, queue.GetCount(20));

            Assert.AreEqual(false, queue.Remove(10, info2));
            Assert.AreEqual(true, queue.Remove(20, info2));
            Assert.AreEqual(3, queue.Count);
            Assert.AreEqual(1, queue.GetCount(10));
            Assert.AreEqual(2, queue.GetCount(20));

            Assert.AreEqual(false, queue.Remove(10, info3));
            Assert.AreEqual(true, queue.Remove(20, info3));
            Assert.AreEqual(2, queue.Count);
            Assert.AreEqual(1, queue.GetCount(10));
            Assert.AreEqual(1, queue.GetCount(20));

            Assert.AreEqual(true, queue.Remove(10, info4));
            Assert.AreEqual(false, queue.Remove(20, info4));
            Assert.AreEqual(1, queue.Count);
            Assert.AreEqual(0, queue.GetCount(10));
            Assert.AreEqual(1, queue.GetCount(20));

            Assert.AreEqual(false, queue.Remove(10, info5));
            Assert.AreEqual(true, queue.Remove(20, info5));
            Assert.AreEqual(0, queue.Count);
            Assert.AreEqual(0, queue.GetCount(10));
            Assert.AreEqual(0, queue.GetCount(20));
        }

        public void Test5C()
        {
            DownInfo target;
            var queue = new PriorityQueue<DownInfo>();
            queue.Enqueue(10, NewDownInfo(1));
            queue.Enqueue(20, NewDownInfo(2));
            queue.Enqueue(20, NewDownInfo(3));
            queue.Enqueue(10, NewDownInfo(4));
            queue.Enqueue(20, NewDownInfo(5));

            Assert.AreEqual(false, queue.Remove((a) => a.Id == 6, out target));
            Assert.AreEqual(target, null);
            Assert.AreEqual(5, queue.Count);
            Assert.AreEqual(2, queue.GetCount(10));
            Assert.AreEqual(3, queue.GetCount(20));

            Assert.AreEqual(true, queue.Remove((a) => a.Id == 1, out target));
            Assert.AreEqual(1, target.Id);
            Assert.AreEqual(4, queue.Count);
            Assert.AreEqual(1, queue.GetCount(10));
            Assert.AreEqual(3, queue.GetCount(20));

            Assert.AreEqual(true, queue.Remove((a) => a.Id == 2, out target));
            Assert.AreEqual(2, target.Id);
            Assert.AreEqual(3, queue.Count);
            Assert.AreEqual(1, queue.GetCount(10));
            Assert.AreEqual(2, queue.GetCount(20));

            Assert.AreEqual(true, queue.Remove((a) => a.Id == 3, out target));
            Assert.AreEqual(3, target.Id);
            Assert.AreEqual(2, queue.Count);
            Assert.AreEqual(1, queue.GetCount(10));
            Assert.AreEqual(1, queue.GetCount(20));

            Assert.AreEqual(true, queue.Remove((a) => a.Id == 4, out target));
            Assert.AreEqual(4, target.Id);
            Assert.AreEqual(1, queue.Count);
            Assert.AreEqual(0, queue.GetCount(10));
            Assert.AreEqual(1, queue.GetCount(20));

            Assert.AreEqual(true, queue.Remove((a) => a.Id == 5, out target));
            Assert.AreEqual(5, target.Id);
            Assert.AreEqual(0, queue.Count);
            Assert.AreEqual(0, queue.GetCount(10));
            Assert.AreEqual(0, queue.GetCount(20));
        }

        public void Test5D()
        {
            var queue = new PriorityQueue<DownInfo>();
            queue.Enqueue(10, NewDownInfo(1));
            queue.Enqueue(20, NewDownInfo(2));
            queue.Enqueue(20, NewDownInfo(3));
            queue.Enqueue(10, NewDownInfo(4));
            queue.Enqueue(20, NewDownInfo(5));

            queue.RemoveAll((a) => a.Id == 6, (t) => { Assert.Fail(); });
            Assert.AreEqual(5, queue.Count);
            Assert.AreEqual(2, queue.GetCount(10));
            Assert.AreEqual(3, queue.GetCount(20));

            queue.RemoveAll((a) => a.Id == 1, (t) => { Assert.AreEqual(1, t.Id); });
            Assert.AreEqual(4, queue.Count);
            Assert.AreEqual(1, queue.GetCount(10));
            Assert.AreEqual(3, queue.GetCount(20));

            queue.RemoveAll((a) => a.Id == 2, (t) => { Assert.AreEqual(2, t.Id); });
            Assert.AreEqual(3, queue.Count);
            Assert.AreEqual(1, queue.GetCount(10));
            Assert.AreEqual(2, queue.GetCount(20));

            queue.RemoveAll((a) => a.Id == 3 || a.Id == 4, (t) =>
            {
                if (t.Id != 3 && t.Id != 4)
                {
                    Assert.Fail();
                }
            });
            Assert.AreEqual(1, queue.Count);
            Assert.AreEqual(0, queue.GetCount(10));
            Assert.AreEqual(1, queue.GetCount(20));

            queue.RemoveAll((a) => a.Id == 5, (t) => { Assert.AreEqual(5, t.Id); });
            Assert.AreEqual(0, queue.Count);
            Assert.AreEqual(0, queue.GetCount(10));
            Assert.AreEqual(0, queue.GetCount(20));
        }

        public void Test5E()
        {
            var queue = new PriorityQueue<DownInfo>();
            queue.Enqueue(10, NewDownInfo(1));
            queue.Enqueue(20, NewDownInfo(2));
            queue.Enqueue(20, NewDownInfo(3));
            queue.Enqueue(10, NewDownInfo(4));
            queue.Enqueue(20, NewDownInfo(5));

            Assert.AreEqual(5, queue.Count);
            Assert.AreEqual(2, queue.GetCount(10));
            Assert.AreEqual(3, queue.GetCount(20));

            Queue<int> removeQueue = new Queue<int>();
            queue.RemoveAll((t) =>
            {
                removeQueue.Enqueue(t.Id);
            });
            Assert.AreEqual(5, removeQueue.Count);
            Assert.AreEqual(1, removeQueue.Dequeue());
            Assert.AreEqual(4, removeQueue.Dequeue());
            Assert.AreEqual(2, removeQueue.Dequeue());
            Assert.AreEqual(3, removeQueue.Dequeue());
            Assert.AreEqual(5, removeQueue.Dequeue());
            Assert.AreEqual(0, queue.Count);
            Assert.AreEqual(0, queue.GetCount(10));
            Assert.AreEqual(0, queue.GetCount(20));
        }

        public void Test6A()
        {
            DownInfo target;
            var queue = new PriorityQueue<DownInfo>();
            queue.Enqueue(10, NewDownInfo(1));
            queue.Enqueue(20, NewDownInfo(2));
            queue.Enqueue(20, NewDownInfo(3));
            queue.Enqueue(10, NewDownInfo(4));
            queue.Enqueue(20, NewDownInfo(5));

            Assert.AreEqual(false, queue.Find((a) => a.Id == 6, out target));
            Assert.AreEqual(target, null);

            Assert.AreEqual(true, queue.Find((a) => a.Id == 1, out target));
            Assert.AreEqual(1, target.Id);

            Assert.AreEqual(true, queue.Find((a) => a.Id == 2, out target));
            Assert.AreEqual(2, target.Id);

            Assert.AreEqual(true, queue.Find((a) => a.Id == 3, out target));
            Assert.AreEqual(3, target.Id);

            Assert.AreEqual(true, queue.Find((a) => a.Id == 4, out target));
            Assert.AreEqual(4, target.Id);

            Assert.AreEqual(true, queue.Find((a) => a.Id == 5, out target));
            Assert.AreEqual(5, target.Id);
        }

        public void Test6B()
        {
            var queue = new PriorityQueue<DownInfo>();
            queue.Enqueue(10, NewDownInfo(1));
            queue.Enqueue(20, NewDownInfo(2));
            queue.Enqueue(20, NewDownInfo(3));
            queue.Enqueue(10, NewDownInfo(4));
            queue.Enqueue(20, NewDownInfo(5));

            List<DownInfo> result = new List<DownInfo>();

            result.Clear();
            queue.FindAll((a) => a.Id == 6, ref result);
            Assert.AreEqual(0, result.Count);

            result.Clear();
            queue.FindAll((a) => a.Id % 2 == 1, ref result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(1, result[0].Id);
            Assert.AreEqual(3, result[1].Id);
            Assert.AreEqual(5, result[2].Id);

            result.Clear();
            queue.FindAll((a) => a.Id % 2 == 0, ref result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(4, result[0].Id);
            Assert.AreEqual(2, result[1].Id);

            result.Clear();
            queue.FindAll((a) => true, ref result);
            Assert.AreEqual(5, result.Count);
            Assert.AreEqual(1, result[0].Id);
            Assert.AreEqual(4, result[1].Id);
            Assert.AreEqual(2, result[2].Id);
            Assert.AreEqual(3, result[3].Id);
            Assert.AreEqual(5, result[4].Id);
        }

        public void TestClear()
        {
            var queue = new PriorityQueue<DownInfo>();
            queue.Enqueue(1, NewDownInfo(1));
            queue.Enqueue(2, NewDownInfo(2));
            queue.Enqueue(3, NewDownInfo(3));
            queue.Enqueue(4, NewDownInfo(4));
            queue.Enqueue(5, NewDownInfo(5));
            Assert.AreEqual(5, queue.Count);
            queue.Clear();
            Assert.AreEqual(0, queue.Count);
        }
    }
}
