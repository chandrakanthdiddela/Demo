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

namespace Folderstructure
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          //  System.Windows.Forms.TreeView treeview = new System.Windows.Forms.TreeView ();
           this. treeView1.Nodes.Add("window");

            string str="C:\\dell";
            ListDirectory(treeview,str);
        }
        private void ListDirectory(TreeView treeView, String path)
        {
            Stack<string> stack = new Stack<string>();
            TreeNode DirFilesCollection = new TreeNode();

            stack.Push(path);

            while (stack.Count > 0)
            {
                string dir = stack.Pop();
                try
                {
                    List<String> parentDir = new List<string>();
                    parentDir.AddRange(Directory.GetFiles(dir, "*.*"));
                    parentDir.AddRange(Directory.GetDirectories(dir));

                    DirectoryInfo d = new DirectoryInfo(dir);
                    TreeNode TParent = new TreeNode(d.Name);

                    foreach (String s in parentDir)
                    {
                        FileInfo f = new FileInfo(s);
                        TreeNode subItems = new TreeNode(f.Name);

                        TParent.Nodes.Add(subItems);
                    }

                    DirFilesCollection.Nodes.Add(TParent);

                    foreach (string dn in Directory.GetDirectories(dir))
                    {
                        stack.Push(dn);
                    }
                }
                catch
                { }
            }

            Action clearTreeView = () => treeView.Nodes.Clear();
            this.Invoke(clearTreeView);

            Action showTreeView = () => treeView.Nodes.Add(DirFilesCollection);
            this.Invoke(showTreeView);
        }
    }
}
