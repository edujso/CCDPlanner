using Data.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            return entityContext.BudgetCategories;
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
