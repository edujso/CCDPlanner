using Data.Access;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {

            List<BudgetCategory> bcategoriesAll = GetAll().ToList();

            // Working with only 3 levels
            //IEnumerable<Category> categories = Table.Where(x => x.Parent == null).Include(x => x.Children).ThenInclude(x => x.Children);
            
            foreach (BudgetCategory c in bcategoriesAll)
            {
                Console.WriteLine("Parent = {0}", c.Description);

                PrintCategoryChildren(c);
            }

            Console.ReadLine();
        }

        #region test

        public static IEnumerable<BudgetCategory> GetAll()
        {
            using (var context = new CCDPlannerDBContext())
            {
                IEnumerable<BudgetCategory> categories = context.BudgetCategories.Where(x => x.ParentCategory == null).ToList();
                categories = Traverse(categories);
                return categories;
            }                
        }

        private static IEnumerable<BudgetCategory> Traverse(IEnumerable<BudgetCategory> categories)
        {
            using (var context = new CCDPlannerDBContext())
            {
                foreach (var category in categories)
                {
                    var subCategories = context.BudgetCategories.Where(x => x.ParentCategoryId == category.BudgetCategoryId).ToList();
                    category.ChildrenCategories = subCategories;
                    category.ChildrenCategories = Traverse(category.ChildrenCategories).ToList();
                }

                return categories;
            }                
        }

        #endregion    

        public static void PrintCategoryChildren(BudgetCategory category)
        {
            if(category.ChildrenCategories != null && category.ChildrenCategories.Count() > 0 )
            {
                foreach (BudgetCategory c in category.ChildrenCategories)
                {
                    Console.WriteLine("Child = {0}", c.Description);
                    PrintCategoryChildren(c);
                }
            }
        }
    }
}
