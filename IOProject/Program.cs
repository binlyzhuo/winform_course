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
            Console.WriteLine("File Operation");
            FileInfo myFile = new FileInfo(@"F:\eclipse\1.txt");
            bool isExist = myFile.Exists;

            string fileName = @"F:\eclipse\new\2.txt";
            FileInfo f = new FileInfo(fileName);
            var dt = f.CreationTime;
            //myFile.MoveTo(@"F:\eclipse\new\2.txt");

            string p = Path.Combine(@"F:\eclipse\new", "2.txt");
            Console.WriteLine("IO Complete!");
            Console.ReadLine();
        }
    }
}
