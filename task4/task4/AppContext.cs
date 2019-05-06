using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace task4
{
    class Project
    {
        public int Id { get; set; }
        public Worker Worker { get; set; }
        public string Name { get; set; }
        public int Premium { get; set; }        
    }

    class Worker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }

    class AppContext : DbContext
    {

        public DbSet<Worker> Workers { get; set; }
        public DbSet<Project> Projects { get; set; }
        //public DbSet<WorkerProject> WorkerProjects { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies();
            //optionsBuilder.UseMySQL("Server=(localdb)\\MSSQLLocalDB;Database=TestDB; Trusted_Connection=True;");
            //optionsBuilder.UseSqlServer(@"Data Source = (localdb)\\MSSQLLocalDB;Database=TestDB;
            //Integrated Security = True; Connect Timeout = 30; Encrypt = False; 
            //TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Database=DBTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //("Server=(localdb)\\MSSQLLocalDB;Database=TestDB; Trusted_Connection=True;");
        }
    }
}
