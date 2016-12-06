using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOProject
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple = false,Inherited = false)]
    public class FieldNameAttribute:Attribute
    {
        private string name;

        public FieldNameAttribute(string name)
        {
            this.name = name;
        }
    }
}
