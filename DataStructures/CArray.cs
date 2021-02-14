using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class CArray<T> : object where T : IComparable
    {
        private T[] _arr;
        private int _length;
        private int _size;

        public CArray()
        {
            _arr = null;
            _length = 0;
            _size = 0;
        }

        public CArray(int size)
        {
            _size = size;
            _length = 0;
            _arr = new T[size];
            for (int i = 0; i < size; i++)
            {
                _arr[i] = default(T);
            }
        }

        public CArray(CArray<T> array)
        {
            _length = array._length;
            _size = array._size;
            _arr = new T[_size];
            for (int i = 0; i < _length; i++)
            {
                _arr[i] = array._arr[i];
            }
        }

        private void ShrinkArrayByTwo()
        {
            if (_length < _size / 4)
            {
                _size = (int)(_size / 2);
                T[] newArr = new T[_size];
                for (int i = 0; i < _size; i++)
                {
                    newArr[i] = _arr[i];
                }
                _arr = newArr;
            }
        }

        ~CArray()
        {
            Clear();
        }

        public void Clear()
        {
            if (_arr == null)
            {
                return;
            }
            _arr = null;
            _length = 0;
            _size = 0;
        }

        public T this[int index]
        {
            get {
                int l = _length;
                if (l == 0)
                {
                    throw new Exception("ArrayIsEmptyError");
                }
                if (index >= l)
                {
                    throw new Exception("ArrayIndexOutOfBoundsError");
                }
                if (index < 0)
                {
                    index = (l + index) % l;
                }
                return _arr[index];
            }
            set {
                int l = _length;
                if (l == 0)
                {
                    throw new Exception("ArrayIsEmptyError");
                }
                if (index >= l)
                {
                    throw new Exception("ArrayIndexOutOfBoundsError");
                }
                if (index < 0)
                {
                    index = (l + index) % l;
                }
                _arr[index] = value;
            }
        }

        public T Get(int index)
        {
            return this[index];
        }

        public int Size { get { return _size; } }

        public void Reverse()
        {
            for (int i = 0; i <= (int)(_length / 2); i++)
            {
                int j = _length - i - 1;
                T tmp = _arr[i];
                _arr[i] = _arr[j];
                _arr[j] = tmp;
            }
        }

        public void PushBack(T t)
        {
            if (_length == 0)
            {
                _size = 2;
                _arr = new T[2];
                _arr[0] = t;
                _length++;
                return;
            }
            if (_length < _size)
            {
                _arr[_length] = t;
                _length++;
            }
            else
            {
                _size *= 2;
                T[] newArr = new T[_size];
                int i = 0;
                for (; i < _size / 2; i++)
                {
                    newArr[i] = _arr[i];
                }
                for (; i < _size; i++)
                {
                    newArr[i] = default(T);
                }
                _arr = newArr;
                _arr[_length] = t;
                _length++;
            }
        }

        public void PushFront(T t)
        {
            PushBack(t);
            // Bubble last element down to the array begin
            int i = _length - 1;
            while (i > 0)
            {
                Swap(i, i - 1);
                i--;
            }
        }

        public void PopBack()
        {
            if (_arr == null || _length == 0)
            {
                throw new Exception("ArrayIsEmptyError");
            }
            _arr[_length - 1] = default(T);
            _length--;
            ShrinkArrayByTwo();
        }

        public void PopFront()
        {
            if (_arr == null || _length == 0)
            {
                throw new Exception("ArrayIsEmptyError");
            }
            _arr[0] = default(T);
            // Shift all array left one place
            for (int i = 1; i < _length; i++)
            {
                _arr[i - 1] = _arr[i];
            }
            _length--;
            ShrinkArrayByTwo();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            CArray<T> a = (CArray<T>)obj;
            if (_length != a._length)
            {
                return false;
            }
            for (int i = 0; i < _length; i++)
            {
                if (!a._arr[i].Equals(_arr[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public void Extend(CArray<T> a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                PushBack(a[i]);
            }
        }

        private void Swap(int i, int j)
        {
            if (i < 0 || i >= _length || j < 0 || j >= _length)
            {
                throw new Exception("ArrayIndexOutOfBoundsError");
            }
            T tmp = _arr[i];
            _arr[i] = _arr[j];
            _arr[j] = tmp;
        }

        public void Shuffle()
        {
            Random random = new Random(0);
            for (int i = 0; i < _length; i++)
            {
                int j = random.Next(0, _length - 1);
                Swap(i, j);
            }
        }

        public int Length { get { return _length; } }

        public int Count(T t)
        {
            int c = 0;
            for (int i = 0; i < _length; i++)
            {
                if (t.Equals(_arr[i]))
                {
                    c++;
                }
            }
            return c;
        }

        public int Find(T t)
        {
            for (int i = 0; i < _length; i++)
            {
                if (t.Equals(_arr[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Sort()
        {
            for (int k = _length - 1; k >= 1; k--)
            {
                for (int i = 0; i < k; i++)
                {
                    if (_arr[i].CompareTo(_arr[i + 1]) > 0)
                    {
                        Swap(i, i + 1);
                    }
                }
            }
        }

        public override string ToString()
        {
            string s = "";
            if (_length == 0)
            {
                return "[]";
            }
            s += "[";
            int i = 0;
            for (; i < _length - 1; i++)
            {
                s += _arr[i].ToString();
            }
            s += _arr[i].ToString() + "]";
            return s;
        }
    }
}
