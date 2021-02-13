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
            Console.WriteLine(l1);
            for (int i = 1; i <= 10; i++)
            {
                l1.Append(i);
            }
            for (int i = 0; i < l1.Length; i++)
            {
                Console.WriteLine(l1[i]);
            }
            Console.WriteLine(l1);

            CList<int> l2 = new CList<int>();
            for (int i = 11; i <= 16; i++)
            {
                l2.Append(i);
            }

            l1.Extend(l2);
            Console.WriteLine(l1);

            CList<string> l3 = new CList<string>();
            l3.Append("abcd");
            l3.Append("xyz");
            l3.Append("qwerty");

            CList<string> l4=new CList<string>(l3);
            Console.WriteLine("l3: " + l3);
            Console.WriteLine("l4: " + l4);
            l4.PopFront();
            Console.WriteLine("l3: " + l3);
            Console.WriteLine("l4: " + l4);

            l4.PushFront("michal");
            Console.WriteLine(l4);

            l2.Reverse();
            Console.WriteLine(l2);

            Console.WriteLine("Finish.");
            //Console.ReadLine();
        }

        static void Main(string[] args)
        {
            RunList();
        }
    }
}
