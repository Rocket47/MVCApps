using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

        private void PopulateTreeView()
        {
            TreeNode rootNode;
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo driveInfo in allDrives)
            {
                DirectoryInfo info = new DirectoryInfo(@driveInfo.Name);
                if (info.Exists)
                {
                    rootNode = new TreeNode(info.Name);
                    rootNode.Tag = info;
                    GetDirectories(info.GetDirectories(), rootNode);
                    treeView1.Nodes.Add(rootNode);
                }
            }
        }

        private void GetDirectories(DirectoryInfo[] subDirs,
            TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            foreach (DirectoryInfo subDir in subDirs)
            {
                try
                {
                    subDir.GetFiles();
                }
                catch (UnauthorizedAccessException ex)
                {
                    continue;
                }
                aNode = new TreeNode(subDir.Name, 0, 0);
                aNode.Tag = subDir;
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
            FillFiles(nodeDirInfo, item, subItems);
        }

        public static long DirSize(DirectoryInfo d)
        {
            long size = 0;
            try
            {
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
            catch (UnauthorizedAccessException ex)
            {
                return 0;
            }

        }

        public void FillDirectory(DirectoryInfo nodeDirInfo, ListViewItem item, ListViewItem.ListViewSubItem[] subItems)
        {
            foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
            {
                try
                {
                    FileInfo[] fis = dir.GetFiles();
                    new Thread(() =>
                        {
                            Action action = () => SetInfoDirectory(dir, item, subItems);

                            if (InvokeRequired)
                                Invoke(action);
                            else
                                action();

                        }).Start();
                }
                catch (UnauthorizedAccessException ex)
                {
                    continue;
                }
            }
        }

        public void SetInfoDirectory(DirectoryInfo dir, ListViewItem item, ListViewItem.ListViewSubItem[] subItems)
        {
            item = new ListViewItem(dir.Name, 0);

            subItems = new ListViewItem.ListViewSubItem[]
           { new ListViewItem.ListViewSubItem(item, "Directory"),
             new ListViewItem.ListViewSubItem(item,
                 dir.LastAccessTime.ToShortDateString()),
             new ListViewItem.ListViewSubItem(item, DirSize(dir).ToString()),
             new ListViewItem.ListViewSubItem(item, dir.GetDirectories().Length.ToString())};
            item.SubItems.AddRange(subItems);
            listview.Items.Add(item);
        }

        public void FillFiles(DirectoryInfo nodeDirInfo, ListViewItem item, ListViewItem.ListViewSubItem[] subItems)
        {
            foreach (FileInfo file in nodeDirInfo.GetFiles())
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
        }
    }
}

