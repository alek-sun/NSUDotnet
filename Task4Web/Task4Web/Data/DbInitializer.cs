using System.Linq;
using Task4Web.Models;

namespace Task4Web.Data
{
    public class DbInitializer
    {
        public static void Initialize(EffectiveWorkerContext context)
        {
            context.Database.EnsureCreated();

            if (context.Workers.Any())
            {
                return;   
            }

            var workers = new Worker[]
            {
            new Worker{FirstName="Nino",LastName="Olivetto",Patronymic=""},
            new Worker{FirstName="Paulo",LastName="Anand",Patronymic=""},
            new Worker{FirstName="Nikolas",LastName="Olivetto",Patronymic=""},
            new Worker{FirstName="Albert",LastName="Alonso",Patronymic=""},
            new Worker{FirstName="Ann",LastName="Alonso",Patronymic=""}
            };

            foreach (var w in workers)
            {
                context.Workers.AddAsync(w);
            }
            context.SaveChanges();

            var projects = new Project[]
            {
            new Project{Name="Skype", Premium=5000},
            new Project{Name="Uno", Premium=4000 },
            new Project{Name="Rally", Premium=7000},
            new Project{Name="Music box", Premium=6000},
            new Project{Name="Painter", Premium=3000 }
            };
            foreach (var p in projects)
            {
                context.Projects.AddAsync(p);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
            new Enrollment{WorkerID = 1, ProjectID = 1},
            new Enrollment{WorkerID = 2, ProjectID = 2},
            new Enrollment{WorkerID = 3, ProjectID = 4},
            new Enrollment{WorkerID = 4, ProjectID = 3},
            new Enrollment{WorkerID = 5, ProjectID = 1},
            new Enrollment{WorkerID = 5, ProjectID = 2},
            new Enrollment{WorkerID = 2, ProjectID = 3},
            new Enrollment{WorkerID = 4, ProjectID = 1},
            new Enrollment{WorkerID = 3, ProjectID = 5},
            new Enrollment{WorkerID = 2, ProjectID = 5},
            new Enrollment{WorkerID = 1, ProjectID = 4},
            };

            foreach (var e in enrollments)
            {
                context.Enrollment.Add(e);
            }
            context.SaveChanges();
        }
    }
}
