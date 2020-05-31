using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Round_Robin
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            labelSave.Text = "";
            if (Properties.Settings.Default.isFormSettingsLoadFirstTime)
            {
                GoToDefaultSettings();                
                return;
            }

            if (!Properties.Settings.Default.isFormSettingsLoadFirstTime)
            {                
                GoToSaveSettings();                
                return;
            }
        }

        private void GoToDefaultSettings()
        {
            labelSave.Text = "DEFAULT!";
            this.responseTimeInput.Text = Properties.Settings.Default.ResponseTime.ToString();
            this.minCountWorkerInput.Text = Properties.Settings.Default.MinCountWorkers.ToString();
            this.maxCountWorkerInput.Text = Properties.Settings.Default.MaxCountWorkers.ToString();
            this.minPerformanceInput.Text = Properties.Settings.Default.MinPerformance.ToString();
            this.maxPerformanceInput.Text = Properties.Settings.Default.MaxPerformance.ToString();
            this.minCountTasksInput.Text = Properties.Settings.Default.MinCountTasks.ToString();
            this.maxCountTasksInput.Text = Properties.Settings.Default.MaxCountTasks.ToString();
            this.minComplexityInput.Text = Properties.Settings.Default.MinComplexity.ToString();
            this.maxComplexityInput.Text = Properties.Settings.Default.MaxComplexity.ToString();
            Properties.Settings.Default.currentResponseTime = Properties.Settings.Default.ResponseTime;
            Properties.Settings.Default.currentMinCountWorkers = Properties.Settings.Default.MinCountWorkers;
            Properties.Settings.Default.currentMaxCountWorkers = Properties.Settings.Default.MaxCountWorkers;
            Properties.Settings.Default.currentMinPerformance = Properties.Settings.Default.MinPerformance;
            Properties.Settings.Default.currentMaxPerformance = Properties.Settings.Default.MaxPerformance;
            Properties.Settings.Default.currentMinCountTasks = Properties.Settings.Default.MinCountTasks;
            Properties.Settings.Default.currentMaxCountTasks = Properties.Settings.Default.MaxCountTasks;
            Properties.Settings.Default.currentMinComplexity = Properties.Settings.Default.MinComplexity;
            Properties.Settings.Default.currentMaxComplexity = Properties.Settings.Default.MaxComplexity;
        }

        private void GoToSaveSettings()
        {
            this.responseTimeInput.Text = Properties.Settings.Default.saveResponseTime.ToString();
            this.minCountWorkerInput.Text = Properties.Settings.Default.saveMinCountWorkers.ToString();
            this.maxCountWorkerInput.Text = Properties.Settings.Default.saveMaxCountWorkers.ToString();
            this.minPerformanceInput.Text = Properties.Settings.Default.saveMinPerformance.ToString();
            this.maxPerformanceInput.Text = Properties.Settings.Default.saveMaxPerformance.ToString();
            this.minCountTasksInput.Text = Properties.Settings.Default.saveMinCountTasks.ToString();
            this.maxCountTasksInput.Text = Properties.Settings.Default.saveMaxCountTasks.ToString();
            this.minComplexityInput.Text = Properties.Settings.Default.saveMinComplexity.ToString();
            this.maxComplexityInput.Text = Properties.Settings.Default.saveMaxComplexity.ToString();
            Properties.Settings.Default.currentResponseTime = Properties.Settings.Default.saveResponseTime;
            Properties.Settings.Default.currentMinCountWorkers = Properties.Settings.Default.saveMinCountWorkers;
            Properties.Settings.Default.currentMaxCountWorkers = Properties.Settings.Default.saveMaxCountWorkers;
            Properties.Settings.Default.currentMinPerformance = Properties.Settings.Default.saveMinPerformance;
            Properties.Settings.Default.currentMaxPerformance = Properties.Settings.Default.saveMaxPerformance;
            Properties.Settings.Default.currentMinCountTasks = Properties.Settings.Default.saveMinCountTasks;
            Properties.Settings.Default.currentMaxCountTasks = Properties.Settings.Default.saveMaxCountTasks;
            Properties.Settings.Default.currentMinComplexity = Properties.Settings.Default.saveMinComplexity;
            Properties.Settings.Default.currentMaxComplexity = Properties.Settings.Default.saveMaxComplexity;
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            GoToDefaultSettings();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.minCountWorkerInput.Text) > Convert.ToInt32(this.maxCountWorkerInput.Text))
            {
                MessageBox.Show("minCount(Performers) should be less than maxCount(Performers)");
                return;
            }
            if (Convert.ToInt32(this.minPerformanceInput.Text) > Convert.ToInt32(this.maxPerformanceInput.Text))
            {
                MessageBox.Show("minPerformance should be less than maxPerformance");
                return;
            }
            if (Convert.ToInt32(this.minCountTasksInput.Text) > Convert.ToInt32(this.maxCountTasksInput.Text))
            {
                MessageBox.Show("maxCount(Tasks) should be less maxCount(Tasks)");
                return;
            }
            if (Convert.ToInt32(this.minComplexityInput.Text) > Convert.ToInt32(this.maxComplexityInput.Text))
            {
                MessageBox.Show("minComplexity should be less maxComplexity");
                return;
            }
            //TODO Добавить уведломление что настройки успешно сохранены
            Properties.Settings.Default.saveResponseTime = Convert.ToInt32(this.responseTimeInput.Text);
            Properties.Settings.Default.saveMinCountWorkers = Convert.ToInt32(this.minCountWorkerInput.Text);
            Properties.Settings.Default.saveMaxCountWorkers = Convert.ToInt32(this.maxCountWorkerInput.Text);
            Properties.Settings.Default.saveMinPerformance = Convert.ToInt32(this.minPerformanceInput.Text);
            Properties.Settings.Default.saveMaxPerformance = Convert.ToInt32(this.maxPerformanceInput.Text);
            Properties.Settings.Default.saveMinCountTasks = Convert.ToInt32(this.minCountTasksInput.Text);
            Properties.Settings.Default.saveMaxCountTasks = Convert.ToInt32(this.maxCountTasksInput.Text);
            Properties.Settings.Default.saveMinComplexity = Convert.ToInt32(this.minComplexityInput.Text);
            Properties.Settings.Default.saveMaxComplexity = Convert.ToInt32(this.maxComplexityInput.Text);
            Properties.Settings.Default.currentResponseTime = Properties.Settings.Default.saveResponseTime;
            Properties.Settings.Default.currentMinCountWorkers = Properties.Settings.Default.saveMinCountWorkers;
            Properties.Settings.Default.currentMaxCountWorkers = Properties.Settings.Default.saveMaxCountWorkers;
            Properties.Settings.Default.currentMinPerformance = Properties.Settings.Default.saveMinPerformance;
            Properties.Settings.Default.currentMaxPerformance = Properties.Settings.Default.saveMaxPerformance;
            Properties.Settings.Default.currentMinCountTasks = Properties.Settings.Default.saveMinCountTasks;
            Properties.Settings.Default.currentMaxCountTasks = Properties.Settings.Default.saveMaxCountTasks;
            Properties.Settings.Default.currentMinComplexity = Properties.Settings.Default.saveMinComplexity;
            Properties.Settings.Default.currentMaxComplexity = Properties.Settings.Default.saveMaxComplexity;
            Properties.Settings.Default.isFormSettingsLoadFirstTime = false;
            labelSave.Text = "SAVED!";

        }
    }
}
