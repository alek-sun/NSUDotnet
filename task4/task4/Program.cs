using System;
using System.Collections.Generic;
using System.Linq;

namespace task4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var ctx = new AppContext())
            {
                // check creating
                ctx.Database.EnsureCreated();
                /*ctx.Workers.Add(new Worker { FirstName = "Ivan", LastName = "Krylov" });
                ctx.SaveChanges();

                var list = ctx.Workers;
                list.GroupBy(e => e.Id).Select(e => new { e.Key, Values = e.Select(v => v.FirstName) }).ToList();

                foreach (var el in list.GroupBy(e => e.FirstName, e => e))
                {
                    Console.WriteLine($"{el.Key}");
                }
                */
            }
            DeleteAllProjects();
            DeleteAllWorkers();            

            AddWorker("Ivan", "Sobolev", "Ivanovich");
            AddWorker("Nikolay", "Sokolov", "Ivanovich");
            AddWorker("Sergey", "Losev", "Alekseevich");

            AddProject("Skype", 5000, "Ivan", "Sobolev");
            AddProject("Uno", 1000, "Nikolay", "Sokolov");
            AddProject("Uno", 4000, "Sergey", "Losev");
            AddProject("Skype", 5000, "Sergey", "Losev");
            AddProject("Rally", 7000, "Ivan", "Sobolev");
            AddProject("Music box", 9000, "Nikolay", "Sokolov");
            
            GetWorkersProject("Ivan", "Sobolev");
            GetWorkersProject("Nikolay", "Sokolov");
            GetWorkersProject("Sergey", "Losev");
            GetWorkersPremium();
            GetWorkers();
            Console.ReadKey();            
        }


        public static void AddProject(string name, int premium, string firstName, string lastName)
        {
            using (var ctx = new AppContext())
            {
                var w = ctx.Workers.First(e => e.FirstName == firstName && e.LastName == lastName);
                ctx.Projects.Add(new Project { Name = name, Premium = premium,  Worker = w});
                ctx.SaveChanges();
            }
        }


        public static void AddWorker(string firstName, string lastName, string patronymic)
        {
            using (var ctx = new AppContext())
            {
                ctx.Workers.Add(new Worker { FirstName = firstName, LastName = lastName, Patronymic = patronymic });
                ctx.SaveChanges();
            }
        }

        public static void DeleteWorker(int workerId)
        {
            using (var ctx = new AppContext())
            {
                var w = ctx.Workers.First(e => e.Id == workerId);
                ctx.Workers.Remove(w);
                ctx.SaveChanges();
            }
        }

        public static void DeleteProject(string projectName)
        {
            using (var ctx = new AppContext())
            {
                var p = ctx.Projects.First(e => e.Name == projectName);
                ctx.Projects.Remove(p);
                ctx.SaveChanges();
            }
        }

        public static void DeleteAllProjects()
        {
            using (var ctx = new AppContext())
            {
                ctx.Projects.RemoveRange(ctx.Projects);
                ctx.SaveChanges();
            }
        }

        public static void DeleteAllWorkers()
        {
            using (var ctx = new AppContext())
            {
                ctx.Workers.RemoveRange(ctx.Workers);
                ctx.SaveChanges();
            }
        }

        private static void GetWorkersProject(string firstName, string lastName)
        {
            using (var ctx = new AppContext())
            {
                var w = ctx.Workers.First(e => e.FirstName == firstName && e.LastName == lastName);
                var projects = ctx.Projects.Where(e => e.Worker == w).ToList();
                Console.WriteLine($"---------------Projects for worker {w.FirstName} {w.LastName} ---------------");
                foreach (var p in projects)
                {
                    Console.WriteLine($"{p.Id} {p.Name} {p.Premium}");
                }
            }
        }

        private static void GetWorkersPremium()
        {
            using (var ctx = new AppContext())
            {
                Console.WriteLine($"ID | First name | Last name | Premium");
                /*foreach (var w in ctx.Workers)
                {
                    var premium = w.Projects.Select(e => e.Premium).Sum();
                    Console.WriteLine($"{w.Id} {w.FirstName} {w.LastName} {premium}");
                }*/

                var list = ctx.Workers.Select(e => 
                    new { e.Id, e.FirstName, e.LastName, Premium = e.Projects.Select(v => v.Premium).Sum() }).OrderByDescending(el => el.Premium);
                foreach (var el in list)
                {
                    Console.WriteLine($"{el.Id} {el.FirstName} {el.LastName} {el.Premium}");
                }
            }
        }

        /*private static void SetWorkerProject(int workerId, int projectId)
        {
            using (var ctx = new AppContext())
            {
                ctx.WorkerProjects.Add(new WorkerProject { WorkerId = workerId, ProjectId = projectId });
                ctx.SaveChanges();
            }
        }*/

        private static void GetWorkers()
        {
            Console.WriteLine("==============Workers===============");
            using (var ctx = new AppContext())
            {               
                foreach (var w in ctx.Workers)
                {
                    Console.WriteLine($"{w.Id} {w.FirstName} {w.LastName}");
                }
            }
        }


        // EXTENTIONS

        /*public enum UserType
        {
            Admin,
            User,
            Unknown
        }
        static class UserExtensions
        {   
            public static string ToFriendlyString(this UserType type)
            {
                if (type.Equals(UserType.Admin))
                {
                    return "Администратор";
                }
                if (type.Equals(UserType.User))
                {
                    return "Пользователь";
                }
                else
                {
                    return "Неизвестный";
                } 
            }
        }
        */
    }
}