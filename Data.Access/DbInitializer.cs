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

                


                List<Record> records1 = new List<Record>()
                {
                    new Record()
                    {
                        RecordId = Guid.NewGuid(),
                        ProjectId = project1.ProjectId,
                        Name = "Phone"
                    },
                    new Record()
                    {
                        RecordId = Guid.NewGuid(),
                        ProjectId = project1.ProjectId,
                        Name = "Rent"
                    },
                    new Record()
                    {
                        RecordId = Guid.NewGuid(),
                        ProjectId = project1.ProjectId,
                        Name = "Food"
                    }
                };

                List<Record> records2 = new List<Record>()
                {
                    new Record()
                    {
                        RecordId = Guid.NewGuid(),
                        ProjectId = project2.ProjectId,
                        Name = "Phone2"
                    },
                    new Record()
                    {
                        RecordId = Guid.NewGuid(),
                        ProjectId = project2.ProjectId,
                        Name = "Rent2"
                    },
                    new Record()
                    {
                        RecordId = Guid.NewGuid(),
                        ProjectId = project2.ProjectId,
                        Name = "Food2"
                    }
                };
                List<Record> records3 = new List<Record>()
                {
                    new Record()
                    {
                        RecordId = Guid.NewGuid(),
                        ProjectId = project3.ProjectId,
                        Name = "Phone3"
                    },
                    new Record()
                    {
                        RecordId = Guid.NewGuid(),
                        ProjectId = project3.ProjectId,
                        Name = "Rent3"
                    },
                    new Record()
                    {
                        RecordId = Guid.NewGuid(),
                        ProjectId = project3.ProjectId,
                        Name = "Food3"
                    }
                };

                project1.Records = records1;
                project2.Records = records2;
                project3.Records = records3;

                context.Projects.Add(project1);
                context.Projects.Add(project2);
                context.Projects.Add(project3);

                context.SaveChanges();
            }
        }
    }
}
