using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 委托
{
    delegate Boolean moreOrlessDelgate(int item);
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            var d1 = new moreOrlessDelgate(More);
            Print(arr, d1);
            Console.WriteLine("OK");

            var d2 = new moreOrlessDelgate(Less);
            Print(arr, d2);
            Console.WriteLine("OK");
            Console.ReadKey();
        }
        static void Print(List<int> arr, moreOrlessDelgate dl)
        {
            foreach (var item in arr)
            {
                if (dl(item))
                {
                    Console.WriteLine(item);
                }
            }
        }
        static bool More(int item)
        {
            if (item > 3)
            {
                return true;
            }
            return false;
        }
        static bool Less(int item)
        {
            if (item < 3)
            {
                return true;
            }
            return false;
        }


    }
}
