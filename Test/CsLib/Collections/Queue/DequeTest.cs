using CsLib.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Test
{
    class DequeTest
    {
        private class DownInfo
        {
            public int Id = 0;

            public override string ToString()
            {
                return Id.ToString();
            }
        }

        private struct StDownInfo
        {
            public int Id;

            public override string ToString()
            {
                return Id.ToString();
            }
        }

        public void SetUp()
        {
        }

        public void TestClear()
        {
            var dueue = new Deque<DownInfo>(2, true);
            dueue.Enqueue(NewDownInfo(1));
            dueue.Enqueue(NewDownInfo(2));
            dueue.Enqueue(NewDownInfo(3));
            dueue.Enqueue(NewDownInfo(4));
            dueue.Enqueue(NewDownInfo(5));
            dueue.Clear();
            Assert.AreEqual(0, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(0, dueue.Tail);
        }

        public void Test2A()
        {
            var dueue = new Deque<DownInfo>(2, true);

            dueue.Enqueue(NewDownInfo(1));
            Assert.AreEqual(1, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(0, dueue.Tail);

            Assert.AreEqual(1, dueue.Dequeue().Id);
            Assert.AreEqual(0, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(0, dueue.Tail);
        }

        public void Test2B()
        {
            var dueue = new Deque<DownInfo>(2, true);

            dueue.Enqueue(NewDownInfo(1));
            Assert.AreEqual(1, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(0, dueue.Tail);

            dueue.Enqueue(NewDownInfo(2));
            Assert.AreEqual(2, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(1, dueue.Tail);

            Assert.AreEqual(1, dueue.Dequeue().Id);
            Assert.AreEqual(1, dueue.Count);
            Assert.AreEqual(1, dueue.Head);
            Assert.AreEqual(1, dueue.Tail);

            Assert.AreEqual(2, dueue.Dequeue().Id);
            Assert.AreEqual(0, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(0, dueue.Tail);
        }

        public void Test2C()
        {
            var dueue = new Deque<DownInfo>(2, true);

            dueue.Enqueue(NewDownInfo(1));
            dueue.Enqueue(NewDownInfo(2));
            Assert.AreEqual(2, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(1, dueue.Tail);

            Assert.AreEqual(1, dueue.Dequeue().Id);
            Assert.AreEqual(1, dueue.Count);
            Assert.AreEqual(1, dueue.Head);
            Assert.AreEqual(1, dueue.Tail);

            dueue.Enqueue(NewDownInfo(3));
            Assert.AreEqual(2, dueue.Count);
            Assert.AreEqual(1, dueue.Head);
            Assert.AreEqual(0, dueue.Tail);

            Assert.AreEqual(2, dueue.Dequeue().Id);
            Assert.AreEqual(1, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(0, dueue.Tail);

            dueue.Enqueue(NewDownInfo(4));
            Assert.AreEqual(2, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(1, dueue.Tail);

            Assert.AreEqual(3, dueue.Dequeue().Id);
            Assert.AreEqual(1, dueue.Count);
            Assert.AreEqual(1, dueue.Head);
            Assert.AreEqual(1, dueue.Tail);

            Assert.AreEqual(4, dueue.Dequeue().Id);
            Assert.AreEqual(0, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(0, dueue.Tail);
        }

        public void Test2D()
        {
            var dueue = new Deque<DownInfo>(2, true);

            dueue.PushFront(NewDownInfo(1));
            Assert.AreEqual(1, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(0, dueue.Tail);

            dueue.PushFront(NewDownInfo(2));
            Assert.AreEqual(2, dueue.Count);
            Assert.AreEqual(1, dueue.Head);
            Assert.AreEqual(0, dueue.Tail);

            Assert.AreEqual(1, dueue.PopBack().Id);
            Assert.AreEqual(1, dueue.Count);
            Assert.AreEqual(1, dueue.Head);
            Assert.AreEqual(1, dueue.Tail);

            dueue.PushFront(NewDownInfo(3));
            Assert.AreEqual(2, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(1, dueue.Tail);

            Assert.AreEqual(2, dueue.PopBack().Id);
            Assert.AreEqual(1, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(0, dueue.Tail);

            dueue.PushFront(NewDownInfo(4));
            Assert.AreEqual(2, dueue.Count);
            Assert.AreEqual(1, dueue.Head);
            Assert.AreEqual(0, dueue.Tail);

            Assert.AreEqual(3, dueue.PopBack().Id);
            Assert.AreEqual(1, dueue.Count);
            Assert.AreEqual(1, dueue.Head);
            Assert.AreEqual(1, dueue.Tail);

            Assert.AreEqual(4, dueue.PopBack().Id);
            Assert.AreEqual(0, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(0, dueue.Tail);
        }

        public void Test3A()
        {
            var dueue = new Deque<DownInfo>(2, true);

            dueue.Enqueue(NewDownInfo(1));
            Assert.AreEqual(1, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(0, dueue.Tail);

            dueue.Enqueue(NewDownInfo(2));
            Assert.AreEqual(2, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(1, dueue.Tail);

            dueue.Enqueue(NewDownInfo(3));
            Assert.AreEqual(3, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(2, dueue.Tail);

            Assert.AreEqual(1, dueue.Dequeue().Id);
            Assert.AreEqual(2, dueue.Count);
            Assert.AreEqual(1, dueue.Head);
            Assert.AreEqual(2, dueue.Tail);

            Assert.AreEqual(2, dueue.Dequeue().Id);
            Assert.AreEqual(1, dueue.Count);
            Assert.AreEqual(2, dueue.Head);
            Assert.AreEqual(2, dueue.Tail);

            Assert.AreEqual(3, dueue.Dequeue().Id);
            Assert.AreEqual(0, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(0, dueue.Tail);
        }

        public void Test3B()
        {
            var dueue = new Deque<DownInfo>(2, true);

            dueue.Enqueue(NewDownInfo(1));
            dueue.Enqueue(NewDownInfo(2));
            dueue.Enqueue(NewDownInfo(3));
            Assert.AreEqual(3, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(2, dueue.Tail);

            Assert.AreEqual(1, dueue.Dequeue().Id);
            Assert.AreEqual(2, dueue.Dequeue().Id);
            Assert.AreEqual(1, dueue.Count);
            Assert.AreEqual(2, dueue.Head);
            Assert.AreEqual(2, dueue.Tail);

            dueue.Enqueue(NewDownInfo(4));
            dueue.Enqueue(NewDownInfo(5));
            dueue.Enqueue(NewDownInfo(6));
            Assert.AreEqual(4, dueue.Count);
            Assert.AreEqual(2, dueue.Head);
            Assert.AreEqual(1, dueue.Tail);

            dueue.Enqueue(NewDownInfo(7));
            Assert.AreEqual(5, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(4, dueue.Tail);

            Assert.AreEqual(3, dueue.Dequeue().Id);
            Assert.AreEqual(4, dueue.Dequeue().Id);
            Assert.AreEqual(5, dueue.Dequeue().Id);
            Assert.AreEqual(6, dueue.Dequeue().Id);
            Assert.AreEqual(1, dueue.Count);
            Assert.AreEqual(4, dueue.Head);
            Assert.AreEqual(4, dueue.Tail);

            Assert.AreEqual(7, dueue.Dequeue().Id);
            Assert.AreEqual(0, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(0, dueue.Tail);
        }

        public void Test4A1()
        {
            var dueue = new Deque<DownInfo>(2, true);
            bool res = false;

            var info1 = NewDownInfo(1);
            var info2 = NewDownInfo(2);
            var info3 = NewDownInfo(3);
            var info4 = NewDownInfo(4);
            var info5 = NewDownInfo(5);
            var info6 = NewDownInfo(6);

            dueue.Enqueue(info1);
            dueue.Enqueue(info2);
            dueue.Enqueue(info3);
            dueue.Enqueue(info4);
            dueue.Enqueue(info5);
            Assert.AreEqual(5, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(4, dueue.Tail);

            res = dueue.Remove(info6);
            Assert.True(!res);
            Assert.AreEqual(5, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(4, dueue.Tail);

            res = dueue.Remove(info3);
            Assert.True(res);
            Assert.AreEqual(4, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(3, dueue.Tail);
            Assert.AreEqual(1, dueue.Data[0].Id);
            Assert.AreEqual(2, dueue.Data[1].Id);
            Assert.AreEqual(4, dueue.Data[2].Id);
            Assert.AreEqual(5, dueue.Data[3].Id);

            res = dueue.Remove(info1);
            Assert.True(res);
            Assert.AreEqual(3, dueue.Count);
            Assert.AreEqual(1, dueue.Head);
            Assert.AreEqual(3, dueue.Tail);
            Assert.AreEqual(2, dueue.Data[1].Id);
            Assert.AreEqual(4, dueue.Data[2].Id);
            Assert.AreEqual(5, dueue.Data[3].Id);

            res = dueue.Remove(info5);
            Assert.True(res);
            Assert.AreEqual(2, dueue.Count);
            Assert.AreEqual(1, dueue.Head);
            Assert.AreEqual(2, dueue.Tail);
            Assert.AreEqual(2, dueue.Data[1].Id);
            Assert.AreEqual(4, dueue.Data[2].Id);

            res = dueue.Remove(info2);
            Assert.True(res);
            Assert.AreEqual(1, dueue.Count);
            Assert.AreEqual(2, dueue.Head);
            Assert.AreEqual(2, dueue.Tail);
            Assert.AreEqual(4, dueue.Data[2].Id);

            res = dueue.Remove(info4);
            Assert.True(res);
            Assert.AreEqual(0, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(0, dueue.Tail);
        }

        public void Test4A2()
        {
            var dueue = new Deque<StDownInfo>(2, true);
            bool res = false;

            var info1 = new StDownInfo() { Id = 1 };
            var info2 = new StDownInfo() { Id = 2 };
            var info3 = new StDownInfo() { Id = 3 };
            var info4 = new StDownInfo() { Id = 4 };
            var info5 = new StDownInfo() { Id = 5 };
            var info6 = new StDownInfo() { Id = 6 };

            dueue.Enqueue(info1);
            dueue.Enqueue(info2);
            dueue.Enqueue(info3);
            dueue.Enqueue(info4);
            dueue.Enqueue(info5);
            Assert.AreEqual(5, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(4, dueue.Tail);

            res = dueue.Remove(info6);
            Assert.True(!res);
            Assert.AreEqual(5, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(4, dueue.Tail);

            res = dueue.Remove(info3);
            Assert.True(res);
            Assert.AreEqual(4, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(3, dueue.Tail);
            Assert.AreEqual(1, dueue.Data[0].Id);
            Assert.AreEqual(2, dueue.Data[1].Id);
            Assert.AreEqual(4, dueue.Data[2].Id);
            Assert.AreEqual(5, dueue.Data[3].Id);

            res = dueue.Remove(info1);
            Assert.True(res);
            Assert.AreEqual(3, dueue.Count);
            Assert.AreEqual(1, dueue.Head);
            Assert.AreEqual(3, dueue.Tail);
            Assert.AreEqual(2, dueue.Data[1].Id);
            Assert.AreEqual(4, dueue.Data[2].Id);
            Assert.AreEqual(5, dueue.Data[3].Id);

            res = dueue.Remove(info5);
            Assert.True(res);
            Assert.AreEqual(2, dueue.Count);
            Assert.AreEqual(1, dueue.Head);
            Assert.AreEqual(2, dueue.Tail);
            Assert.AreEqual(2, dueue.Data[1].Id);
            Assert.AreEqual(4, dueue.Data[2].Id);

            res = dueue.Remove(info2);
            Assert.True(res);
            Assert.AreEqual(1, dueue.Count);
            Assert.AreEqual(2, dueue.Head);
            Assert.AreEqual(2, dueue.Tail);
            Assert.AreEqual(4, dueue.Data[2].Id);

            res = dueue.Remove(info4);
            Assert.True(res);
            Assert.AreEqual(0, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(0, dueue.Tail);
        }

        public void Test4B()
        {
            var dueue = new Deque<DownInfo>(2, true);
            DownInfo target = null;
            bool res = false;

            dueue.Enqueue(NewDownInfo(1));
            dueue.Enqueue(NewDownInfo(2));
            dueue.Enqueue(NewDownInfo(3));
            dueue.Enqueue(NewDownInfo(4));
            dueue.Enqueue(NewDownInfo(5));
            Assert.AreEqual(5, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(4, dueue.Tail);

            res = dueue.Remove((a) => a.Id == 6, out target);
            Assert.True(!res);
            Assert.True(target == null);
            Assert.AreEqual(5, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(4, dueue.Tail);

            res = dueue.Remove((a) => a.Id == 3, out target);
            Assert.True(res);
            Assert.True(target.Id == 3);
            Assert.AreEqual(4, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(3, dueue.Tail);
            Assert.AreEqual(1, dueue.Data[0].Id);
            Assert.AreEqual(2, dueue.Data[1].Id);
            Assert.AreEqual(4, dueue.Data[2].Id);
            Assert.AreEqual(5, dueue.Data[3].Id);

            res = dueue.Remove((a) => a.Id == 1, out target);
            Assert.True(res);
            Assert.True(target.Id == 1);
            Assert.AreEqual(3, dueue.Count);
            Assert.AreEqual(1, dueue.Head);
            Assert.AreEqual(3, dueue.Tail);
            Assert.AreEqual(2, dueue.Data[1].Id);
            Assert.AreEqual(4, dueue.Data[2].Id);
            Assert.AreEqual(5, dueue.Data[3].Id);

            res = dueue.Remove((a) => a.Id == 5, out target);
            Assert.True(res);
            Assert.True(target.Id == 5);
            Assert.AreEqual(2, dueue.Count);
            Assert.AreEqual(1, dueue.Head);
            Assert.AreEqual(2, dueue.Tail);
            Assert.AreEqual(2, dueue.Data[1].Id);
            Assert.AreEqual(4, dueue.Data[2].Id);

            res = dueue.Remove((a) => a.Id == 2, out target);
            Assert.True(res);
            Assert.True(target.Id == 2);
            Assert.AreEqual(1, dueue.Count);
            Assert.AreEqual(2, dueue.Head);
            Assert.AreEqual(2, dueue.Tail);
            Assert.AreEqual(4, dueue.Data[2].Id);

            res = dueue.Remove((a) => a.Id == 4, out target);
            Assert.True(res);
            Assert.True(target.Id == 4);
            Assert.AreEqual(0, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(0, dueue.Tail);
        }

        public void Test4C()
        {
            var dueue = new Deque<DownInfo>(2, true);
            int count = 0;

            dueue.Enqueue(NewDownInfo(1));
            dueue.Enqueue(NewDownInfo(2));
            dueue.Enqueue(NewDownInfo(3));
            dueue.Enqueue(NewDownInfo(4));
            dueue.Enqueue(NewDownInfo(5));
            Assert.AreEqual(5, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(4, dueue.Tail);

            count = dueue.RemoveAll((a) => a.Id == 6, (a) => { Assert.Fail(); });
            Assert.AreEqual(0, count);
            Assert.AreEqual(5, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(4, dueue.Tail);

            count = dueue.RemoveAll((a) => a.Id == 3, (a) => { Assert.True(a.Id == 3); });
            Assert.AreEqual(1, count);
            Assert.AreEqual(4, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(3, dueue.Tail);
            Assert.AreEqual(1, dueue.Data[0].Id);
            Assert.AreEqual(2, dueue.Data[1].Id);
            Assert.AreEqual(4, dueue.Data[2].Id);
            Assert.AreEqual(5, dueue.Data[3].Id);

            count = dueue.RemoveAll((a) => a.Id == 1, (a) => { Assert.True(a.Id == 1); });
            Assert.AreEqual(1, count);
            Assert.AreEqual(3, dueue.Count);
            Assert.AreEqual(1, dueue.Head);
            Assert.AreEqual(3, dueue.Tail);
            Assert.AreEqual(2, dueue.Data[1].Id);
            Assert.AreEqual(4, dueue.Data[2].Id);
            Assert.AreEqual(5, dueue.Data[3].Id);

            count = dueue.RemoveAll((a) => a.Id == 5, (a) => { Assert.True(a.Id == 5); });
            Assert.AreEqual(1, count);
            Assert.AreEqual(2, dueue.Count);
            Assert.AreEqual(1, dueue.Head);
            Assert.AreEqual(2, dueue.Tail);
            Assert.AreEqual(2, dueue.Data[1].Id);
            Assert.AreEqual(4, dueue.Data[2].Id);

            count = dueue.RemoveAll((a) => a.Id == 2, (a) => { Assert.True(a.Id == 2); });
            Assert.AreEqual(1, count);
            Assert.AreEqual(1, dueue.Count);
            Assert.AreEqual(2, dueue.Head);
            Assert.AreEqual(2, dueue.Tail);
            Assert.AreEqual(4, dueue.Data[2].Id);

            count = dueue.RemoveAll((a) => a.Id == 4, (a) => { Assert.True(a.Id == 4); });
            Assert.AreEqual(1, count);
            Assert.AreEqual(0, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(0, dueue.Tail);
        }

        public void Test4D()
        {
            var dueue = new Deque<DownInfo>(2, true);
            int count = 0;

            dueue.Enqueue(NewDownInfo(1));
            dueue.Enqueue(NewDownInfo(2));
            dueue.Enqueue(NewDownInfo(3));
            dueue.Enqueue(NewDownInfo(4));
            dueue.Enqueue(NewDownInfo(5));
            Assert.AreEqual(5, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(4, dueue.Tail);

            count = dueue.RemoveAll((a) => a.Id == 3 || a.Id == 5, (a) => { Assert.True(a.Id == 3 || a.Id == 5); });
            Assert.AreEqual(2, count);
            Assert.AreEqual(3, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(2, dueue.Tail);
            Assert.AreEqual(1, dueue.Data[0].Id);
            Assert.AreEqual(2, dueue.Data[1].Id);
            Assert.AreEqual(4, dueue.Data[2].Id);

            count = dueue.RemoveAll((a) => a.Id == 1 || a.Id == 2, (a) => { Assert.True(a.Id == 1 || a.Id == 2); });
            Assert.AreEqual(2, count);
            Assert.AreEqual(1, dueue.Count);
            Assert.AreEqual(1, dueue.Head);
            Assert.AreEqual(1, dueue.Tail);
            Assert.AreEqual(4, dueue.Data[1].Id);

            dueue.Enqueue(NewDownInfo(6));
            dueue.Enqueue(NewDownInfo(7));
            dueue.Enqueue(NewDownInfo(8));
            dueue.Enqueue(NewDownInfo(9));
            dueue.Enqueue(dueue.Dequeue());
            dueue.Enqueue(dueue.Dequeue());
            dueue.Enqueue(dueue.Dequeue());
            dueue.Enqueue(dueue.Dequeue());
            dueue.Enqueue(dueue.Dequeue());
            Assert.AreEqual(5, dueue.Count);
            Assert.AreEqual(6, dueue.Head);
            Assert.AreEqual(2, dueue.Tail);
            Assert.AreEqual(4, dueue.Data[6].Id);
            Assert.AreEqual(6, dueue.Data[7].Id);
            Assert.AreEqual(7, dueue.Data[0].Id);
            Assert.AreEqual(8, dueue.Data[1].Id);
            Assert.AreEqual(9, dueue.Data[2].Id);

            count = dueue.RemoveAll((a) => a.Id == 4 || a.Id == 6, (a) => { Assert.True(a.Id == 4 || a.Id == 6); });
            Assert.AreEqual(2, count);
            Assert.AreEqual(3, dueue.Count);
            Assert.AreEqual(7, dueue.Head);
            Assert.AreEqual(1, dueue.Tail);
            Assert.AreEqual(7, dueue.Data[7].Id);
            Assert.AreEqual(8, dueue.Data[0].Id);
            Assert.AreEqual(9, dueue.Data[1].Id);

            count = dueue.RemoveAll((a) => a.Id == 8, (a) => { Assert.True(a.Id == 8); });
            Assert.AreEqual(1, count);
            Assert.AreEqual(2, dueue.Count);
            Assert.AreEqual(7, dueue.Head);
            Assert.AreEqual(0, dueue.Tail);
            Assert.AreEqual(7, dueue.Data[7].Id);
            Assert.AreEqual(9, dueue.Data[0].Id);

            count = dueue.RemoveAll((a) => true, (a) => { Assert.True(a.Id == 7 || a.Id == 9); });
            Assert.AreEqual(2, count);
            Assert.AreEqual(0, dueue.Count);
            Assert.AreEqual(0, dueue.Head);
            Assert.AreEqual(0, dueue.Tail);
        }

        public void Test5A()
        {
            var dueue = new Deque<DownInfo>(2, true);
            var result = new List<DownInfo>();

            dueue.Enqueue(NewDownInfo(1));
            dueue.Enqueue(NewDownInfo(2));
            dueue.Enqueue(NewDownInfo(3));
            dueue.Enqueue(NewDownInfo(4));
            dueue.Enqueue(NewDownInfo(5));

            result.Clear();
            dueue.FindAll((a) => a.Id == 6, ref result);
            Assert.AreEqual(0, result.Count);

            result.Clear();
            dueue.FindAll((a) => a.Id == 1 || a.Id == 5, ref result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(1, result[0].Id);
            Assert.AreEqual(5, result[1].Id);

            result.Clear();
            dueue.FindAll((a) => a.Id == 2 || a.Id == 4, ref result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(2, result[0].Id);
            Assert.AreEqual(4, result[1].Id);

            result.Clear();
            dueue.Remove((a) => a.Id == 2, out DownInfo target);
            dueue.FindAll((a) => a.Id == 2 || a.Id == 3, ref result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(3, result[0].Id);
        }

        public void Test5B()
        {
            var dueue = new Deque<DownInfo>(2, true);
            DownInfo target = null;
            bool res = false;

            dueue.Enqueue(NewDownInfo(1));
            dueue.Enqueue(NewDownInfo(2));
            dueue.Enqueue(NewDownInfo(3));
            dueue.Enqueue(NewDownInfo(4));
            dueue.Enqueue(NewDownInfo(5));

            res = dueue.Find((a) => a.Id == 6, out target);
            Assert.True(!res);
            Assert.True(target == null);

            res = dueue.Find((a) => a.Id == 1, out target);
            Assert.True(res);
            Assert.True(target.Id == 1);

            res = dueue.Find((a) => a.Id == 5, out target);
            Assert.True(res);
            Assert.True(target.Id == 5);

            res = dueue.Find((a) => a.Id == 2 || a.Id == 4, out target);
            Assert.True(res);
            Assert.True(target.Id == 2);

            res = dueue.Remove((a) => a.Id == 2, out target);
            res = dueue.Find((a) => a.Id == 2, out target);
            Assert.True(!res);
            Assert.True(target == null);

            res = dueue.Find((a) => a.Id == 2 || a.Id == 4, out target);
            Assert.True(res);
            Assert.True(target.Id == 4);
        }

        public void Test5C1()
        {
            var dueue = new Deque<StDownInfo>(2, true);
            bool res = false;

            var info1 = new StDownInfo() { Id = 1 };
            var info2 = new StDownInfo() { Id = 2 };
            var info3 = new StDownInfo() { Id = 3 };
            var info4 = new StDownInfo() { Id = 4 };
            var info5 = new StDownInfo() { Id = 5 };
            var info6 = new StDownInfo() { Id = 6 };
            var info7 = new StDownInfo() { Id = 3 };

            dueue.Enqueue(info1);
            dueue.Enqueue(info2);
            dueue.Enqueue(info3);
            dueue.Enqueue(info4);
            dueue.Enqueue(info5);

            res = dueue.Contains(info1);
            Assert.True(res);
            res = dueue.Contains(info2);
            Assert.True(res);
            res = dueue.Contains(info3);
            Assert.True(res);
            res = dueue.Contains(info4);
            Assert.True(res);
            res = dueue.Contains(info5);
            Assert.True(res);
            res = dueue.Contains(info6);
            Assert.True(!res);
            res = dueue.Contains(info7);
            Assert.True(res);

            dueue.Remove(info3);
            res = dueue.Contains(info3);
            Assert.True(!res);
            res = dueue.Contains(info7);
            Assert.True(!res);
        }

        public void Test5C2()
        {
            var dueue = new Deque<DownInfo>(2, true);
            bool res = false;

            var info1 = NewDownInfo(1);
            var info2 = NewDownInfo(2);
            var info3 = NewDownInfo(3);
            var info4 = NewDownInfo(4);
            var info5 = NewDownInfo(5);
            var info6 = NewDownInfo(6);
            var info7 = NewDownInfo(3);

            dueue.Enqueue(info1);
            dueue.Enqueue(info2);
            dueue.Enqueue(info3);
            dueue.Enqueue(info4);
            dueue.Enqueue(info5);

            res = dueue.Contains(info1);
            Assert.True(res);
            res = dueue.Contains(info2);
            Assert.True(res);
            res = dueue.Contains(info3);
            Assert.True(res);
            res = dueue.Contains(info4);
            Assert.True(res);
            res = dueue.Contains(info5);
            Assert.True(res);
            res = dueue.Contains(info6);
            Assert.True(!res);
            res = dueue.Contains(info7);
            Assert.True(!res);

            dueue.Remove(info3);
            res = dueue.Contains(info3);
            Assert.True(!res);
            res = dueue.Contains(info7);
            Assert.True(!res);
        }

        private DownInfo NewDownInfo(int id)
        {
            return new DownInfo() { Id = id };
        }
    }
}
