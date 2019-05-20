namespace Task4Web.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int ProjectID { get; set; }
        public int WorkerID { get; set; }

        public Worker Worker { get; set; }
        public Project Project { get; set; }
    }
}
