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
            CList<int> intList = new CList<int>();
            Console.WriteLine(intList);
            for (int i = 1; i <= 10; i++)
            {
                intList.Append(i);
            }
            for (int i = 0; i < intList.Length; i++)
            {
                Console.WriteLine(intList[i]);
            }
            Console.WriteLine(intList);
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            RunList();
        }
    }
}
