using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(PrintNumbers);
            t.Start();
            PrintNumbers();
            Console.WriteLine();
        }

        static void PrintNumbers()
        {
            Console.WriteLine("Starting...");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
