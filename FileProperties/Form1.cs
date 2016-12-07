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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            label1.Text = "Enter name of folder to be examined and click display";
            label2.Text = "Content of folder";
            label3.Text = "Files";
            label4.Text = "Folders";

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string folderPath = tbInput.Text;
            DirectoryInfo theFolder = new DirectoryInfo(folderPath);
            if (theFolder.Exists)
            {
                DisplayFolderList(theFolder.FullName);
            }
        }

        private void DisplayFolderList(string folderFullName)
        {
            DirectoryInfo theFolder = new DirectoryInfo(folderFullName);
            if (!theFolder.Exists)
            {
                throw new DirectoryNotFoundException("Folder not found:"+folderFullName);
            }

            foreach (var nextFolder in theFolder.GetDirectories())
            {
                lsFolders.Items.Add(nextFolder.Name);
            }

            foreach (var nextFile in theFolder.GetFiles())
            {
                lsFiles.Items.Add(nextFile.Name);
            }
        }
    }
}
