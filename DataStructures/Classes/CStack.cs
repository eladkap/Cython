using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Classes
{
    public class CStack<T> : object
    {
        private CList<T> _list;

        public CStack()
        {
            _list = new CList<T>();
        }

        public int Size { get{ return _list.Length; } }

        ~CStack()
        {
            _list.Clear();
        }

        public void Push(T t)
        {
            _list.Append(t);
        }

        public bool IsEmpty()
        {
            return _list.Length == 0;
        }

        public T Top()
        {
            if (IsEmpty())
            {
                throw new Exception("StackIsEmptyError");
            }
            int l = _list.Length;
            return _list[l - 1];
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("StackIsEmptyError");
            }
            T t = Top();
            _list.PopBack();
            return t;
        }

        public override string ToString()
        {
            return _list.ToString();
        }
    }
}
