using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Classes
{
    public class TreeNode<K, V> : object
    {
        private K _key;
        private V _value;
        private TreeNode<K, V> _left;
        private TreeNode<K, V> _right;
        private TreeNode<K, V> _parent;
        private int _level;
        private int _height;
        private int _bf;

        public TreeNode(K key, V value, int level)
        {
            _key = key;
            _value = value;
            _left = null;
            _right = null;
            _parent = null;
            _level = level;
            _height = 0;
            _bf = 0;
        }

        public TreeNode() : this(default(K), default(V), 0)
        { }

        public K Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public V Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public TreeNode<K, V> Left
        {
            get { return _left; }
            set { _left = value; }
        }

        public TreeNode<K, V> Right
        {
            get { return _right; }
            set { _right = value; }
        }

        public TreeNode<K, V> Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public int Level { get => _level; }

        public int Height { 
            get => _height;
            set { _height = value; }
        }

        public int BF { 
            get => _bf;
            set { _bf = value; }
        }

        public bool IsLeaf
        {
            get { return _left == null && _right == null; }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return _key.Equals(((TreeNode<K, V>)(obj))._key);
        }

        public override int GetHashCode()
        {
            return _key.GetHashCode();
        }

        public override string ToString()
        {
            return _key.ToString();
        }
    }

    public class Tree<K, V>: object where K : IComparable
    {
        private TreeNode<K, V> _root;
        private int _length;

        public Tree()
        {
            _root = null;
            _length = 0;
        }

        void Dispose(TreeNode<K, V> root)
        {
            if (root == null)
            {
                return;
            }
            Dispose(root.Left);
            Dispose(root.Right);
            root = null;
        }
        ~Tree()
        {
            Dispose(_root);
            _root = null;
            _length = 0;
        }

        public int Length { get => _length; }

        public TreeNode<K,V> Find(K key)
        {
            TreeNode<K, V> node = _root;
            while (node != null)
            {
                if (node.Key.Equals(key))
                {
                    return node;
                }
                if (key.CompareTo(node.Key) < 0)
                {
                    node = node.Left;
                }
                else if (key.CompareTo(node.Key) > 0)
                {
                    node = node.Right;
                }
            }
            return null;
        }

        private bool Retrace(TreeNode<K, V> node)
        {
            bool isBalanced = true;
            while (node != null)
            {
                int leftHeight = (node.Left == null) ? 0 : node.Left.Height;
                int rightHeight = (node.Right == null) ? 0 : node.Right.Height;
                node.Height = Math.Max(leftHeight, rightHeight) + 1;
                node.BF = leftHeight - rightHeight;
                node = node.Parent;
            }
            return isBalanced;
        }

        public void Insert(K key, V value)
        {
            if (_root == null)
            {
                _root = new TreeNode<K, V>(key, value, 0);
                _length++;
                return;
            }
            TreeNode<K, V> node = _root;
            while (node != null)
            {
                if (node.Key.Equals(key))
                {
                    return;
                }
                if (node.Left != null && key.CompareTo(node.Key) < 0)
                {
                    node = node.Left;
                    continue;
                }
                if (node.Right != null && key.CompareTo(node.Key) > 0)
                {
                    node = node.Right;
                    continue;
                }
                break;
            }
            int level = node.Level + 1;
            TreeNode<K, V> newNode = new TreeNode<K, V>(key, value, level);
            newNode.Parent = node;

            if (key.CompareTo(node.Key) < 0)
            {
                node.Left = newNode;
            }
            else
            {
                node.Right = newNode;
            }

            _length++;

            //UpdateHeight(newNode);
            bool isBalanced = Retrace(newNode);

            if (!isBalanced)
            {
                Rotate();
            }
        }

        private void Rotate()
        {
            
        }

        public void SetItem(K key, V value)
        {
            TreeNode<K, V> node = Find(key);
            if (node != null)
            {
                node.Value = value;
                return;
            }
            Insert(key, value);
        }

        public void Clear()
        {
            Dispose(_root);
            _root = null;
            _length = 0;
        }

        private TreeNode<K, V> FindNextSuccessor(TreeNode<K, V> node)
        {
            if (node == null || node.Right == null)
            {
                return null;
            }
            TreeNode<K, V> succ = node.Right;
            while (succ.Left != null)
            {
                succ = succ.Left;
            }
            return succ;
        }
    }
}
