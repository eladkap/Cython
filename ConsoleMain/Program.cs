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
            for (int i = 0; i <= 9; i++)
            {
                l1.Append(i);
            }
            Console.WriteLine(l1.Count(1));
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

        static void Main(string[] args)
        {
            //RunList();
            RunStack();
        }
    }
}
