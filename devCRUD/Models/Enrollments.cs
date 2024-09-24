namespace devCRUD.Models
{
    public class Enrollments
    {

        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public decimal Grade { get; set; }

        public Student Student { get; set; } // Relación con Student
        public Course Course { get; set; } // Relación con Course
    }
}
