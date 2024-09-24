namespace devCRUD.Models
{
    public class CourseAssignments
    {
        public int AssignmentId { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
        public DateTime AssignmentDate { get; set; }

        public Course Course { get; set; } // Relación con Course
        public Teacher Teacher { get; set; } // Relación con Teacher
    }
}
