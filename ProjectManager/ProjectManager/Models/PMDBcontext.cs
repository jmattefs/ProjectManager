using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProjectManager.Models;

namespace ProjectManager.Models
{
    public class PMDBcontext : DbContext
    {
        public PMDBcontext(): base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<ProjectManager.Models.TeamMember> TeamMembers { get; set; }

        public System.Data.Entity.DbSet<ProjectManager.Models.Client> Clients { get; set; }

        public System.Data.Entity.DbSet<ProjectManager.Models.ScrumMaster> ScrumMasters { get; set; }
    }
        
        
}