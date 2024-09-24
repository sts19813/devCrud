namespace devCRUD.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public int Credits { get; set; }

        public ICollection<Enrollments> Enrollments { get; set; } // Relación con Enrollment
        public ICollection<CourseAssignments> CourseAssignments { get; set; } // Relación con CourseAssignment
    }
}
