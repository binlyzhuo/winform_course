using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqDemo
{
    public class LambdaHelper
    {
        public static void Test()
        {
            Func<string, int> strLen = delegate(string s)
            {
                return s.Length;
            };

            Console.WriteLine(strLen("1234"));

            strLen = s => s.Length;
            Console.WriteLine(strLen("s"));
            //int len=strLen("1234");
        }
    }
}
