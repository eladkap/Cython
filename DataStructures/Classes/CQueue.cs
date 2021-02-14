using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Classes
{
    public class CQueue<T> : object
    {
        private CList<T> _list;

        public CQueue()
        {
            _list = new CList<T>();
        }

        public int Size { get { return _list.Length; } }

        ~CQueue()
        {
            _list.Clear();
        }

        public void Enqueue(T t)
        {
            _list.Append(t);
        }

        public bool IsEmpty()
        {
            return _list.Length == 0;
        }

        public T First()
        {
            if (IsEmpty())
            {
                throw new Exception("StackIsEmptyError");
            }
            return _list[0];
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new Exception("QueueIsEmptyError");
            }
            T t = First();
            _list.PopFront();
            return t;
        }

        public override string ToString()
        {
            return _list.ToString();
        }
    }
}
