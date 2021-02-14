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

            l1.Reverse();
            Console.WriteLine(l1);

          
            //Console.ReadLine();
        }

        static void Main(string[] args)
        {
            RunList();
        }
    }
}
