using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqDemo
{
    //http://blog.jobbole.com/86638/
    public class Person
    {
        public string Name { set; get; }
        public int Age { set; get; }

        //
        public bool Gender { set; get; }
    }

    public class Student:Person
    {
        
    }
}
