using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities
{
    public class Project
    {
        [Key]
        public Guid ProjectId { get; set; }

        public string Name { get; set; }

        public string Budget { get; set; }

        public string Sponsor { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ICollection<ProjectBudgetCategory> ProjectBudgetCategories { get; set; }
            = new List<ProjectBudgetCategory>();

        public ICollection<BudgetLine> BudgetLines { get; set; }
            = new List<BudgetLine>();

        public ICollection<Sponsor> Sponsors { get; set; }
            = new List<Sponsor>();
    }
}
