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
        GeneratorNamesValues generatorNamesValues = new GeneratorNamesValues();
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
            fillListWorkers();
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
        private void fillListWorkers()
        {
            //TODO Надо заменить настройки на текущие. Сейчас не верно! Берется всегда дефолт!            
            int minCountWorkers = Properties.Settings.Default.MinCounWorkers;
            int maxCountWorkers = Properties.Settings.Default.MaxCountWorkers;
            int randomCountWorkers;
            Random random = new Random();
            randomCountWorkers = random.Next(minCountWorkers, maxCountWorkers);
            for (int i = 0; i < randomCountWorkers; i++)
            {
                string name = generatorNamesValues.GenerateNameWorker();             
                int performance = generatorNamesValues.GeneratePerformanceWorker();
                Worker worker = new Worker(name, performance);
                string nameTask = generatorNamesValues.GenerateNameTask();
                int complexity = generatorNamesValues.GenerateTaskComplexity();
                worker.AddTaskToContainer(new Task(nameTask, complexity));
                listWorkers.Add(worker);
                Thread.Sleep(50);
                //TODO В идеале заменить на многопоточность                
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
            try {
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
    }
}
