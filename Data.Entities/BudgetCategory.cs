using Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    public class BudgetCategory
    {
        [Key]
        public Guid BudgetCategoryId { get; set; }

        public string Description { get; set; }

        public Guid? ParentCategoryId { get; set; }

        [ForeignKey("ParentCategoryId")]
        public virtual BudgetCategory ParentCategory { get; set; }

        public virtual ICollection<BudgetCategory> ChildrenCategories { get; set; }
    }
}
