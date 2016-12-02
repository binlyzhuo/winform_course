﻿using System;
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
            SetLabelTxt("Takes a while started!");
            Thread.Sleep(ms);
            SetLabelTxt("Takes a while completed!");
            return "Hello World!!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Task t = DoSomethingAsync();
            //Task t = new Task(Test);
            //t.Start();

            button1.Enabled = false;

            MyDelegate myDel = AsyncMethod;
            IAsyncResult rs = myDel.BeginInvoke(10000, null, null);
            while (!rs.IsCompleted)
            {
                //label1.Text = "...";
                //Thread.Sleep(10);
            }

            string res = myDel.EndInvoke(rs);
            label1.Text = res;

            BeginInvoke(new MethodInvoker(delegate()
            {
                button1.Enabled = true;
            }));
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

        private delegate void SetLabelText(string msg);

        private void SetLabelTxt(string msg)
        {
            if (label1.InvokeRequired)
            {
                Invoke(new SetLabelText(SetLabelTxt), new object[] {msg});
            }
            else
            {
                label1.Text = msg;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Task task = new Task(LoadingData);
            task.Start();
            //LoadingData();
            label1.Text = "Complete!!";
        }

        private void LoadingData()
        {
            SetLabelTxt("BEGIN!!");
            //Thread.Sleep(10000);
            SetLabelTxt("OK!!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //AsyncMethodTest();
            //SetLabelTxt("TId:"+Thread.CurrentThread.ManagedThreadId.ToString());
            label1.Text = "tid:"+Thread.CurrentThread.ManagedThreadId.ToString();
            //Thread.Sleep(4000);
            Task t = new Task(Imp3);
            t.Start();
            label1.Text = "COMPLETE!!";
        }

        void AsyncMethodTest()
        {
            label1.Text = "I am running...";
        }

        void Imp1()
        {
            MyDelegate dl = DelegateMethod;
            IAsyncResult ar = dl.BeginInvoke(5000, null, null);
            while (!ar.IsCompleted)
            {
                //SetLabelTxt("."+DateTime.Now.Millisecond);
                Thread.Sleep(1000);
                SetLabelTxt(Thread.CurrentThread.ManagedThreadId.ToString());
            }

            string rs = dl.EndInvoke(ar);

            //SetLabelTxt("result:"+rs);
        }

        void Imp2()
        {
            MyDelegate dl = DelegateMethod;
            IAsyncResult ar = dl.BeginInvoke(5000,null,null);

            while (true)
            {
                SetLabelTxt(DateTime.Now.Millisecond.ToString());
                if (ar.AsyncWaitHandle.WaitOne(50))
                {
                    SetLabelTxt("Can get the result now!");
                    break;
                }
            }

            string rs = dl.EndInvoke(ar);
            SetLabelTxt("result:"+rs);
        }

        void Imp3()
        {
            MyDelegate dl = DelegateMethod;
            dl.BeginInvoke(5000, new AsyncCallback(ar =>
            {
                string rs = dl.EndInvoke(ar);
                SetLabelTxt("result:"+rs);
                MessageBox.Show("Complete!!");
            }), null);

            for (int i = 0; i < 100; i++)
            {
                SetLabelTxt("ff"+DateTime.Now.Millisecond.ToString());
                Thread.Sleep(50);
            }
        }
    }
}