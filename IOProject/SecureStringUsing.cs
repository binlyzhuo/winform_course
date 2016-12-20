using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace IOProject
{
    public class SecureStringUsing
    {
        public unsafe static void PrintSrecureString(SecureString ss)
        {
            char* buffer = null;

            try
            {
                buffer = (char*)Marshal.SecureStringToCoTaskMemUnicode(ss);
                for (int i = 0; *(buffer + i) != ' '; i++)
                {
                    Console.WriteLine(*(buffer+i));
                }
            }
            catch
            {
            }
            finally
            {
                if (buffer != null)
                {
                    Marshal.ZeroFreeCoTaskMemUnicode((System.IntPtr)buffer);
                }
            }
        }
    }
}
