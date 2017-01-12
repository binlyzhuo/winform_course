using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosePackageConsole
{
    public class ListUtil
    {
        public static IList<string> Filter(IList<string> source, Predicate<string> predicate)
        {
            List<string> list = new List<string>();
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    list.Add(item);
                }
                
            }
            return list;
        }

        public static void Dump<T>(IList<T> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        public static IList<string> SampleData()
        {
            return new List<string>()
            {
                "the", "quick", "brown", "fox", "jumped",
             "over", "the", "lazy", "dog"
            };
        }

        public static bool MathFourLetterOrFewer(string item)
        {
            return item.Length <= 4;
        }

        public static void Execute()
        {
            Predicate<string> predicate = new Predicate<string>(MathFourLetterOrFewer);
            Predicate<string> predicate2 = u => u.Length <= 4;
            IList<string> shortWords = Filter(SampleData(), predicate2);
            Dump(shortWords);

        }
    }
}
