using System;
using DataStructures.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCython
{
    [TestClass]
    public class UnitTestQueue
    {
        [TestMethod]
        public void TestMethodQueueEnqueue()
        {
            CQueue<string> q = new CQueue<string>();
            Assert.AreEqual(q.Size, 0);
            q.Enqueue("a");
            Assert.AreEqual(q.Size, 1);
            Assert.AreEqual(q.First(), "a");
            q.Enqueue("b");
            Assert.AreEqual(q.Size, 2);
            Assert.AreEqual(q.First(), "a");
        }

        [TestMethod]
        public void TestMethodQueueDequeue()
        {
            CQueue<string> q = new CQueue<string>();
            Assert.AreEqual(q.Size, 0);
            q.Enqueue("a");
            q.Enqueue("b");
            q.Enqueue("c");
            Assert.AreEqual(q.First(), "a");
            q.Dequeue();
            Assert.AreEqual(q.First(), "b");
            q.Dequeue();
            Assert.AreEqual(q.First(), "c");

            q.Dequeue();
            Assert.IsTrue(q.IsEmpty());
            Assert.ThrowsException<Exception>(() => q.First());
            Assert.ThrowsException<Exception>(() => q.Dequeue());
        }
    }
}
