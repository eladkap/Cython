using DataStructures.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMain
{
    class Program
    {
        public static void RunList()
        {
            CList<int> l1 = new CList<int>();
            for (int i = 1; i <= 4; i++)
            {
                l1.Append(i);
            }

            foreach (int x in l1)
            {
                Console.WriteLine(x);
            }
        }

        public static void RunStack()
        {
            CStack<int> s = new CStack<int>();
            for (int i = 1; i <= 3; i++)
            {
                s.Push(i);
            }
            Console.WriteLine(s);
            s.Pop();
            Console.WriteLine(s);
            s.Pop();
            Console.WriteLine(s);
            s.Pop();
            Console.WriteLine(s);
           
            Console.WriteLine(s.Size);
            Console.WriteLine(s.IsEmpty());

            //Console.ReadLine();
        }

        public static void RunArray()
        {
            CArray<string> a = new CArray<string>();
            char letter = 'A';
            for (int i = 0; i <= 10; i++)
            {
                a.PushBack(letter.ToString());
                letter++;
            }
            foreach (string l in a)
            {
                Console.WriteLine(l);
            }      
        }

        private static void Assert(bool cond)
        {
            if (!cond)
            {
                throw new Exception("AssertError");
            }
        }

        private static void RunTree()
        {
            Tree<int, int> tree = new Tree<int, int>();
            int[] values = { 12, 5, 15, 3, 7, 13, 17, 1, 9, 8, 11, 20, 18, 14 };

            foreach (var value in values) {
                tree.Insert(value, value);
            }

            int n = tree.Length;


            foreach (var value in values)
            {
                Assert(tree.Length == n);
                tree.Remove(value);
                Assert(tree.Length == n - 1);
                var keys = tree.Keys();
                int[] indices = new int[keys.Length];
                for (int i = 0; i < keys.Length - 1; i++)
                {
                    indices[i] = i;
                }
                bool isSorted = indices.All(i => keys[i] <= keys[i + 1]);
                Assert(isSorted);
                Assert(!keys.Contains(value));
                tree.Clear();
                Assert(tree.IsEmpty());
                foreach (var v in values)
                {
                    tree.Insert(v, v);
                }
            }
        }

    
        static void Main(string[] args)
        {
            //RunList();
            //RunStack();
            //RunArray();
            RunTree();
        }

        
    }
}
