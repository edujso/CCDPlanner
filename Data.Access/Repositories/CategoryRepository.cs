using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Data.Access.Repositories
{
    public class CategoryRepository : DataRepositoryBase<BudgetCategory>, ICategoryRepository
    {
        protected override BudgetCategory AddEntity(CCDPlannerDBContext entityContext, BudgetCategory entity)
        {
            return entityContext.BudgetCategories.Add(entity).Entity;
        }

        protected override IEnumerable<BudgetCategory> GetEntities(CCDPlannerDBContext entityContext)
        {
            IEnumerable<BudgetCategory> categories = entityContext.BudgetCategories;

            return categories.Where(c => c.ParentCategoryId == null);
        }

        protected override BudgetCategory GetEntity(CCDPlannerDBContext entityContext, Guid id)
        {
            return GetEntities(entityContext).Where(c => c.BudgetCategoryId == id).FirstOrDefault();            
        }

        protected override BudgetCategory UpdateEntity(CCDPlannerDBContext entityContext, BudgetCategory entity)
        {
            throw new NotImplementedException();
        }
    }
}
