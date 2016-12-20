using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IOProject
{
    public class FileStreamAction
    {
        private const int bufferLength = 1024;

        public static void Test()
        {
            string fileName = "d:\\TestStream.txt";
            string fileContent = GetTestString();
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(fileContent);
                fs.Write(bytes,0,bytes.Length);
            }
        }

        static string GetTestString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                builder.Append("我是测试数据\r\n");
                builder.AppendFormat("我是长江{0}号\r\n", i + 1);
            }

            return builder.ToString();
        }
    }


}
