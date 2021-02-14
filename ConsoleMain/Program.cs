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
            for (int i = 3; i <= 9; i++)
            {
                l1.Append(i);
            }
            Console.WriteLine(l1.Hash());

            CList<string> l2 = new CList<string>();
            l2.Append("a");
            l2.Append("b");
            l2.Append("c");
            
            l2.Append("x");
            l2.Append("y");
            l2.Append("z");
            Console.WriteLine(l2.Hash());
            //Console.ReadLine();
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
            for (int i = 0; i < 12; i++)
            {
                a.PushBack(letter.ToString());
                letter++;
            }
            Console.WriteLine(a);
            a.Reverse();
            Console.WriteLine(a);
            a.Sort();
            Console.WriteLine(a);
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }
            a[0] = "Z";
            Console.WriteLine(a);

            CArray<string> b = new CArray<string>();
            letter = 'Q';
            for (int i = 0; i < 5; i++)
            {
                b.PushBack(letter.ToString());
                letter++;
            }

            a.Extend(b);
            Console.WriteLine(a);

            Console.WriteLine(a);
            a.Shuffle();
            Console.WriteLine(a);
            a.Sort();
            Console.WriteLine(a);

            b = new CArray<string>(a);
            Console.WriteLine(b);
            Console.WriteLine(a.Equals(b));
            b.PopBack();
            Console.WriteLine(b);
            b.PopFront();
            Console.WriteLine(b);
            a[3] = "Z";
            Console.WriteLine(a);
            Console.WriteLine(a.Count("A"));
            Console.WriteLine(a.Count("Z"));
            Console.WriteLine(a.Find("A"));
            Console.WriteLine(a.Find("Z"));
        }

        static void Main(string[] args)
        {
            //RunList();
            //RunStack();
            RunArray();
        }
    }
}
