using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ReflectorDemo
{
    public enum Fruit
    {
        [Description("苹果")]
        Apple = 10,

        [Description("桔子")]
        Orange = 1
    }
}
