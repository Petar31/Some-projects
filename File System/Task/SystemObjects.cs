using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task
{
    class SystemObjects
    {
        public static void DriveDetails(TreeViewEventArgs e, ListBox listBox1)
        {
            listBox1.Items.Clear();
            foreach (var item in Form1.drives)
            {
                if (item.Name == e.Node.Text)
                {
                    listBox1.Items.Add("Drive letter : " + item.Name.Substring(0, 1));
                    listBox1.Items.Add("Drive name : " + item.Name);
                    if (item.IsReady)
                    {
                        listBox1.Items.Add("Free space : " + item.TotalFreeSpace + " bytes");
                        listBox1.Items.Add("Total size : " + item.TotalSize + " bytes");
                    }

                }


            }
        }

        public static void FolderDetails(TreeViewEventArgs e, ListBox listBox1)
        {
            try
            {
                listBox1.Items.Clear();
                DirectoryInfo directory = new DirectoryInfo(e.Node.FullPath);
                listBox1.Items.Add("Folder Name : " + directory.Name);
                listBox1.Items.Add("Number of files in folder : " + directory.GetFiles().Count());
                listBox1.Items.Add($"Folder attributes : ");
                listBox1.Items.Add($"Archive : { IsArchive(directory.FullName)}");
                listBox1.Items.Add($"Read only : {directory.Attributes.HasFlag(FileAttributes.ReadOnly)}");
                listBox1.Items.Add($"Hidden : {directory.Attributes.HasFlag(FileAttributes.Hidden)}");
                listBox1.Items.Add($"System : {directory.Attributes.HasFlag(FileAttributes.System)}");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }


        public static void FileDetails(TreeViewEventArgs e, ListBox listBox1)
        {
            try
            {
                listBox1.Items.Clear();
                FileInfo file = new FileInfo(e.Node.FullPath);
                listBox1.Items.Add("File name : " + file.Name);
                listBox1.Items.Add($"File size : {file.Length} bytes");
                listBox1.Items.Add($"File attributes : ");
                listBox1.Items.Add($"Archive : { IsArchive(file.FullName)}");
                listBox1.Items.Add($"Read only : {file.Attributes.HasFlag(FileAttributes.ReadOnly)}");
                listBox1.Items.Add($"Hidden : {file.Attributes.HasFlag(FileAttributes.Hidden)}");
                listBox1.Items.Add($"System : {file.Attributes.HasFlag(FileAttributes.System)}");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }


        private static bool IsArchive(string fileOrFolder)
        {
            string extension = fileOrFolder.Substring(fileOrFolder.Length - 4);

            if (extension == ".zip" || extension == ".rar")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void GetExtensions(TreeViewEventArgs e, ComboBox comboBox1)
        {
            DirectoryInfo directory = new DirectoryInfo(e.Node.FullPath);
            FileInfo[] files = directory.GetFiles();

            if (files.Count() != 0)
            {
                List<string> extensions = new List<string>();
                foreach (var item in files)
                {
                    extensions.Add(item.Extension);
                }
                List<string> distinct = extensions.Distinct().ToList();
                foreach (var item in distinct)
                {
                    comboBox1.Items.Add(item);

                }
               

            }
        }

    }
}
