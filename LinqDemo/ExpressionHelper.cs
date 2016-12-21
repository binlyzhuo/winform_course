using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LinqDemo
{
    public class ExpressionHelper
    {
        public static void Test()
        {
            Expression numA = Expression.Constant(6);
            Console.WriteLine("NodeType:{0},Type:{1}",numA.NodeType,numA.Type);
        }
    }
}
