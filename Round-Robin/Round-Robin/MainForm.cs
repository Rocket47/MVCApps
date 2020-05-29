using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Round_Robin
{
    public partial class MainForm : Form
    {
        Generator generator = new Generator();
        List<Worker> listWorkers = new List<Worker>();
        int _ticks = 0;
        public MainForm()
        {
            InitializeComponent();
            _ticks = Properties.Settings.Default.ResponseTime;
            this.timerLabel.Text = Properties.Settings.Default.ResponseTime.ToString();
        }

        //@/////////////////////////////////////////////////////////////////////////////////////
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show();
        }

        //@/////////////////////////////////////////////////////////////////////////////////////
        private void buttonNew_Click(object sender, EventArgs e)
        {
            timer1.Start();
            //TODO 2х нажатие обработать
            RoundRobin();
            for (int i = 0; i < listWorkers.Count; i++)
            {
                var rowWorkers = new string[] { listWorkers[i].Name, listWorkers[i].Performance.ToString() };
                var lvi = new ListViewItem(rowWorkers);
                lvi.Tag = listWorkers[i];
                listViewEmployees.Items.Add(lvi);
                listViewEmployees.Items[i].SubItems.Add(listWorkers[i].containerTasks[0].Name.ToString());
                listViewEmployees.Items[i].SubItems.Add(listWorkers[i].containerTasks[0].Complexity.ToString());
            }
        }        

        //@/////////////////////////////////////////////////////////////////////////////////////
        private void timer1_Tick(object sender, EventArgs e)
        {
            _ticks--;
            if (_ticks == 0)
            {
                timer1.Stop();
            }
            this.timerLabel.Text = _ticks.ToString();

        }

        //@/////////////////////////////////////////////////////////////////////////////////////
        private void listViewEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewTasksWorker.Items.Clear();
            try
            {
                var SelectedItem = (Worker)listViewEmployees.SelectedItems[0].Tag;
                if (SelectedItem != null)
                {
                    foreach (Task task in SelectedItem.containerTasks)
                    {
                        var row = new string[] { task.Name, task.Complexity.ToString() };
                        var lvi = new ListViewItem(row);
                        listViewTasksWorker.Items.Add(lvi);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        //@/////////////////////////////////////////////////////////////////////////////////////
        private void RoundRobin()
        {
            int indexWorker = 0;           
            listWorkers = generator.GenerateAllWorkers();
            int countWorkers = listWorkers.Count;
            List<Task> listTasks = generator.GenerateAllTasks();           
            for (int indexTasks = 0; indexTasks < listTasks.Count; indexTasks++)
            {
                if (indexWorker >= countWorkers)
                {
                    indexWorker = 0;
                }
                listWorkers[indexWorker].AddTaskToContainer(listTasks[indexTasks]);
                indexWorker++;
            }
        }

        //@/////////////////////////////////////////////////////////////////////////////////////
        private void RedistributionTask()
        {
            int listWorkersCount = listWorkers.Count;
            for (int i = 0; i < listWorkersCount; i++)
            {
                int indexNextTask = i + 1;
                if (indexNextTask == listWorkersCount)
                {
                    listWorkers[0].containerTasks.Add(listWorkers[i].containerTasks[0]);
                    listWorkers[i].containerTasks.RemoveAt(0);
                    return;
                }
                listWorkers[indexNextTask].containerTasks.Add(listWorkers[i].containerTasks[0]);
                listWorkers[i].containerTasks.RemoveAt(0);
            }
        }      
    }
}
