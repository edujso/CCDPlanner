using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Access
{
    public class DbInitializer
    {
        public static void Initialize(CCDPlannerDBContext context)
        {
            context.Database.EnsureCreated();

            if(!context.Projects.Any())
            {
                Project project1 = new Project()
                {
                    ProjectId = Guid.NewGuid(),
                    Name = "Griesser",
                    Sponsor = "Griesser Sales",
                    Budget = "100.000",
                    StartDate = DateTime.Now
                };                

                Project project2 = new Project()
                {
                    ProjectId = Guid.NewGuid(),
                    Name = "Valooze",
                    Sponsor = "Valooze Sales",
                    Budget = "200.000",
                    StartDate = DateTime.Now
                };

                Project project3 = new Project()
                {
                    ProjectId = Guid.NewGuid(),
                    Name = "DoojZ",
                    Sponsor = "DoojZ Sales",
                    Budget = "1.000.000",
                    StartDate = DateTime.Now
                };

                BudgetCategory bc1 = new BudgetCategory()
                {
                    BudgetCategoryId = Guid.NewGuid(),
                    Description = "Infrastructure"
                };

                BudgetCategory bc11 = new BudgetCategory()
                {
                    BudgetCategoryId = Guid.NewGuid(),
                    Description = "Rent",
                    ParentCategoryId = bc1.BudgetCategoryId
                };

                BudgetCategory bc12 = new BudgetCategory()
                {
                    BudgetCategoryId = Guid.NewGuid(),
                    Description = "Phone",
                    ParentCategoryId = bc1.BudgetCategoryId
                };

                BudgetCategory bc121 = new BudgetCategory()
                {
                    BudgetCategoryId = Guid.NewGuid(),
                    Description = "Business Phone",
                    ParentCategoryId = bc12.BudgetCategoryId
                };

                BudgetCategory bc122 = new BudgetCategory()
                {
                    BudgetCategoryId = Guid.NewGuid(),
                    Description = "Private Phone",
                    ParentCategoryId = bc12.BudgetCategoryId
                };

                BudgetCategory bc1221 = new BudgetCategory()
                {
                    BudgetCategoryId = Guid.NewGuid(),
                    Description = "Private Phone Euro",
                    ParentCategoryId = bc122.BudgetCategoryId
                };

                BudgetCategory bc1222 = new BudgetCategory()
                {
                    BudgetCategoryId = Guid.NewGuid(),
                    Description = "Private Phone Dollars",
                    ParentCategoryId = bc122.BudgetCategoryId
                };

                BudgetCategory bc2 = new BudgetCategory()
                {
                    BudgetCategoryId = Guid.NewGuid(),
                    Description = "Activites"
                };

                BudgetCategory bc21 = new BudgetCategory()
                {
                    BudgetCategoryId = Guid.NewGuid(),
                    Description = "Seminar",
                    ParentCategoryId = bc2.BudgetCategoryId
                };

                BudgetCategory bc22 = new BudgetCategory()
                {
                    BudgetCategoryId = Guid.NewGuid(),
                    Description = "Online Show",
                    ParentCategoryId = bc2.BudgetCategoryId
                };


                project1.BudgetCategories.Add(bc1);
                project1.BudgetCategories.Add(bc11);
                project1.BudgetCategories.Add(bc12);
                project1.BudgetCategories.Add(bc2);
                project1.BudgetCategories.Add(bc21);
                project1.BudgetCategories.Add(bc22);
                project1.BudgetCategories.Add(bc121);
                project1.BudgetCategories.Add(bc122);
                project1.BudgetCategories.Add(bc1221);
                project1.BudgetCategories.Add(bc1222);

                project2.BudgetCategories.Add(bc2);
                project2.BudgetCategories.Add(bc21);
                project2.BudgetCategories.Add(bc22);

                project3.BudgetCategories.Add(bc2);
                project3.BudgetCategories.Add(bc21);
                project3.BudgetCategories.Add(bc22);

                context.Projects.Add(project1);
                context.Projects.Add(project2);
                context.Projects.Add(project3);

                context.SaveChanges();
            }
        }
    }
}
