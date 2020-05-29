using Round_Robin.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Round_Robin
{
    class GeneratorNamesValues
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
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }
            return Name;
        }

        //@/////////////////////////////////////////////////////////////////////////////////////
        public int GeneratePerformanceWorker()
        {
            int minValue = Convert.ToInt32(Properties.Settings.Default.MinPerformance);
            int maxValue = Convert.ToInt32(Properties.Settings.Default.MaxPerformance) + 1;
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
            int minValue = Convert.ToInt32(Properties.Settings.Default.MinComplexity);
            int maxValue = Convert.ToInt32(Properties.Settings.Default.MaxComplexity) + 1;
            Random r = new Random();
            int complexity = r.Next(minValue, maxValue);
            return complexity; ;
        }
    }
}
