using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TreeSize
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {       
        public MainWindow()
        {
            InitializeComponent();
            FillDiscsInfo();
        }

        public void FillDiscsInfo()
        {
            int count = 0;
            TreeView treeView = TreeViewMain;
            TreeViewItem treeViewItem = TreeViewItem;
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            TreeViewItem itemsTreeView = (TreeViewItem)treeView.Items[0];
            for (int i = 0; i < allDrives.Length; i++)
            {
                TreeViewItem newChild = new TreeViewItem();
                treeViewItem.Items.Add(newChild);
            }
           
            foreach (DriveInfo disc in allDrives)
            {                
                TreeViewItem childItem = (TreeViewItem)itemsTreeView.Items[count];
                if (disc.IsReady == true)
                {
                    childItem.Header = disc.Name;                   
                }
                count++;
            }
        }

        public void FillDirectoryInfo()
        {
            int count = 0;
            TreeView treeView = TreeViewMain;
            TreeViewItem treeViewItem = TreeViewItem;
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            TreeViewItem itemsTreeView = (TreeViewItem)treeView.Items[0];
            for (int i = 0; i < allDrives.Length; i++)
            {
                TreeViewItem newChild = new TreeViewItem();
                treeViewItem.Items.Add(newChild);
            }

            foreach (DriveInfo disc in allDrives)
            {
                TreeViewItem childItem = (TreeViewItem)itemsTreeView.Items[count];
                if (disc.IsReady == true)
                {
                    childItem.Header = disc.Name;
                }
                count++;
            }
        }
    }
}
