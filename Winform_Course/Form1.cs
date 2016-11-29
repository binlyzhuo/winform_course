using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Winform_Course
{
    public partial class Form1 : Form
    {
        DataTable table;
        private int currentIndex = 0;
        private int max = 10000;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            btnOK.Enabled = false;
            Thread thread = new Thread(new ThreadStart(LoadData));
            thread.Start();

            progressBar1.Minimum = 0;
            progressBar1.Maximum = max;
        }

        private void LoadData()
        {
            //label1.Text = "loading";
            SetLabelText("数据加载中......");
            currentIndex = 1;
            table = new DataTable();
            table.Columns.Add("id");
            table.Columns.Add("name");
            table.Columns.Add("age");

            while (currentIndex<max)
            {
                decimal completed = Convert.ToDecimal(currentIndex)/Convert.ToDecimal(max)*100;
                SetLabelText(string.Format("当前行:{0},剩余量:{1},完成比例:{2}",currentIndex,max-currentIndex,completed));
                SetPbValue(currentIndex);

                DataRow dr = table.NewRow();
                dr["id"] = currentIndex;
                dr["name"] = "张三";
                dr["age"] = currentIndex + 5;
                table.Rows.Add(dr);
                currentIndex++;
            }

            SetDgvDataSource(table);
            SetLabelText("数据加载完成");

            Action action = new Action(delegate()
            {
                btnOK.Enabled = true;
            });

            //btnOK.Enabled = true;
            //var async= BeginInvoke(new MethodInvoker(delegate()
            //{
            //    btnOK.Enabled = true;
            //}));
            //var obj=Invoke(action);
            var async = BeginInvoke(action);
            while (async.IsCompleted==false)
            {
                
            }

            object asyncResult = EndInvoke(async);
        }

        private delegate void labDelegate(string str);

        private void SetLabelText(string str)
        {
            if (label1.InvokeRequired)
            {
                Invoke(new labDelegate(SetLabelText), new object[] {str});
            }
            else
            {
                label1.Text = str;
            }
        }

        private delegate void pbDelegate(int value);

        private void SetPbValue(int value)
        {
            if (progressBar1.InvokeRequired)
            {
                Invoke(new pbDelegate(SetPbValue),new object[] {value});
            }
            else
            {
                progressBar1.Value = value;
            }
        }

        private delegate void dgvDelegate(DataTable table);

        private void SetDgvDataSource(DataTable table)
        {
            if (dataGridView1.InvokeRequired)
            {
                Invoke(new dgvDelegate(SetDgvDataSource),new object[] {table});
            }
            else
            {
                dataGridView1.DataSource = table;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CodeRunForm f = new CodeRunForm();
            f.ShowDialog();
        }
    }
}
