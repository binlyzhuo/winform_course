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
            ListUtil.Execute();
            Console.ReadLine();
        }
    }
}
