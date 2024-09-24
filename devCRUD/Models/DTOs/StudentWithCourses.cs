namespace devCRUD.Models.DTOs
{
    public class StudentWithCourses
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public List<string> Courses { get; set; }
    }
}
