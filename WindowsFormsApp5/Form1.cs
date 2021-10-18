using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        private void FillTreeNode(TreeNode driveNode, string path)
        {
            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);
                foreach (string s in files)
                {
                    treeView2.Nodes.Clear();
                    treeView2.Nodes.Add(s);
                }
              }
         }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog()==DialogResult.OK)
            {
                 treeView1.Nodes.Add(folderBrowserDialog.SelectedPath);
               
            }

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            e.Node.Nodes.Clear();
            string[] dirs;


            if (Directory.Exists(e.Node.FullPath))
            {
                dirs = Directory.GetDirectories(e.Node.FullPath);
                if (dirs.Length != 0)
                {
                    for (int i = 0; i < dirs.Length; i++)
                    {
                        TreeNode dirNode = new TreeNode(new DirectoryInfo(dirs[i]).Name);
                        FillTreeNode(dirNode, dirs[i]);
                        e.Node.Nodes.Add(dirNode);

                    }


                }
            }

        }


    }
        

    
    
    
}
