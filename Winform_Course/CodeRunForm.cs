using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Winform_Course
{
    public partial class CodeRunForm : Form
    {
        public CodeRunForm()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            var driver = new CodeDriver();
            bool isError = false;
            txtResult.Text = driver.CompileAndRun(txtSource.Text, out isError);
            
        }
    }
}
