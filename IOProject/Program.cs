using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace IOProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //http://www.cnblogs.com/webhome/p/6164139.html
            Guid g = default(Guid);

            StringLength();

            Console.WriteLine("IO Complete!");
            Console.ReadLine();
        }

        static void FileStreamDemo()
        {
            FileStream fs = new FileStream("f:\\1.doc", FileMode.Create);
            int nextByte = fs.ReadByte();
            FileStream fs2 = new FileStream("f:\\3.doc", FileMode.Create, FileAccess.Write);
        }

        static void StringLength()
        {
            string strTemp = "wk张三";
            int i = System.Text.Encoding.Default.GetBytes(strTemp).Length;
            int j = strTemp.Length;
            Console.WriteLine("字符串:{0},算汉字的长度:{1},不算汉字长度:{2}", strTemp, i, j);

            byte[] byteStr = System.Text.Encoding.Default.GetBytes(strTemp);
            int len = byteStr.Length;
            Console.WriteLine("字符串长度:{0}", len);

            int zhCount = CheckGBKLen(strTemp);
            Console.WriteLine("汉字个数:{0}",zhCount);
        }

        static int CheckGBKLen(string str)
        {
            System.Text.ASCIIEncoding n = new ASCIIEncoding();
            byte[] b = n.GetBytes(str);

            byte[] d = System.Text.Encoding.UTF8.GetBytes(str);

            int l = 0;
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] == 63)
                {
                    l++;
                }
            }

            return l;
        }
    }
}
