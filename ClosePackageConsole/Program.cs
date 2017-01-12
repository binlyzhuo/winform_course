using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosePackageConsole
{
    class Program
    {
        //http://blog.jobbole.com/102772/
        static void Main(string[] args)
        {
            Console.WriteLine("Close package in C#!");
            //ListUtil.Execute();
            Console.WriteLine("Maximum length of string to include?");
            int maxLength = int.Parse(Console.ReadLine());
            VariableLengthMather mather = new VariableLengthMather(maxLength);
            Predicate<string> predicate = mather.Math;
            IList<string> shortWords = ListUtil.Filter(ListUtil.SampleData(), predicate);
            //ListUtil.Dump(shortWords);

            Console.WriteLine("Now for words with:");
            maxLength = 5;
            shortWords = ListUtil.Filter(ListUtil.SampleData(), predicate);
            //ListUtil.Dump(shortWords);

            string name = "cnblogs";
            Func<string> capture = () => name;
            //Print(capture);
            name = "bin";
            Print(capture);

            List<Func<int>> funcs = new List<Func<int>>();
            for (int j = 0; j < 10; j++)
            {
                int tempJ = j;
                funcs.Add(()=>tempJ);
            }

            foreach (var func in funcs)
            {
                Console.WriteLine(func());
            }
            Console.ReadLine();
        }

        static void Print(Func<string> f)
        {
            Console.WriteLine(f());
        }
    }
}
