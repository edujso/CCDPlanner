using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Access
{
    public class CCDPlannerDBContext : IdentityDbContext<User>
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<BudgetCategory> BudgetCategories { get; set; }
        public DbSet<User> Users { get; set; }

        public CCDPlannerDBContext(DbContextOptions<CCDPlannerDBContext> options)
            : base(options)
        {

        }

        public CCDPlannerDBContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("data source=localhost\\SQLEXPRESS;initial catalog=CCDPlanner;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<BudgetCategory>()
                .HasMany(c => c.ChildrenCategories)
                .WithOne(c => c.ParentCategory)
                .HasForeignKey(c => c.ParentCategoryId);
                
        }
    }
}
