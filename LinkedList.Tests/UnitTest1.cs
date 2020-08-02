using NUnit.Framework;
using System;

namespace LinkedList.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(5, new int[] { 5, 5 })]
        [TestCase(0, new int[] { 0, 0 })]
        public void AddLastTest(int a, int[] ex)
        {
            LinkedListProject.LinkedList lList = new LinkedListProject.LinkedList();

            lList.AddLast(a);
            lList.AddLast(a);
            int[] actual = lList.ToArray();
            Assert.AreEqual(ex, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 5, 6, 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 5, 6, 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 0, 0, 0, 0 }, new int[] { 5, 6, 0, 0, 0, 0 })]
        public void AddLastTest(int[] a, int[] ex)
        {
            LinkedListProject.LinkedList lList = new LinkedListProject.LinkedList();

            lList.AddLast(5);
            lList.AddLast(6);
            lList.AddLast(a);
            int[] actual = lList.ToArray();
            Assert.AreEqual(ex, actual);

        }

        [TestCase(15, new int[] { 15, 5, 6 })]
        [TestCase(0, new int[] { 0, 5, 6 })]
        public void AddFirstTest(int a, int[] ex)
        {
            LinkedListProject.LinkedList lList = new LinkedListProject.LinkedList();

            lList.AddLast(5);
            lList.AddLast(6);
            lList.AddFirst(a);
            int[] actual = lList.ToArray();
            Assert.AreEqual(ex, actual);
        }
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 5, 6 })]
        [TestCase(new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 5, 6 })]
        public void AddFirstTest(int[] a, int[] ex)
        {
            LinkedListProject.LinkedList lList = new LinkedListProject.LinkedList();

            lList.AddLast(5);
            lList.AddLast(6);
            lList.AddFirst(a);
            int[] actual = lList.ToArray();
            Assert.AreEqual(ex, actual);
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 25, new int[] { 1, 25, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 25, new int[] { 25, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 25, new int[] { 1, 2, 25, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 25, new int[] { 1, 2, 3, 25, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -3, 25, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 13, 25, new int[] { 1, 2, 3, 4, 5 })]
        public void AddAtTest(int[] array, int idx, int val, int[] ex)
        {
            LinkedListProject.LinkedList lList = new LinkedListProject.LinkedList();
            if (idx < 0 || idx > array.Length)
            {
                Assert.Throws<Exception>(() => lList.AddAt(idx, val));
            }
            else
            {

                lList.AddLast(array);
                lList.AddAt(idx, val);

                int[] actual = lList.ToArray();
                Assert.AreEqual(ex, actual);
            }
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0 })]
        public void ReverseTest(int[] a, int[] ex)
        {
            LinkedListProject.LinkedList lList = new LinkedListProject.LinkedList();
            lList.AddLast(a);
            lList.Reverse();
            int[] actual = lList.ToArray();
            Assert.AreEqual(ex, actual);
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { 1, 2, 3 }, 3)]
        [TestCase(new int[] { 0, 0, 0 }, 3)]
        [TestCase(new int[] { 0 }, 1)]
        [TestCase(new int[] { }, 0)]
        public void GetSizeTest(int[] a, int ex)
        {
            LinkedListProject.LinkedList lList = new LinkedListProject.LinkedList();
            lList.AddLast(a);
            int actual = lList.GetSize();
            Assert.AreEqual(ex, actual);
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 25, new int[] { 1, 25, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 25, new int[] { 25, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 25, new int[] { 1, 2, 25, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 25, new int[] { 1, 2, 3, 25, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 25, new int[] { 1, 2, 3, 4, 25 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -4, 25, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 10, 25, new int[] { 1, 2, 3, 4, 5 })]

        public void SetTest(int[] a, int idx, int val, int[] ex)
        {
            LinkedListProject.LinkedList lList = new LinkedListProject.LinkedList();
            if (idx < 0 || idx > a.Length)
            {
                Assert.Throws<Exception>(() => lList.Set(idx, val));
            }
            else
            {

                lList.AddLast(a);
                lList.Set(idx, val);
                int[] actual = lList.ToArray();
                Assert.AreEqual(ex, actual);
            }

        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2 }, new int[] { 2 })]
        [TestCase(new int[] { 5 }, new int[] { })]
        [TestCase(new int[] { }, new int[] { })]
        public void RemoveFirstTest(int[] array, int[] ex)
        {
            LinkedListProject.LinkedList lList = new LinkedListProject.LinkedList();
            if (array.Length < 2)
            {
                Assert.Throws<Exception>(() => lList.RemoveFirst());
            }
            else
            {

                lList.AddLast(array);
                lList.RemoveFirst();
                int[] actual = lList.ToArray();
                Assert.AreEqual(ex, actual);
            }
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 2 }, new int[] { })]
        public void RemoveLastTest(int[] array, int[] ex)
        {
            LinkedListProject.LinkedList lList = new LinkedListProject.LinkedList();
            if (array.Length == 0)
            {
                Assert.Throws<Exception>(() => lList.RemoveLast());
            }
            else
            {
                lList.AddLast(array);
                lList.RemoveLast();
                int[] actual = lList.ToArray();
                Assert.AreEqual(ex, actual);
            }
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, new int[] { 1, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, new int[] { 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 7, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -7, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { }, 2, new int[] { })]
        public void RemoveAtTest(int[] array, int idx, int[] ex)
        {
            LinkedListProject.LinkedList lList = new LinkedListProject.LinkedList();
            if (array.Length == 0 || idx > array.Length || idx < 0)
            {
                Assert.Throws<Exception>(() => lList.RemoveAt(idx));
            }
            else
            {
                lList.AddLast(array);
                lList.RemoveAt(idx);
                int[] actual = lList.ToArray();
                Assert.AreEqual(ex, actual);
            }
        }
        [TestCase(new int[] { 1, 2, 3, 2, 5 }, 2, new int[] { 1, 3, 5 })]
        [TestCase(new int[] { 1, 2, 3, 2, 5 }, 1, new int[] { 2, 3, 2, 5 })]
        [TestCase(new int[] { 1, 2, 3, 2, 5 }, 0, new int[] { 1, 2, 3, 2, 5 })]
        [TestCase(new int[] { 5, 2, 3, 2, 5 }, 5, new int[] { 2, 3, 2 })]
        [TestCase(new int[] { }, 0, new int[] { })]
        public void RemoveAllTest(int[] array, int val, int[] ex)
        {
            LinkedListProject.LinkedList lList = new LinkedListProject.LinkedList();
            if (array.Length == 0)
            {
                Assert.Throws<Exception>(() => lList.RemoveAll(val));
            }
            else
            {
                lList.AddLast(array);
                lList.RemoveAll(val);
                int[] actual = lList.ToArray();
                Assert.AreEqual(ex, actual);
            }
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, true)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, false)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6, false)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, true)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, true)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5, true)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, true)]
        [TestCase(new int[] { }, 0, false)]
        public void ContainsTest(int[] array, int val, bool ex)
        {
            LinkedListProject.LinkedList lList = new LinkedListProject.LinkedList();
            if (array.Length == 0)
            {
                bool actual = false;
            }
            else
            {
                lList.AddLast(array);
                bool actual = lList.Contains(val);
                Assert.AreEqual(ex, actual);
            }
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 7, 7, 7, 7 }, 1, 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 7, 7, 7, 7 }, 2, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 7, 7, 7, 7 }, 7, 6)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 7, 7, 7, 7 }, 25, -1)]
        [TestCase(new int[] { }, 7, null)]
        public void IndexOfTest(int[] array, int val, int ex)
        {
            LinkedListProject.LinkedList lList = new LinkedListProject.LinkedList();
            if (array.Length == 0)
            {
                Assert.Throws<Exception>(() => lList.IndexOf(val));
            }
            else
            {
                lList.AddLast(array);
                int actual = lList.IndexOf(val);
                Assert.AreEqual(ex, actual);
            }
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 7 }, 1)]
        [TestCase(new int[] { 2, 3, 4, 5, 7 }, 2)]
        [TestCase(new int[] { 7 }, 7)]
        [TestCase(new int[] { }, null)]
        public void GetFirstTest(int[] array, int ex)
        {
            LinkedListProject.LinkedList lList = new LinkedListProject.LinkedList();
            if (array.Length == 0)
            {
                Assert.Throws<Exception>(() => lList.GetFirst());
            }
            else
            {
                lList.AddLast(array);
                int actual = lList.GetFirst();
                Assert.AreEqual(ex, actual);
            }
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 7 }, 7)]
        [TestCase(new int[] { 2, 3, 4, 5, 7 }, 7)]
        [TestCase(new int[] { 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { 2, 3 }, 3)]
        [TestCase(new int[] { 7 }, 7)]
        [TestCase(new int[] { }, null)]
        public void GetLastTest(int[] array, int ex)
        {
            LinkedListProject.LinkedList lList = new LinkedListProject.LinkedList();
            if (array.Length == 0)
            {
                Assert.Throws<Exception>(() => lList.GetLast());
            }
            else
            {
                lList.AddLast(array);
                int actual = lList.GetLast();
                Assert.AreEqual(ex, actual);
            }
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 0, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 7, 8)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 5, 6)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 15, 0)]
        [TestCase(new int[] { }, 5, 0)]
        public void GetTest(int[] array, int idx, int ex)
        {
            LinkedListProject.LinkedList lList = new LinkedListProject.LinkedList();
            if (array.Length == 0 || idx < 0 || idx > array.Length)
            {
                Assert.Throws<Exception>(() => lList.Get(idx));
            }
            else
            {
                lList.AddLast(array);
                int actual = lList.Get(idx);
                Assert.AreEqual(ex, actual);
            }
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 8)]
        [TestCase(new int[] { 1, 2, 3, 4, 8, 6, 7 }, 8)]
        [TestCase(new int[] { 8, 2, 3, 4, 6, 7 }, 8)]
        [TestCase(new int[] { }, 0)]
        public void MaxTest(int[] array, int ex)
        {
            LinkedListProject.LinkedList lList = new LinkedListProject.LinkedList();
            if (array.Length == 0)
            {
                Assert.Throws<Exception>(() => lList.Max());
            }
            else
            {
                lList.AddLast(array);
                int actual = lList.Max();
                Assert.AreEqual(ex, actual);
            }
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 1)]
        [TestCase(new int[] { 8, 2, 3, 4, 8, 6, 1 }, 1)]
        [TestCase(new int[] { 8, 2, 3, 4, 6, 7 }, 2)]
        [TestCase(new int[] { }, 0)]
        public void MinTest(int[] array, int ex)
        {
            LinkedListProject.LinkedList lList = new LinkedListProject.LinkedList();
            if (array.Length == 0)
            {
                Assert.Throws<Exception>(() => lList.Min());
            }
            else
            {
                lList.AddLast(array);
                int actual = lList.Min();
                Assert.AreEqual(ex, actual);
            }
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 7)]
        [TestCase(new int[] { 8, 2, 3, 4, 8, 6, 1 }, 0)]
        [TestCase(new int[] { 1, 2, 8, 4, 6, 7 }, 2)]
        [TestCase(new int[] { 1, 2, 8, 10, 6, 7 }, 3)]
        [TestCase(new int[] { }, 0)]
        public void IndexOfMaxTest(int[] array, int ex)
        {
            LinkedListProject.LinkedList lList = new LinkedListProject.LinkedList();
            if (array.Length == 0)
            {
                Assert.Throws<Exception>(() => lList.IndexOfMax());
            }
            else
            {
                lList.AddLast(array);
                int actual = lList.IndexOfMax();
                Assert.AreEqual(ex, actual);
            }
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 0)]
        [TestCase(new int[] { 8, 2, 3, 4, 8, 6, 1 }, 6)]
        [TestCase(new int[] { 1, 2, 8, 4, 6, 7 }, 0)]
        [TestCase(new int[] { 1, 2, 8, 10, 6, 7 }, 0)]
        [TestCase(new int[] { }, 0)]
        public void IndexOfMinTest(int[] array, int ex)
        {
            LinkedListProject.LinkedList lList = new LinkedListProject.LinkedList();
            if (array.Length == 0)
            {
                Assert.Throws<Exception>(() => lList.IndexOfMin());
            }
            else
            {
                lList.AddLast(array);
                int actual = lList.IndexOfMin();
                Assert.AreEqual(ex, actual);
            }
        }
        [TestCase(new int[] { 1, 2, 8, 10, 6, 7 }, new int[] { 1, 2, 6, 7, 8, 10 })]
        [TestCase(new int[] { 6, 6, 32, 2, 56, 8, 0, 1, 23, 34, 56, 89 }, new int[] { 0, 1, 2, 6, 6, 8, 23, 32, 34, 56, 56, 89 })]
        [TestCase(new int[] { }, new int[] { })]
        public void SortTest(int[] array, int[] ex)
        {
            LinkedListProject.LinkedList lList = new LinkedListProject.LinkedList();

            lList.AddLast(array);
            lList.Head = lList.Sort(lList.Head);
            int[] actual = lList.ToArray();
            Assert.AreEqual(ex, actual);

        }

        [TestCase(new int[] { 1, 2, 8, 10, 6, 7 }, new int[] { 10, 8, 7, 6, 2, 1 })]
        [TestCase(new int[] { 6, 6, 32, 2, 56, 8, 0, 1, 23, 34, 56, 89 }, new int[] { 89, 56, 56, 34, 32, 23, 8, 6, 6, 2, 1, 0 })]
        [TestCase(new int[] { }, new int[] { })]
        public void SortDescTest(int[] array, int[] ex)
        {
            LinkedListProject.LinkedList lList = new LinkedListProject.LinkedList();

            lList.AddLast(array);
            lList.Head = lList.SortDesc(lList.Head);
            int[] actual = lList.ToArray();
            Assert.AreEqual(ex, actual);

        }
    }
}