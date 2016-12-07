using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileProperties
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            label1.Text = "Enter File Path";
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = File.ReadAllText(textBox1.Text);
        }
    }
}
