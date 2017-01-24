using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectMemoryInAction
{
    public class DisposeClass:IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Dispose called!!");
        }

        public void Close()
        {
            Console.WriteLine("Close called!!");
        }

        public DisposeClass()
        {
            Console.WriteLine("Contrunct called!!");
        }

        ~DisposeClass()
        {
            
        }
    }
}
