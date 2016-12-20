using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.SqlServer.Server;

namespace IOProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //http://www.cnblogs.com/webhome/p/6164139.html
            //http://blog.jobbole.com/92815/
            Guid g = default(Guid);
            //StringLength();
            StringEncode();

            StringInMemoryCache();
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

            char ch = 'A';
            int ascII = ch;
            char email = (char)64;


            Console.WriteLine(email);
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

        static void StringEncode()
        {
            string s = "我是字符串，I am a string!";
            byte[] utf8 = StringToByte(s,Encoding.UTF8);
            byte[] gb2312 = StringToByte(s, Encoding.GetEncoding("GB2312"));
            byte[] unicode = StringToByte(s, Encoding.Unicode);

            Console.WriteLine(utf8.Length);
            Console.WriteLine(gb2312.Length);
            Console.WriteLine(unicode.Length);

            Console.WriteLine(ByteToString(utf8,Encoding.UTF8));
            Console.WriteLine(ByteToString(gb2312,Encoding.GetEncoding("GB2312")));
            Console.WriteLine(ByteToString(unicode,Encoding.Unicode));


            string test = "abc";
            byte[] bytes = Encoding.UTF8.GetBytes(test);
            string base64 = BytesToBase64(bytes);
            Console.WriteLine(base64);

            bytes = Base64ToBytes(base64);
            Console.WriteLine(Encoding.UTF8.GetString(bytes));

        }

        static byte[] StringToByte(string str, Encoding encoding)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }

            return encoding.GetBytes(str);
        }

        static string ByteToString(byte[] bytes, Encoding encoding)
        {
            if (bytes == null || bytes.Length == 0)
            {
                return string.Empty;
            }

            return encoding.GetString(bytes);
        }

        static string BytesToBase64(byte[] bytes)
        {
            try
            {
                return Convert.ToBase64String(bytes);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        static byte[] Base64ToBytes(string base64)
        {
            try
            {
                return Convert.FromBase64String(base64);
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        static void StringInMemoryCache()
        {
            string a = "abcde";
            string b = "abcde";

            Console.WriteLine(object.ReferenceEquals(a,b));

            string c = "a" + "bc" + "de";
            Console.WriteLine(object.ReferenceEquals(a,c));

            char[] arr = {'a','b','c','d','e'};
            string d = new string(arr);
            Console.WriteLine(object.ReferenceEquals(a,d));
        }
    }
}
