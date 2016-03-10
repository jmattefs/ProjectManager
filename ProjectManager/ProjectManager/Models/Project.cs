using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManager.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CompletedTasks { get; set; }
        public int NumberofTasks { get; set; }
        public bool isComplete { get; set; }
        public List<TeamMember> ProjectTeam { get; set; }
        
        public List<string> Tasks { get; set; }
        
    }
}