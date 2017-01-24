using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectMemoryInAction
{
    //http://www.cnblogs.com/worfdream/articles/2345053.html
    class Program
    {
        static void Main(string[] args)
        {
            //DisposeClass ps = new DisposeClass();
            using (DisposeClass ps = new DisposeClass())
            {

            }
            Console.ReadLine();
        }
    }

    public class Person
    {
        public int Id;
        public Nullable<DateTime> endData;

        public void Eat()
        {
            Console.WriteLine("Eat Pear!");
            endData = null;
        }
    }

    public class Student : Person
    {
        public int studentId;

        public void GotoSchool()
        {
            Console.WriteLine("Go to school");
        }
    }
}
