namespace devCRUD.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<CourseAssignments> CourseAssignments { get; set; } // Relación con CourseAssignment

    }
}
