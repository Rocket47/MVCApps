using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeSize
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PopulateTreeView();
            this.treeView1.NodeMouseClick +=
            new TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void PopulateTreeView()
        {
            TreeNode rootNode;

            DirectoryInfo info = new DirectoryInfo(@"F:\");
            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                GetDirectories(info.GetDirectories(), rootNode);
                treeView1.Nodes.Add(rootNode);
            }
        }

        private void GetDirectories(DirectoryInfo[] subDirs,
            TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            DirectoryInfo[] subSubDirs;
            foreach (DirectoryInfo subDir in subDirs)
            {
                aNode = new TreeNode(subDir.Name, 0, 0);
                aNode.Tag = subDir;
                aNode.ImageKey = "folder";
                nodeToAddTo.Nodes.Add(aNode);
            }
        }

        void treeView1_NodeMouseClick(object sender,
    TreeNodeMouseClickEventArgs e)
        {
            TreeNode newSelected = e.Node;
            listview.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
            ListViewItem.ListViewSubItem[] subItems = new ListViewItem.ListViewSubItem[] { };
            ListViewItem item = null;
            FillDirectory(nodeDirInfo, item, subItems);            
            listview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        public static long DirSize(DirectoryInfo d)
        {
            long size = 0;
            FileInfo[] fis = d.GetFiles();
            if (fis.Length != 0)
            {
                foreach (FileInfo fi in fis)
                {
                    size += fi.Length;
                }
            }
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += DirSize(di);
            }
            return size;
        }

        public void FillDirectory(DirectoryInfo nodeDirInfo, ListViewItem item, ListViewItem.ListViewSubItem[] subItems)
        {
            try
            {
                foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
                {                    
                        item = new ListViewItem(dir.Name, 0);
                    var extension = dir.FullName.Replace(Path.GetFileNameWithoutExtension(dir.FullName), "");
                    if (Path.GetExtension(extension) == string.Empty)
                    {
                        subItems = new ListViewItem.ListViewSubItem[]
                            {new ListViewItem.ListViewSubItem(item, "Directory"),
             new ListViewItem.ListViewSubItem(item,
                dir.LastAccessTime.ToShortDateString()),
              new ListViewItem.ListViewSubItem(item, DirSize(dir).ToString())};
                        item.SubItems.AddRange(subItems);
                        listview.Items.Add(item);
                    }
                        
                    else
                    {
                        FillFiles(nodeDirInfo, item, subItems);
                    }                       
                }                                  
                }            
            catch
            {
                            
            }
        }

        public void FillFiles(DirectoryInfo nodeDirInfo, ListViewItem item, ListViewItem.ListViewSubItem[] subItems)
        {           
                foreach (FileInfo file in nodeDirInfo.GetFiles())
                {
                    if (Path.GetExtension(file.FullName) != string.Empty)
                    {
                        item = new ListViewItem(file.Name, 1);
                        subItems = new ListViewItem.ListViewSubItem[]
                            { new ListViewItem.ListViewSubItem(item, "File"),
             new ListViewItem.ListViewSubItem(item,
                file.LastAccessTime.ToShortDateString()), new ListViewItem.ListViewSubItem(item,
                file.Length.ToString()) };

                        item.SubItems.AddRange(subItems);
                        listview.Items.Add(item);
                    }
                    else
                    {
                        FillDirectory(nodeDirInfo, item, subItems);
                    }
                    
                }                      
        }
    }
}

