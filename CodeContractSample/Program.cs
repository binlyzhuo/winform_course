using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeContractSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //http://blog.csdn.net/zj735539703/article/details/46486777
            List<int> list = new List<int>() { 1, 2, 3, 4, 4, 5, 6, 6 };
            var newList = list.Distinct().ToList();
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
