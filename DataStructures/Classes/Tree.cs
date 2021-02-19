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
        //private int _level;
        //private int _hash;

        public TreeNode(K key, V value)
        {
            _key = key;
            _value = value;
            _left = null;
            _right = null;
            _parent = null;
            //_level = level;
            //_hash = key.GetHashCode();
        }

        public TreeNode() : this(default(K), default(V))
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

        //public int Level { get => _level; }

        //public int Hash { get => _hash; }

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
            string parentKey = (_parent != null) ? _parent._key.ToString() : "-";
            if (_left != null && _right != null) {
                return string.Join(", ", new string[] { _key.ToString(), _left._key.ToString(), _right._key.ToString(), parentKey });
            }
            if (_left != null)
            {
                return string.Join(", ", new string[] { _key.ToString(), _left._key.ToString(), "-", parentKey });
            }
            if (_right != null)
            {
                return string.Join(", ", new string[] { _key.ToString(), "-", _right._key.ToString(), parentKey });
            }
            return string.Join(", ", new string[] { _key.ToString(), "-", "-", parentKey });
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

        public void Insert(K key, V value)
        {
            if (_root == null)
            {
                _root = new TreeNode<K, V>(key, value);
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
            //int level = node.Level + 1;
            TreeNode<K, V> newNode = new TreeNode<K, V>(key, value);
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

        public bool IsEmpty()
        {
            return _root == null && _length == 0;
        }

        private void RemoveNodeWithoutTwoChildren(TreeNode<K, V> nodeToRemove)
        {
            //node is leaf
            if (nodeToRemove.IsLeaf)
            {
                if (nodeToRemove == _root)
                {
                    _root = null;
                    _length--;
                }
                else
                {
                    var parent = nodeToRemove.Parent;
                    if (parent.Left == nodeToRemove)
                    {
                        parent.Left = null;
                    }
                    else
                    {
                        parent.Right = null;
                    }
                    nodeToRemove = null;
                    _length--;
                    return;
                }
            }

            // node has only left child
            if (nodeToRemove.Left != null)
            {
                var leftNode = nodeToRemove.Left;
                var parent = nodeToRemove.Parent;
                if (parent.Left == nodeToRemove)
                {
                    parent.Left = leftNode;
                }
                else
                {
                    parent.Right = leftNode;
                }
                nodeToRemove = null;
                _length--;
                return;
            }

            // node has only right child
            if (nodeToRemove.Right != null)
            {
                var rightNode = nodeToRemove.Right;
                var parent = nodeToRemove.Parent;
                if (parent.Left == nodeToRemove)
                {
                    parent.Left = rightNode;
                }
                else
                {
                    parent.Right = rightNode;
                }
                nodeToRemove = null;
                _length--;
                return;
            }          
        }

        private TreeNode<K,V> FindMaxInLeftSubTree(TreeNode<K,V> node)
        {
            if (node.Left == null)
            {
                return node;
            }
            var maxNode = node.Left;
            while (maxNode.Right != null)
            {
                maxNode = maxNode.Right;
            }
            return maxNode;
        }

        public void Remove(K key)
        {
            TreeNode<K, V> nodeToRemove = Find(key);
            if (nodeToRemove == null)
            {
                return;
            }
            // node has no two children
            if  (!(nodeToRemove.Left != null && nodeToRemove.Right != null))
            {
                RemoveNodeWithoutTwoChildren(nodeToRemove);
                return;
            }

            // node has both left and right children
            // find max in left-subtree
            var maxNode = FindMaxInLeftSubTree(nodeToRemove);
            nodeToRemove.Key = maxNode.Key;
            nodeToRemove.Value = maxNode.Value;

            // Delete duplicate from left-subtree (this node does not have right child for sure)
            RemoveNodeWithoutTwoChildren(maxNode);
        }

        private void InorderScan(TreeNode<K, V> node, CList<TreeNode<K, V>> nodes)
        {
            if (node == null)
            {
                return;
            }
            InorderScan(node.Left, nodes);
            nodes.Append(node);
            InorderScan(node.Right, nodes);
        }

        private CList<Tuple<TreeNode<K, V>, int>> LevelOrderScan()
        {
            CList<Tuple<TreeNode<K, V>, int>> items = new CList<Tuple<TreeNode<K, V>, int>>();
            if (_root == null)
            {
                return items;
            }
            CQueue<Tuple<TreeNode<K, V>, int>> queue = new CQueue<Tuple<TreeNode<K, V>, int>>();
            queue.Enqueue(new Tuple<TreeNode<K, V>, int>(_root, 0));
            while (queue.Size > 0)
            {
                var item = queue.Dequeue();
                var node = item.Item1;
                var level = item.Item2;
                items.Append(item);
                if (node.Left != null)
                {
                    queue.Enqueue(new Tuple<TreeNode<K, V>, int>(node.Left, level + 1));
                }
                if (node.Right != null){
                    queue.Enqueue(new Tuple<TreeNode<K, V>, int>(node.Right, level + 1));
                }
            }
            return items;
        }

        public CList<K> Keys()
        {
            CList<TreeNode<K, V>> nodes = new CList<TreeNode<K, V>>();
            InorderScan(_root, nodes);
            CList<K> keys = new CList<K>();
            foreach (var node in nodes)
            {
                keys.Append(node.Key);
            }
            return keys;
        }

        public CList<TreeNode<K, V>> Nodes()
        {
            CList<TreeNode<K, V>> nodes = new CList<TreeNode<K, V>>();
            InorderScan(_root, nodes);
            return nodes;
        }

        public override string ToString()
        {
            var items = LevelOrderScan();
            string[] results = new string[items.Length];
            for (int i =0; i < items.Length; i++)
            {
                var item = items[i];
                results[i] = "(" + item.Item1.ToString() + ", " + item.Item2.ToString() + ")";
            }
            string s = "[" + string.Join(", ", results) + "]";
            return s;
        }
    }
}
