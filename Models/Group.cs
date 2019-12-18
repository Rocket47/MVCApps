using System.ComponentModel.DataAnnotations;

namespace MVCApps.Models
{
    public class Group
    {
        [Key]
        public int group_ID {get;set;}       
        public int course_ID {get;set;}
        public string name {get;set;}
    }
}