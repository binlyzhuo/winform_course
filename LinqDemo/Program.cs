using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqDemo
{
    class Program
    {
        //http://blog.jobbole.com/102901/
        //http://blog.jobbole.com/102770/
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

            var list = GetList();
            list.ForEach(new Action<Person>(delegate(Person p)
            {
                Console.WriteLine(p.Name);
            }));

            list.ForEach(delegate(Person p)
            {
                Console.WriteLine(p.Name);
            });

            var lsGet = list.Find(delegate(Person p)
            {
                return p.Age == 10;
            });

            var lsGet2 = list.Find(d => d.Gender);

            list.ForEach(u=>Console.WriteLine(u.Name));
            Console.ReadLine();
        }

        static IEnumerator<int> GetResult()
        {
            var arr = new int[] { 1, 6, 8, 12, 15 };
            List<int> list = new List<int>();
            foreach (var item in arr)
            {
                list.Add(item);
            }

            return list.GetEnumerator();
        }

        static IEnumerator<int> GetResultByYield()
        {
            var arr = new int[] { 1, 6, 8, 12, 15 };
            foreach (var i in arr)
            {
                yield return i;
                if (i == 12)
                    yield break;
            }
        }

        static List<Person> GetList()
        {
            List<Person> list = new List<Person>()
            {
                new Person(){ Name = "A", Age = 10, Gender = true},
                new Person(){ Name = "B", Age = 15, Gender = true},
                new Person(){ Name = "C", Age = 30, Gender = true}
            };

            return list;
        }
    }
}
