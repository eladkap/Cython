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

        static void Main(string[] args)
        {
            //RunList();
            //RunStack();
            RunArray();
        }
    }
}
