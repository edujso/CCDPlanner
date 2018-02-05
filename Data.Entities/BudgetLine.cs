using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class BudgetLine
    {
        public Guid BudgetLineId { get; set; }

        public string Descriptioin { get; set; }        

        public string TotalCost { get; set; }

        public string Unit { get; set; }

        public int NumberOfUnits { get; set; }
        
        public int CostPerUnit { get; set; }

        public Guid ProjectBudgetCategoryId { get; set; }

        public ProjectBudgetCategory ProjectBudgetCategory { get; set; }
    }
}
