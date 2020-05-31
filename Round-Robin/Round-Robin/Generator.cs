using Round_Robin.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Round_Robin
{
    class Generator
    {
        public int numberTask = 1;

        //@/////////////////////////////////////////////////////////////////////////////////////
        public string GenerateNameWorker()
        {
            Random r = new Random();
            int len = r.Next(4, 10);
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int timeLetterAdded = 2;
            while (timeLetterAdded < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                timeLetterAdded++;
                Name += vowels[r.Next(vowels.Length)];
                timeLetterAdded++;
            }
            return Name;
        }

        //@/////////////////////////////////////////////////////////////////////////////////////
        public int GeneratePerformanceWorker()
        {
            int minValue = Convert.ToInt32(Properties.Settings.Default.currentMinPerformance);
            int maxValue = Convert.ToInt32(Properties.Settings.Default.currentMaxPerformance) + 1;
            Random r = new Random();
            int performance = r.Next(minValue, maxValue);
            return performance;
        }

        //@/////////////////////////////////////////////////////////////////////////////////////
        public string GenerateNameTask()
        {
            string taskName = "Task " + numberTask;
            numberTask++;
            return taskName;
        }

        //@/////////////////////////////////////////////////////////////////////////////////////
        public int GenerateTaskComplexity()
        {
            int minValue = Convert.ToInt32(Properties.Settings.Default.currentMinComplexity);
            int maxValue = Convert.ToInt32(Properties.Settings.Default.currentMaxComplexity) + 1;
            Random r = new Random();
            int complexity = r.Next(minValue, maxValue);
            return complexity; ;
        }

        //@/////////////////////////////////////////////////////////////////////////////////////
        public List<Task> GenerateAllTasks()
        {
            List<Task> resultListTasks = new List<Task>();
            int minValue = Convert.ToInt32(Properties.Settings.Default.currentMinCountTasks);
            int maxValue = Convert.ToInt32(Properties.Settings.Default.currentMaxCountTasks);
            Random r = new Random();
            int countTasks = r.Next(minValue, maxValue);
            for (int i = 0; i < countTasks; i++)
            {
                resultListTasks.Add(new Task(GenerateNameTask(), GenerateTaskComplexity()));
                Thread.Sleep(30);
            }
            return resultListTasks;
        }

        //@/////////////////////////////////////////////////////////////////////////////////////
        public List<Worker> GenerateAllWorkers()
        {
            //TODO В идеале заменить на многопоточность  
            List<Worker> resultListWorkers = new List<Worker>();
            int minCountWorkers = Properties.Settings.Default.currentMinCountWorkers;
            int maxCountWorkers = Properties.Settings.Default.currentMaxCountWorkers;
            int randomCountWorkers;
            Random random = new Random();
            randomCountWorkers = random.Next(minCountWorkers, maxCountWorkers);
            for (int i = 0; i < randomCountWorkers; i++)
            {
                string name = GenerateNameWorker();
                int performance = GeneratePerformanceWorker();
                Worker worker = new Worker(name, performance);
                Thread.Sleep(40);
                resultListWorkers.Add(worker);
            }
            return resultListWorkers;
        }
    }
}
