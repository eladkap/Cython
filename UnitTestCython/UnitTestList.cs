using System;
using DataStructures.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCython
{
    [TestClass]
    public class UnitTestList
    {
        [TestMethod]
        public void TestListCtor()
        {
            CList<int> l1 = new CList<int>();
            for (int i = 1; i <= 10; i++)
            {
                l1.Append(i);
            }
            Assert.AreEqual(l1.Length, 10);
        }

        [TestMethod]
        public void TestListEmptyCtor()
        {
            CList<int> l1 = new CList<int>();
            Assert.AreEqual(l1.Length, 0);
        }

        [TestMethod]
        public void TestListCopyCtor()
        {
            CList<int> l1 = new CList<int>();
            for (int i = 1; i <= 10; i++)
            {
                l1.Append(i);
            }
            CList<int> l2 = new CList<int>(l1);
            Assert.AreEqual(l1.Length, l2.Length);
            Assert.AreEqual(l2.Length, 10);
            Assert.AreEqual("[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]", l2.ToString());
        }

        [TestMethod]
        public void TestListClear()
        {
            CList<int> l1 = new CList<int>();
            for (int i = 1; i <= 10; i++)
            {
                l1.Append(i);
            }
            l1.Clear();
            Assert.AreEqual(l1.Length, 0);
            Assert.AreEqual("[]", l1.ToString());
        }

        [TestMethod]
        public void TestListExtend()
        {
            CList<int> l1 = new CList<int>();
            for (int i = 1; i <= 5; i++)
            {
                l1.Append(i);
            }
            CList<int> l2 = new CList<int>();
            for (int i = 6; i <= 12; i++)
            {
                l2.Append(i);
            }
            l1.Extend(l2);
            Assert.AreEqual(l1.Length, 12);
            Assert.AreEqual("[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]", l1.ToString());
        }

        [TestMethod]
        public void TestListPopBack()
        {
            CList<string> l1 = new CList<string>();
            l1.Append("abcd");
            l1.Append("qwerty");
            l1.Append("hello");
            l1.Append("world");
            l1.PopBack();
            Assert.AreEqual(l1.Length, 3);
            Assert.AreEqual("[abcd, qwerty, hello]", l1.ToString());
        }

        [TestMethod]
        public void TestListPopFront()
        {
            CList<string> l1 = new CList<string>();
            l1.Append("abcd");
            l1.Append("qwerty");
            l1.Append("hello");
            l1.Append("world");
            l1.PopFront();
            Assert.AreEqual(l1.Length, 3);
            Assert.AreEqual("[qwerty, hello, world]", l1.ToString());
        }

        [TestMethod]
        public void TestListIndexer()
        {
            CList<int> l1 = new CList<int>();
            for (int i = 0; i <= 9; i++)
            {
                l1.Append(i);
            }
            for (int i = 0; i <= 9; i++)
            {
                Assert.AreEqual(l1[i], i);
            }
            Assert.ThrowsException<Exception>(() => l1[10]);
            Assert.ThrowsException<Exception>(() => l1[-1]);
        }

        [TestMethod]
        public void TestListEquals()
        {
            CList<int> l1 = new CList<int>();
            for (int i = 0; i <= 9; i++)
            {
                l1.Append(i);
            }
            CList<int> l2 = new CList<int>();
            for (int i = 0; i <= 9; i++)
            {
                l2.Append(i);
            }
            Assert.IsTrue(l1.Equals(l2));
        }

        [TestMethod]
        public void TestListCount()
        {
            CList<int> l1 = new CList<int>();
            for (int i = 0; i <= 9; i++)
            {
                l1.Append(i);
            }
            l1.Append(1);
            l1.Append(2);
            l1.Append(8);
            l1.Append(9);
            l1.Append(8);
            Assert.AreEqual(l1.Count(12), 0);
            Assert.AreEqual(l1.Count(1), 2);
            Assert.AreEqual(l1.Count(8), 3);
        }

        [TestMethod]
        public void TestListFind()
        {
            CList<int> l1 = new CList<int>();
            for (int i = 0; i <= 9; i++)
            {
                l1.Append(i);
            }  
            Assert.AreEqual(l1.Find(12), -1);
            Assert.AreEqual(l1.Find(1), 1);
            Assert.AreEqual(l1.Find(8), 8);
        }
    }
}
