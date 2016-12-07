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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //File.WriteAllText(textBox1.Text,textBox2.Text);
            string[] movies = {"Grease","Close Encounter of third kind!","The day after tomorrow"};
            File.WriteAllLines("f:\\3.txt",movies);
        }
    }
}
