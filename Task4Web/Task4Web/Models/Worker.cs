using System.Collections.Generic;
using System.Linq;

namespace Task4Web.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        //public int Total => Enrollments.Select(v => v.Project.Premium).Sum();
        public int _Total;      

        public int Total
        {
            get
            {
                if (Enrollments != null)
                {
                    return Enrollments.Select(v => v.Project.Premium).Sum();
                }
                else
                {
                    return 0;
                }
            }
        }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
