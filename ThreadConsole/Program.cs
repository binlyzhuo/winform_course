using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadConsole
{
    class Program
    {
        static void Main(string[] args)
        {
          
            Console.WriteLine("Starting Program...");
            //ThreadPriorty();
            //AsyncTest();
            CallerWithAync();
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
            Console.WriteLine("Running on all cores avaiable");
            RunThreads();

            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("Running on a single core");
            Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(1);
            RunThreads();
        }

        static void RunThreads()
        {
            var sample = new ThreadSample();
            var threadOne = new Thread(sample.CountNumber);
            threadOne.Name = "ThreadOne";

            var threadTwo = new Thread(sample.CountNumber);
            threadTwo.Name = "ThreadTwo";

            threadOne.Priority = ThreadPriority.Highest;
            threadTwo.Priority = ThreadPriority.Lowest;

            threadOne.Start();
            threadTwo.Start();

            Thread.Sleep(TimeSpan.FromSeconds(2));
            sample.Stop();
        }


        static async Task<int> MyMethod()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("异步执行"+i.ToString()+"..");
                await TaskEx.Delay(1000);
            }

            return 0;
        }

        static async void AsyncMethod()
        {
            Console.WriteLine("开始异步代码");
            var rs = await MyMethod();
            Console.WriteLine("异步代码执行完毕");
        }

        static void AsyncTest()
        {
            Console.WriteLine("主线程测试开始");
            AsyncMethod();
            Thread.Sleep(1000);
            Console.WriteLine("主线程测试完毕");
            
        }

        static string Greeting(string name)
        {
            Thread.Sleep(3000);
            return string.Format("Hello,{0}",name);
        }

        static Task<string> GreetingAync(string name)
        {
            return TaskEx.Run<string>(() =>
            {
                return Greeting(name);
            });
        }

        async static void CallerWithAync()
        {
            string result = await GreetingAync("Bin");
            Console.WriteLine(result);
        }
    }
}
