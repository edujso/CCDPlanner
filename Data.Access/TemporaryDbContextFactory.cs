using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Access
{
    public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<CCDPlannerDBContext>
    {
        public CCDPlannerDBContext CreateDbContext(string[] args)
        {
            //var config = new ConfigurationBuilder()
            //.AddJsonFile("appsettings.json", optional: false)
            //.Build();

            var builder = new DbContextOptionsBuilder<CCDPlannerDBContext>();
            //builder.UseSqlServer("data source=localhost;initial catalog=Valooze;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
            return new CCDPlannerDBContext(builder.Options);
        }
    }
}
