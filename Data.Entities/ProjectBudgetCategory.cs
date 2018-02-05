using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class ProjectBudgetCategory
    {
        public Guid ProjectBudgetCategoryId { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public Guid BudgetCategoryId { get; set; }
        public BudgetCategory BudgetCategory { get; set; }

        public ICollection<BudgetLine> BudgetLines { get; set; }
            = new List<BudgetLine>();
    }
}
