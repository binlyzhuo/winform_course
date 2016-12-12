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

            Console.WriteLine("File Operation");
            FileInfo myFile = new FileInfo(@"F:\eclipse\1.txt");
            bool isExist = myFile.Exists;

            string fileName = @"F:\eclipse\new\2.txt";
            FileInfo f = new FileInfo(fileName);
            var dt = f.CreationTime;
            //myFile.MoveTo(@"F:\eclipse\new\2.txt");

            string p = Path.Combine(@"F:\eclipse\new", "2.txt");

            FileStreamDemo();
            Console.WriteLine("IO Complete!");
            Console.ReadLine();
        }

        static void FileStreamDemo()
        {
            FileStream fs = new FileStream("f:\\1.doc", FileMode.Create);
            int nextByte = fs.ReadByte();
            FileStream fs2 = new FileStream("f:\\3.doc", FileMode.Create, FileAccess.Write);
        }
    }
}
