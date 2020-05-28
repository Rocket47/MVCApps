using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Round_Robin
{
    class Worker
    {
        public string Name { get; set; }
        public int Performance { get; set; }

        public List<Task> containerTasks;

        public Worker(string Name, int Performance)
        {
            this.Name = Name;
            this.Performance = Performance;
        }

        private void AddTaskToContainer(Task task)
        {
            containerTasks = new List<Task>();
            containerTasks.Add(task);
        }
    }
}
