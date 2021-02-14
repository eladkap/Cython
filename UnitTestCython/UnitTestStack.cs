using System;
using DataStructures.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCython
{
    [TestClass]
    public class UnitTestStack
    {
        [TestMethod]
        public void TestMethodStackPush()
        {
            CStack<string> s = new CStack<string>();
            Assert.AreEqual(s.Size, 0);
            s.Push("a");
            Assert.AreEqual(s.Size, 1);
            Assert.AreEqual(s.Top(), "a");
            s.Push("b");
            Assert.AreEqual(s.Size, 2);
            Assert.AreEqual(s.Top(), "b");
        }

        [TestMethod]
        public void TestMethodStackPop()
        {
            CStack<string> s = new CStack<string>();
            Assert.AreEqual(s.Size, 0);
            s.Push("a");
            s.Push("b");
            s.Push("c");
            Assert.AreEqual(s.Top(), "c");
            s.Pop();
            Assert.AreEqual(s.Top(), "b");
            s.Pop();
            Assert.AreEqual(s.Top(), "a");
            s.Pop();
            Assert.IsTrue(s.IsEmpty());
            Assert.ThrowsException<Exception>(() => s.Top());
            Assert.ThrowsException<Exception>(() => s.Pop());
        }
    }
}
