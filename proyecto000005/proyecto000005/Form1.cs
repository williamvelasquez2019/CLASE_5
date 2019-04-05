﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace proyecto000005
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            DriveInfo[] u = DriveInfo.GetDrives();
           
            foreach (DriveInfo unidad in u)
            {
                try
                {
                    listBox1.Items.Add(unidad.Name);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("error de lectura"+ex.Message);
                }

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            string unidades =listBox1.SelectedItem.ToString();
            DriveInfo d = new DriveInfo(unidades);
            listBox2.Items.Add("disco "+ d.Name + "\n");

            if (d.IsReady){
                listBox2.Items.Add("espacio ocupado (GB) :"+(d.TotalSize - d.AvailableFreeSpace / 1024/1024/1024 + "\n"));
                listBox2.Items.Add("espacio ocupado (GB) :"+(d.TotalFreeSpace)/ 1024/1024/1024 +"\n");
                listBox2.Items.Add("espacio total (GB) :"+(d.TotalSize)/1024/1024/1024+"\n");
            }
            listBox2.Items.Add("tipo de disco utilizado"+d.DriveType.ToString()+"\n");
            treeView1.Nodes.Clear();
            if (d.IsReady)
            {
                DirectoryInfo dir = new DirectoryInfo(unidades);
                treeView1.Nodes.
            }

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
