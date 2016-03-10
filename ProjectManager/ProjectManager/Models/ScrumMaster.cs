using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManager.Models
{
    public class ScrumMaster
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public Project Project { get; set; }
        public List<TeamMember> Team { get; set; }
    }
}