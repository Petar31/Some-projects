using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Task
{
    public partial class Form1 : Form
    {
       public static List<DriveInfo> drives = new List<DriveInfo>();

        public Form1()
        {
            InitializeComponent();
           
            foreach (DriveInfo item in DriveInfo.GetDrives())
            {
                drives.Add(item);
                treeView1.Nodes.Add(item.Name);
                treeView1.NodeMouseDoubleClick += TreeView1_NodeMouseDoubleClick;
               

            }

        }

        private void TreeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Process.Start(e.Node.FullPath);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes.Count == 0 )
            {
                Nodes.AddNodes(e, treeView1);
                
            }
            Nodes.LoadNodes(e, listBox2);


            if (e.Node.Parent == null)
            {
                
                SystemObjects.DriveDetails(e, listBox1);
                comboBox1.Items.Clear();
            }

           else
            {
               
                comboBox1.Items.Clear();
                if (e.Node.GetNodeCount(true) != 0)
                {

                    SystemObjects.FolderDetails(e, listBox1);
                    SystemObjects.GetExtensions(e, comboBox1); 


                }
                else
                {

                    SystemObjects.FileDetails(e, listBox1); 
                }

            }
           

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            listBox2.Items.Clear();
            foreach (string item in Nodes.listBoxItems)
            {
                FileInfo file = new FileInfo(item);
                if (file.Extension == comboBox1.SelectedItem.ToString())
                {
                    listBox2.Items.Add(file.Name);

                }
            }

        }

      
    }
}
