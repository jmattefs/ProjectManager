﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManager.Models
{
    public class TeamMember
    {
        public int ID { get; set; }
        public string Name {get; set;}
        
        public Project Project { get; set; }
        public string Task { get; set; }
        public bool TaskComplete { get; set; }
        
    }
}