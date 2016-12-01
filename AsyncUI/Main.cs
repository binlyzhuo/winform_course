using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncUI
{
    public partial class Main : Form
    {
        public delegate string MyDelegate(int ms);
        public Main()
        {
            InitializeComponent();
        }

        

        string DelegateMethod(int ms)
        {
            if (label1.InvokeRequired)
            {
                //label1.Invoke(new Delegate(MyDelegate),new []{ms});
                Invoke(new MyDelegate(DelegateMethod), new object[] {ms});
            }
            else
            {
                label1.Text = ms.ToString();
            }

            //Func<int, string> f = (num) =>
            //{
            //    return num.ToString();
            //};

            //string s = f(123);

            return ms.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Task t = DoSomethingAsync();
            //Task t = new Task(Test);
            //t.Start();

            MyDelegate myDel = AsyncMethod;
            IAsyncResult rs = myDel.BeginInvoke(10000, null, null);
            while (!rs.IsCompleted)
            {
                label1.Text = "...";
                Thread.Sleep(10);
            }

            string res = myDel.EndInvoke(rs);
            label1.Text = res;
        }

        void Test()
        {
            DelegateMethod(10);
            Thread.Sleep(5000);
            DelegateMethod(100);
        }

        string AsyncMethod(int ms)
        {
            //Thread.Sleep(ms);
            //return "Hello World!";

            //MyDelegate myDel = AsyncMethod;
            //IAsyncResult rs = myDel.BeginInvoke(5000, null, null);
            //while (!rs.IsCompleted)
            //{
            //    label1.Text = "...";
            //    Thread.Sleep(10);
            //}

            //string res = myDel.EndInvoke(rs);
            //label1.Text = res;
            Thread.Sleep(ms);
            return "Hello World!!";
        }

        async Task DoSomethingAsync()
        {
            int val = 10;
            await Task.Delay(TimeSpan.FromSeconds(1));
            val *= 2;
            await Task.Delay(TimeSpan.FromSeconds(1));
            Trace.WriteLine(val);
        }
    }
}
