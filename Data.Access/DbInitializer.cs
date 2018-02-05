using Data.Entities;
using Microsoft.EntityFrameworkCore;
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
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if(true)
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


                ProjectBudgetCategory pbc1 = context.ProjectBudgetCategories.Where(pbc => pbc.BudgetCategory.Description == "Business Phone").FirstOrDefault();


                //context.Add(pbc1);
                //context.Add(new ProjectBudgetCategory { Project = project1, BudgetCategory = bc11 });
                //context.Add(new ProjectBudgetCategory { Project = project1, BudgetCategory = bc12 });
                //context.Add(new ProjectBudgetCategory { Project = project1, BudgetCategory = bc2 });
                //context.Add(new ProjectBudgetCategory { Project = project1, BudgetCategory = bc21 });
                //context.Add(new ProjectBudgetCategory { Project = project1, BudgetCategory = bc22 });
                //context.Add(new ProjectBudgetCategory { Project = project1, BudgetCategory = bc121 });
                //context.Add(new ProjectBudgetCategory { Project = project1, BudgetCategory = bc122 });
                //context.Add(new ProjectBudgetCategory { Project = project1, BudgetCategory = bc1221 });
                //context.Add(new ProjectBudgetCategory { Project = project1, BudgetCategory = bc1222 });

                //context.Add(new ProjectBudgetCategory { Project = project2, BudgetCategory = bc1 });
                //context.Add(new ProjectBudgetCategory { Project = project2, BudgetCategory = bc11 });
                //context.Add(new ProjectBudgetCategory { Project = project2, BudgetCategory = bc12 });
                //context.Add(new ProjectBudgetCategory { Project = project2, BudgetCategory = bc2 });
                //context.Add(new ProjectBudgetCategory { Project = project2, BudgetCategory = bc21 });
                //context.Add(new ProjectBudgetCategory { Project = project2, BudgetCategory = bc22 });
                //context.Add(new ProjectBudgetCategory { Project = project2, BudgetCategory = bc121 });
                //context.Add(new ProjectBudgetCategory { Project = project2, BudgetCategory = bc122 });

                //context.Add(new ProjectBudgetCategory { Project = project3, BudgetCategory = bc1 });
                //context.Add(new ProjectBudgetCategory { Project = project3, BudgetCategory = bc11 });
                //context.Add(new ProjectBudgetCategory { Project = project3, BudgetCategory = bc12 });
                //context.Add(new ProjectBudgetCategory { Project = project3, BudgetCategory = bc2 });
                //context.Add(new ProjectBudgetCategory { Project = project3, BudgetCategory = bc121 });
                //context.Add(new ProjectBudgetCategory { Project = project3, BudgetCategory = bc122 });



                BudgetLine bl1 = new BudgetLine()
                {
                    Descriptioin = "Phone costs for Edin Dujso",
                    Unit = "Month",
                    NumberOfUnits = 12,
                    CostPerUnit = 50,
                    TotalCost = "600",
                    ProjectBudgetCategory = pbc1
                };

                context.Add(bl1);

                context.SaveChanges();
            }
        }
    }
}
