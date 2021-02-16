using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Classes
{
    class CNode<T> : object
    {
        private T _data;
        private CNode<T> _next;

        public CNode(T data)
        {
            _data = data;
            _next = null;
        }

        public CNode() : this(default(T))
        { }

        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public CNode<T> Next {
            get { return _next; }
            set { _next = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return _data.Equals(((CNode<T>)(obj))._data);
        }

        public override int GetHashCode()
        {
            return _data.GetHashCode();
        }

        public override string ToString()
        {
            return _data.ToString();
        }
    }

    public class CList<T> : object, IEnumerable<T>, IEnumerator<T>
    {
        private CNode<T> _head;
        private CNode<T> _tail;
        private int _length;
        private CNode<T> _current;

        public CList()
        {
            _head = new CNode<T>();
            _tail = new CNode<T>();
            _head.Next = _tail;
            _current = _head;
            _length = 0;
        }

        public CList(CList<T> list)
        {
            Clear();
            _head = new CNode<T>();
            _tail = new CNode<T>();
            _head.Next = _tail;
            CNode<T> node = list._head.Next;
            while (node != list._tail)
            {
                Append(node.Data);
                node = node.Next;
            }
        }

        public void Clear()
        {
            while (_length > 0)
            {
                PopBack();
            }
            _length = 0;
        }

        public void Append(T t)
        {
            CNode<T> node = _head;
            while (node.Next != _tail)
            {
                node = node.Next;
            }
            CNode<T> newNode = new CNode<T>(t);
            newNode.Next = _tail;
            node.Next = newNode;
            _length++;
        }

        public void Extend(CList<T> list)
        {
            CNode<T> node = list._head.Next;
            while (node != list._tail)
            {
                Append(node.Data);
                node = node.Next;
            }
        }

        public void PopBack()
        {
            if (this._length == 0)
            {
                return;
            }
            CNode<T> curr = _head.Next;
            CNode<T> prev = _head;
            while (curr.Next != _tail)
            {
                curr = curr.Next;
                prev = prev.Next;
            }
            prev.Next = _tail;
            _length--;
        }

        public void PopFront()
        {
            if (_length == 0)
            {
                return;
            }
            CNode<T> first = _head.Next;
            _head.Next = first.Next;
            _length--;
        }

        public void PushFront(T t) {
            CNode<T> newNode = new CNode<T>(t);
            CNode<T> firstNode = _head.Next;
            newNode.Next = firstNode;
            _head.Next = newNode;
        }

        ~CList()
        {
            Clear();
        }

        public int Length
        {
            get { return _length; }
        }

        public T Current => _current.Data;

        object IEnumerator.Current => Current;

        public T this[int index]
        {
            get {
                int l = _length;
                if (l == 0)
                {
                    throw new Exception("ListIsEmptyError");
                }
                if (index < 0 || index >= l)
                {
                    throw new Exception("IndexOutOfBoundsError");
                }
                CNode<T> node = _head;
                int i = 0;
                while (i <= index)
                {
                    node = node.Next;
                    i++;
                }
                return node.Data;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            CList<T> list = (CList<T>)obj;
            if (_length != list._length)
            {
                return false;
            }
            CNode<T> node1 = _head.Next;
            CNode<T> node2 = list._head.Next;
            while (node1 != _tail)
            {
                if (!node1.Data.Equals(node2.Data))
                {
                    return false;
                }
                node1 = node1.Next;
                node2 = node2.Next;
            }
            return true;
        }

        public int Count(T t)
        {
            int count = 0;
            CNode<T> node = _head.Next;
            while (node != _tail)
            {
                if (t.Equals(node.Data))
                {
                    count++;
                }
                node = node.Next;
            }
            return count;
        }

        public int Find(T t)
        {
            int index = 0;
            CNode<T> node = _head.Next;
            while (node != _tail)
            {
                if (t.Equals(node.Data))
                {
                    return index;
                }
                node = node.Next;
                index++;
            }
            return -1;
        }

        public void Reverse()
        {
            if (_length <= 1)
            {
                return;
            }
            _tail = _head;
            CNode<T> prevNode = null;
            CNode<T> currNode = _head;
            CNode<T> nextNode = null;
            while (currNode != null)
            {
                nextNode = currNode.Next;
                currNode.Next = prevNode;
                prevNode = currNode;
                currNode = nextNode;
            }
            _head = prevNode;
        }

        public override string ToString()
        {
            if (_length == 0)
            {
                return "[]";
            }
            string s = "[";
            CNode<T> node = _head.Next;
            while (node.Next != _tail)
            {
                s += node.Data + ", ";
                node = node.Next;
            }
            s += node.Data + "]";
            return s;
        }

        public ulong Hash()
        {
            if (Length == 0)
            {
                return 0;
            }
            Type type = typeof(T);
            T t = _head.Next.Data;
            if (type.Name.ToLower().Contains("int"))
            {
                return Convert.ToUInt64(t);
            }
            else if (type.Name.ToLower() == "string"){
                return (ulong)(t.ToString().GetHashCode());
            }
            else
            {
                return 1;
            }
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool MoveNext()
        {
            _current = _current.Next;
            return _current != _tail;
        }

        public void Reset()
        {
            _current = _head;
        }

        public void Dispose()
        {
        }
    }
}
