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
          
            Console.WriteLine("Starting Program...");
            ThreadPriorty();
            Console.ReadLine();
        }

        static void PrintNumbers()
        {
            Console.WriteLine("Starting...");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }


        static void PrintNumbersWithDelay()
        {
            Console.WriteLine("Starting...");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine(i);
            }
        }

        static void DoSomehing()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }

        static void PrintNumberWithStatus()
        {
            Console.WriteLine("Starting");
            Console.WriteLine(Thread.CurrentThread.ThreadState.ToString());

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine(i);
            }
        }

        static void ThreadStatusMethod()
        {
            Thread t = new Thread(PrintNumberWithStatus);
            Thread t2 = new Thread(DoSomehing);
            Console.WriteLine(t.ThreadState.ToString());
            t2.Start();
            t.Start();

            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine(t.ThreadState.ToString());
            }

            Thread.Sleep(TimeSpan.FromSeconds(6));
            t.Abort();
            Console.WriteLine("A thread has been aborted!");
            Console.WriteLine(t.ThreadState.ToString());
            Console.WriteLine(t2.ThreadState.ToString());
        }

        static void ThreadPriorty()
        {
            Console.WriteLine("Current thread priority :{0}",Thread.CurrentThread.Priority);
        }

        static void RunThreads()
        {
            var sample = new ThreadSample();
            var threadOne = new Thread(sample.CountNumber);
            threadOne.Name = "ThreadOne";
        }
    }
}
