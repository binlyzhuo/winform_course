using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosePackageConsole
{
    public class VariableLengthMather
    {
        private int maxLength;

        public VariableLengthMather(int maxLength)
        {
            this.maxLength = maxLength;
        }

        public bool Math(string item)
        {
            return item.Length <= maxLength;
        }
    }
}
