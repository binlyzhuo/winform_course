using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqDemo
{
    class Program
    {
        //http://blog.jobbole.com/102901/
        static void Main(string[] args)
        {
            //var result = GetResult();
            var result = GetResultByYield();
            Console.WriteLine(result.Current);
            Console.WriteLine("遍历开始...");
            while (result.MoveNext())
            {
                Console.WriteLine(result.Current);
            }
            Console.WriteLine("遍历结束");
            Console.ReadLine();
        }

        static IEnumerator<int> GetResult()
        {
            var arr = new int[] {1, 6, 8, 12, 15};
            List<int> list = new List<int>();
            foreach (var item in arr)
            {
                list.Add(item);
            }

            return list.GetEnumerator();
        }

        static IEnumerator<int> GetResultByYield()
        {
            var arr = new int[] {1, 6, 8, 12, 15};
            foreach (var i in arr)
            {
                yield return i;
                if(i==12)
                    yield break;
            }
        }
    }
}
