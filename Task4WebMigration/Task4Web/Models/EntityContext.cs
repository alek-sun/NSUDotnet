using System.Collections.Generic;
using System.Linq;

namespace Task4Web.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Premium { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }

    public class Worker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public int Total => Enrollments.Select(v => v.Project.Premium).Sum();

        public ICollection<Enrollment> Enrollments { get; set; }
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int ProjectID { get; set; }
        public int WorkerID { get; set; }

        public Worker Worker { get; set; }
        public Project Project { get; set; }
    }
}
