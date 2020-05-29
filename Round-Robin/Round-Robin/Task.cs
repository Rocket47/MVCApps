using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Round_Robin
{
    class Task
    {
        public string Name { get; set; }
        public int Complexity { get; set; }

        public Task(string Name, int Complexity)
        {
            this.Name = Name;
            this.Complexity = Complexity;
        }        
    }
}
