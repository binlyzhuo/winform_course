using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadConsole
{
    public class ThreadSample
    {
        private bool _isStopped = false;

        public void Stop()
        {
            _isStopped = true;
        }

        public void CountNumber()
        {
            long counter = 0;
            while (_isStopped)
            {
                counter++;
            }

            Console.WriteLine("{0} with {1,11} " +
                              "priority has a count={2,3}",
                              Thread.CurrentThread.Name,
                              Thread.CurrentThread.Priority,
                              counter.ToString("N0"));
        }
    }
}
