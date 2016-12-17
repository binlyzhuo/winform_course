using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncForm
{
    class Program
    {
        static void Main(string[] args)
        {
            //Application.Run(new AsyncForm());
            PrintPageLength();
            Console.ReadLine();
        }

        static async Task<int> GetPageLengthAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                Task<string> fetchNextTask = client.GetStringAsync(url);
                int length = (await fetchNextTask).Length;
                return length;
            }
        }

        static void PrintPageLength()
        {
            Task<int> lengthTask = GetPageLengthAsync("Http://www.baidu.com");
            Console.WriteLine(lengthTask.Result);
        }
    }

    class AsyncForm : Form
    {
        private Label label;
        private Button button;

        public AsyncForm()
        {
            label = new Label()
            {
                Location = new Point(10,20),Text = "Length"
            };

            button = new Button()
            {
                Location =  new Point(10,50),Text = "Click"
            };

            button.Click += DisplayWebSiteLength;

            AutoSize = true;
            Controls.Add(label);
            Controls.Add(button);
        }

        async void DisplayWebSiteLength(object sender, EventArgs args)
        {
            label.Text = "Fetching...";
            using (HttpClient client = new HttpClient())
            {
                string text = await client.GetStringAsync("Http://www.baidu.com");
                label.Text = text.Length.ToString();
            }
        }

        async void DisplayWebSiteLength2(object sender, EventArgs args)
        {
            label.Text = "Fetching.....";
            using (HttpClient client = new HttpClient())
            {
                Task<string> task = client.GetStringAsync("http://www.baidu.com");
                string text = await task;
                label.Text = text.Length.ToString();
            }
        }

        
    }
}
