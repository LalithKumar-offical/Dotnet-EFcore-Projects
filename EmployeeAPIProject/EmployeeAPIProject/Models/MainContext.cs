using System.Collections.Generic;
using System.Reflection.Emit;
using EmployeeAPIProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPIProject.Models
{
    public class MainContext : DbContext 
    {
        public DbSet<Employee> employees { get; set; }
        public DbSet<Project> projects { get; set; }

        public MainContext(DbContextOptions<MainContext> options) : base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Projects)
                .WithMany(p => p.Employees)
                .HasForeignKey(e => e.ProjectId);

            modelBuilder.Entity<Employee>()
               .Property(e => e.Salary)
               .HasPrecision(18, 2);

            modelBuilder.Entity<Project>()
                .Property(p => p.Budget)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    ProjectId = 1,
                    ProjectName = "E-Commerce Platform",
                    ProjectCode = "PRJ101",
                    StartDate = new DateTime(2025, 9, 1),
                    EndDate = new DateTime(2026, 3, 15),
                    Budget = 150000
                },
                new Project
                {
                    ProjectId = 2,
                    ProjectName = "AI Chatbot Integration",
                    ProjectCode = "PRJ102",
                    StartDate = new DateTime(2025, 10, 10),
                    EndDate = new DateTime(2026, 5, 30),
                    Budget = 250000
                }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee 
                { 
                    EmployeeId = 1, 
                    Name = "John Smith", 
                    Email = "john.smith@company.com", 
                    EmployeeCode = "EMP101", 
                    designation = "Full Stack Developer", 
                    Salary = 75000, 
                    ProjectId = 1 
                },
                new Employee 
                { 
                    EmployeeId = 2, 
                    Name = "Emma Johnson", 
                    Email = "emma.johnson@company.com", 
                    EmployeeCode = "EMP102", 
                    designation = "Project Lead", 
                    Salary = 95000, 
                    ProjectId = 2 
                }
            );
        }
    }
}
