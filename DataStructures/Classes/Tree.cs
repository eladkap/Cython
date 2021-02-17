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
        private int _hash;


        public TreeNode(K key, V value, int level)
        {
            _key = key;
            _value = value;
            _left = null;
            _right = null;
            _parent = null;
            _level = level;
            _hash = key.GetHashCode();
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

        public int Hash { get => _hash; }


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
            return "(" + _key.ToString() + ", " + _value.ToString() + ")";
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

        public TreeNode<K, V> Find(K key)
        {
            TreeNode<K, V> node = _root;
            while (node != null)
            {
                if (node.Key.GetHashCode() == key.GetHashCode())
                {
                    return node;
                }
                if (key.GetHashCode() < node.Key.GetHashCode())
                {
                    node = node.Left;
                }
                else if (key.GetHashCode() > node.Key.GetHashCode())
                {
                    node = node.Right;
                }
            }
            return null;
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
                if (node.Key.GetHashCode() == key.GetHashCode())
                {
                    return;
                }
                if (node.Left != null && key.GetHashCode() < node.Key.GetHashCode())
                {
                    node = node.Left;
                    continue;
                }
                if (node.Right != null && key.GetHashCode() > node.Key.GetHashCode())
                {
                    node = node.Right;
                    continue;
                }
                break;
            }
            int level = node.Level + 1;
            TreeNode<K, V> newNode = new TreeNode<K, V>(key, value, level);
            newNode.Parent = node;

            if (key.GetHashCode() < node.Key.GetHashCode())
            {
                node.Left = newNode;
            }
            else
            {
                node.Right = newNode;
            }

            _length++;
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

        private TreeNode<K, V> FindNextSuccessorOld(TreeNode<K, V> node)
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

        private TreeNode<K, V> FindNextSuccessor(TreeNode<K, V> node)
        {
            TreeNode<K, V> succ = null;
            CList<TreeNode<K, V>> nodes = Nodes();
            int i = 0;
            for (; i < nodes.Length; i++)
            {
                if (node.Key.Equals(nodes[i].Key))
                {
                    break;
                }
            }
            succ = (i < nodes.Length - 1) ? nodes[i + 1] : null;
            return succ;
        }

        public void Remove(K key)
        {
            TreeNode<K, V> node = Find(key);
            if (node == null)
            {
                return;
            }
            // node is a leaf
            if (node.IsLeaf)
            {
                TreeNode<K, V> parent = node.Parent;
                // node to be deleted is the root
                if (parent == null)
                {
                    _root = null;
                    return;
                }
                if (parent.Left == node)
                {
                    parent.Left = null;
                }
                else
                {
                    parent.Right = null;
                }
                node = null;
                return;
            }
            // node has a single left child
            if (node.Left != null && node.Right == null)
            {
                TreeNode<K, V> leftNode = node.Left;
                node.Key = leftNode.Key;
                node.Value = leftNode.Value;
                node.Left = leftNode.Left;
                node.Right = leftNode.Right;
                node.Left = null;
                return;
            }
            // node has a single right child
            if (node.Right != null && node.Left == null)
            {
                TreeNode<K, V> rightNode = node.Right;
                node.Key = rightNode.Key;
                node.Value = rightNode.Value;
                node.Left = rightNode.Left;
                node.Right = rightNode.Right;
                node.Right = null;
                return;
            }
            // node has two children
            if (node.Left != null && node.Right != null)
            {
                TreeNode<K, V> succ = FindNextSuccessor(node);
                if (succ == null)
                {
                    return;
                }
                node.Key = succ.Key;
                node.Value = succ.Value;
                if (succ.Parent.Left == succ)
                {
                    succ.Parent.Left = null;
                }
                else
                {
                    succ.Parent.Right = null;
                }
                succ = null;
            }
        }

        private void InorderScan(TreeNode<K, V> node, CList<K> list)
        {
            if (node == null)
            {
                return;
            }
            InorderScan(node.Left, list);
            list.Append(node.Key);
            InorderScan(node.Right, list);
        }

        private void InorderScanNodes(TreeNode<K, V> node, CList<TreeNode<K, V>> nodes)
        {
            if (node == null)
            {
                return;
            }
            InorderScanNodes(node.Left, nodes);
            nodes.Append(node);
            InorderScanNodes(node.Right, nodes);
        }

        public CList<K> Keys()
        {
            CList<K> keys = new CList<K>();
            InorderScan(_root, keys);
            return keys;
        }

        public CList<TreeNode<K, V>> Nodes()
        {
            CList<TreeNode<K, V>> nodes = new CList<TreeNode<K, V>>();
            InorderScanNodes(_root, nodes);
            return nodes;
        }

        public override string ToString()
        {
            CList<TreeNode<K, V>> nodes = Nodes();  
            return  "T:" + nodes;
        }
    }
}
