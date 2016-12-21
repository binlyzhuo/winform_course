using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectMemoryInAction
{
    class Program
    {
        static void Main(string[] args)
        {
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
