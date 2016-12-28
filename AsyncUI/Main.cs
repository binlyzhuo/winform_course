using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
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
			//THINKING!!
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

        private void button4_Click(object sender, EventArgs e)
        {
            Thread t1 = new Thread(ThreadMethod1);
            Thread t2 = new Thread(ThreadMetod2);

            t1.Start();
            t2.Start();
        }

        void ThreadMethod1()
        {
            for (int i = 0; i < 20; i++)
            {
                SetLabelTxt("Thread 1 is running");
                Thread.Sleep(50);
            }
        }

        void ThreadMetod2()
        {
            for (int i = 0; i < 20; i++)
            {
                SetLabelTxt("Thread 2 is running");
                Thread.Sleep(50);
            }
        }

        void ThreadMethod3(object param)
        {
            ThreadData data = (ThreadData)param;
            for (int i = 0; i < 20; i++)
            {
                SetLabelTxt(i.ToString()+"Thread 3 is running,Message:"+data.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(ThreadMethod3);
            t.IsBackground = true;
            t.Start(new ThreadData() {Message = "Hello World!!"});
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                ThreadPool.UnsafeQueueUserWorkItem(WaitCallBackMethod, i);
            }
        }

        void WaitCallBackMethod(object param)
        {
            for (int i = 0; i < 5; i++)
            {
                SetLabelTxt(string.Format("Thread {0} is running",param));
                Thread.Sleep(1000);
            }
        }

        void MaxThreads()
        {
            int workerThreads;
            int ioThreads;

            ThreadPool.GetMaxThreads(out workerThreads,out ioThreads);
            ThreadPool.GetMinThreads(out workerThreads,out ioThreads);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Task t = new Task(TaskMwthodWithParameter,"Hello World!!");
            //t.Start();

            TaskFactory f = new TaskFactory();
            f.StartNew(TaskMethod);

            Task.Factory.StartNew(TaskMwthodWithParameter, "OK");

            for (int i = 0; i < 10; i++)
            {
                SetLabelTxt("Running in main thread!!");
            }
        }

        void TaskMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                SetLabelTxt(string.Format("Running in a task.TaskID is {0}",Task.CurrentId));
                Thread.Sleep(500);
            }
        }

        void TaskMwthodWithParameter(object param)
        {
            for (int i = 0; i < 10; i++)
            {
                SetLabelTxt(string.Format("Running in a task.TaskID is {0},Param is {1}", Task.CurrentId,param));
                Thread.Sleep(500);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Task t1 = new Task(FirstTaskMethod);
            Task t2 = t1.ContinueWith(SecondTaskMethod,TaskContinuationOptions.OnlyOnRanToCompletion);
            t1.Start();

            for (int i = 0; i < 20; i++)
            {
                SetLabelTxt("Main thread is running...");
                Thread.Sleep(200);
            }
        }

        void FirstTaskMethod()
        {
            SetLabelTxt(string.Format("Task {0} is doing something.",Task.CurrentId));
            Thread.Sleep(20);
        }

        void SecondTaskMethod(Task task)
        {
            SetLabelTxt("Last task is finished!");
            Thread.Sleep(200);
            SetLabelTxt(string.Format("Task {0} is doing something.", Task.CurrentId));
            Thread.Sleep(20);
        }

        private async void asyncBtn_Click(object sender, EventArgs e)
        {
            //int length = await AccessTheWebAsync();
            //label1.Text = "length:"+length;

            label1.Text = "Loading";
            await Task.Delay(2000);
            label1.Text = "Loading Complete!!";
        }

        async Task<int> AccessTheWebAsync()
        {
            //https://www.zhihu.com/question/30601778
            HttpClient client = new HttpClient();
            string urlContent = await client.GetStringAsync("http://www.baidu.com");
            
            return urlContent.Length;
        }
    }

    struct ThreadData
    {
        public string Message;
    }
}
