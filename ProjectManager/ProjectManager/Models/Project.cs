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
        public int Status { get; set; }
        
        public List<string> Tasks { get; set; }
    }
}