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
        int _numberCycleModulation = 0;
        public MainForm()
        {
            InitializeComponent();
            _ticks = Properties.Settings.Default.currentResponseTime;
            this.timerLabel.Text = Properties.Settings.Default.currentResponseTime.ToString();
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
            if (_numberCycleModulation == 0)
            {
                _ticks = Properties.Settings.Default.currentResponseTime;
                timerLabel.Text = _ticks.ToString();
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
            else
            {
                _ticks = Properties.Settings.Default.currentResponseTime;
                timerLabel.Text = _ticks.ToString();
                timer1.Start();
            }
        }

        //@/////////////////////////////////////////////////////////////////////////////////////
        private void UpdteLVWorkersTmrTick()
        {
            listViewEmployees.BeginUpdate();
            try
            {
                for (int i = 0; i < listWorkers.Count; i++)
                {
                    if (listWorkers[i].containerTasks.Count != 0)
                    {
                        listViewEmployees.Items[i].SubItems[2].Text = listWorkers[i].containerTasks[0].Name;
                        listViewEmployees.Items[i].SubItems[3].Text = listWorkers[i].containerTasks[0].Complexity.ToString();                        
                    }

                    if (listWorkers[i].containerTasks.Count == 0)
                    {
                        listViewEmployees.Items[i].SubItems[2].Text = "No tasks";
                        listViewEmployees.Items[i].SubItems[3].Text = "-";
                    }
                }
            }
            finally
            {
                listViewEmployees.EndUpdate();
            }
        }

        //@/////////////////////////////////////////////////////////////////////////////////////
        private void timer1_Tick(object sender, EventArgs e)
        {
            _ticks--;
            if (_ticks == 0)
            {
                this.timerLabel.Text = _ticks.ToString();
                timer1.Stop();
                _numberCycleModulation++;
                CountTaskAfterTimeTick();
                UpdteLVWorkersTmrTick();
                return;
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
                    if (listWorkers[0].containerTasks.Count == 1)
                    {
                        listWorkers[0].containerTasks.Insert(0, listWorkers[i].containerTasks[0]);
                        listWorkers[i].containerTasks.RemoveAt(0);
                    }
                    if (listWorkers[0].containerTasks.Count > 1)
                    {
                        if (listWorkers[i].containerTasks.Count == 1)
                        {
                            listWorkers[0].containerTasks.Insert(0, listWorkers[i].containerTasks[0]);
                            listWorkers[i].containerTasks.RemoveAt(0);
                        }
                        if (listWorkers[i].containerTasks.Count > 1)
                        {
                            listWorkers[0].containerTasks.Insert(0, listWorkers[i].containerTasks[1]);
                            listWorkers[i].containerTasks.RemoveAt(1);
                        }
                    }

                    return;
                }
                if (indexNextTask == 1)
                {
                    if (listWorkers[i].containerTasks.Count != 0)
                    {
                        listWorkers[indexNextTask].containerTasks.Insert(0, listWorkers[i].containerTasks[0]);
                        listWorkers[i].containerTasks.RemoveAt(0);
                    }                   
                }
                else
                {
                    if (listWorkers[i].containerTasks.Count == 1)
                    {
                        listWorkers[indexNextTask].containerTasks.Insert(0, listWorkers[i].containerTasks[0]);
                        listWorkers[i].containerTasks.RemoveAt(0);
                    }
                    if (listWorkers[i].containerTasks.Count > 1)
                    {
                        listWorkers[indexNextTask].containerTasks.Insert(0, listWorkers[i].containerTasks[1]);
                        listWorkers[i].containerTasks.RemoveAt(1);
                    }
                }
            }
        }

        //@/////////////////////////////////////////////////////////////////////////////////////
        private void CountTaskAfterTimeTick()
        {
            Random random = new Random();           
            foreach (Worker worker in listWorkers)
            {
                if (worker.containerTasks.Count >= 1)
                {
                    int result = worker.containerTasks[0].Complexity - worker.Performance;
                    if (result <= 0)
                    {
                        fillProcessWorkListView(worker, worker.containerTasks[0], _numberCycleModulation);
                        worker.containerTasks.RemoveAt(0);
                    }
                    else
                    {
                        worker.containerTasks[0].Complexity = result;
                    }
                }
                else
                {
                    continue;
                }
            }
            int probability = random.Next(0, 2);
            if (probability == 0)
            {
                RedistributionTask();               
            }            
        }

        //@/////////////////////////////////////////////////////////////////////////////////////
        private void buttonPause_Click(object sender, EventArgs e)
        {            
            if (buttonPause.Text.Equals("CONTINUE"))
            {
                timer1.Start();
                buttonPause.Text = "PAUSE";
            }
            else
            {
                timer1.Stop();
                buttonPause.Text = "CONTINUE";
            }            
        }

        //@/////////////////////////////////////////////////////////////////////////////////////
        private void fillProcessWorkListView(Worker workerFinished, Task completedTask, int numberCycleModulation)
        {
            string[] item = new string[] { workerFinished.Name, completedTask.Name, numberCycleModulation.ToString() };
            ListViewItem lvItem = new ListViewItem(item);
            listViewProcessWork.Items.Add(lvItem);
        }
    }
}

