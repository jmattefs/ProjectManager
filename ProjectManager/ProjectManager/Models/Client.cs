using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManager.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string Role { get; set; }
        public string Feedback { get; set; }
        public Project MyProject { get; set; }
        public ScrumMaster MyLeader { get; set; }
    }
}