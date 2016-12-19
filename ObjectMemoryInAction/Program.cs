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

        public void Eat()
        {
            Console.WriteLine("Eat Pear!");
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
