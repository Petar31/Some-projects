using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task
{
    class Nodes
    {
        public static List<string> listBoxItems = new List<string>();

        public static void AddNodes(TreeViewEventArgs e, TreeView treeView1)
        {
            DirectoryInfo directory = new DirectoryInfo(e.Node.FullPath);
            
            try
            {
                
                string[] dir = Directory.GetDirectories(directory.ToString());
                string[] files = Directory.GetFiles(directory.ToString());

                foreach (var item in dir)
                {
                   
                        treeView1.SelectedNode.Nodes.Add(item.Remove(0, item.LastIndexOf('\\') + 1));

                }

                foreach (var item in files)
                {
                   
                        treeView1.SelectedNode.Nodes.Add(item.Remove(0, item.LastIndexOf('\\') + 1));
                   
                    
                }
            }
            catch (Exception)
            {
             
            }
        }

        public static void LoadNodes(TreeViewEventArgs e, ListBox listBox)
        {
            listBox.Items.Clear();
            foreach (TreeNode item in e.Node.Nodes)
            {
                listBox.Items.Add(item.Text);
                if (!listBoxItems.Contains(item.Text))
                {
                    listBoxItems.Add(item.Text);
                }
                
            }

        }
    }
}
