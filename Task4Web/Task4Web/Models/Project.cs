using System.Collections.Generic;

namespace Task4Web.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Premium { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
