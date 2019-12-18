using System.ComponentModel.DataAnnotations;

namespace MVCApps.Models
{
    public class Student
    {
        [Key]
        public int student_ID {get;set;}
        public int sex_ID {get;set;}
        public int group_ID {get;set;}
        public string firstName {get;set;}
        public string lastName {get;set;}
    }
}