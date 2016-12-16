using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqDemo
{
    public static class LinqHelper
    {
        public static List<T> SelfDefineFindAll<T>(this List<T> list, Predicate<T> pre)
            where T : class
        {
            List<T> preList = new List<T>();
            foreach (T t in list)
            {
                if (pre(t))
                {
                    preList.Add(t);
                }
            }

            return preList;
        }
    }
}
