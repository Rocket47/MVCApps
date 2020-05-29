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
            this.responseTimeInput.Text = Properties.Settings.Default.ResponseTime.ToString();
            this.minCountWorkerInput.Text = Properties.Settings.Default.MinCounWorkers.ToString();
            this.maxCountWorkerInput.Text = Properties.Settings.Default.MaxCountWorkers.ToString();
            this.minPerformanceInput.Text = Properties.Settings.Default.MinPerformance.ToString();
            this.maxPerformanceInput.Text = Properties.Settings.Default.MaxPerformance.ToString();
            this.minCountTasksInput.Text = Properties.Settings.Default.MinCountTasks.ToString();
            this.maxCountTasksInput.Text = Properties.Settings.Default.MaxCountTasks.ToString();
            this.minComplexityInput.Text = Properties.Settings.Default.MinComplexity.ToString();
            this.maxComplexityInput.Text = Properties.Settings.Default.MaxComplexity.ToString();
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
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            GoToDefaultSettings();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
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
            Properties.Settings.Default.isFormSettingsLoadFirstTime = false;

        }
    }
}
