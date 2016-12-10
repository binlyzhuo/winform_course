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
            Application.Run(new AsyncForm());
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
    }
}
