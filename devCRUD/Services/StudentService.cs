using devCRUD.Models;
using devCRUD.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace devCRUD.Services
{
    /// <summary>
    /// Clase de servicio para Student, contiene métodos CRUD.
    /// Implementa la interfaz IStudentService.
    /// </summary>
    public class StudentService : IStudentService
    {

        /// <summary>
        /// Contexto de la base de datos.
        /// </summary>
        private readonly DatabaseContext _ctx;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="ctx">Contexto de la base de datos.</param>
        public StudentService(DatabaseContext ctx)
        {
            _ctx = ctx;
        }

        /// <summary>
        /// Método para agregar o actualizar un estudiante.
        /// Si el ID del estudiante no existe, se agrega, si existe, se actualiza.
        /// </summary>
        /// <param name="student">Objeto Student.</param>
        /// <returns>True si la operación fue exitosa, de lo contrario false.</returns>
        public bool AddUpdate(Student student)
        {
            try
            {
                if (student.StudentId == 0)
                    _ctx.Students.Add(student);
                else
                    _ctx.Students.Update(student);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Aquí podrías agregar un registro del error si es necesario
                return false;
            }
        }

        /// <summary>
        /// Método para eliminar un estudiante.
        /// </summary>
        /// <param name="id">ID del estudiante a eliminar.</param>
        /// <returns>True si la operación fue exitosa, de lo contrario false.</returns>
        public bool Delete(int id)
        {
            try
            {
                var student = FindById(id);
                if (student == null)
                    return false;
                _ctx.Students.Remove(student);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Aquí podrías agregar un registro del error si es necesario
                return false;
            }
        }

        /// <summary>
        /// Método para encontrar un estudiante por su ID.
        /// </summary>
        /// <param name="id">ID del estudiante.</param>
        /// <returns>Objeto Student o null si no se encuentra.</returns>
        public Student FindById(int id)
        {
            return _ctx.Students.Find(id);
        }

        /// <summary>
        /// Método para obtener todos los estudiantes.
        /// </summary>
        /// <returns>Lista de estudiantes.</returns>
        public List<Student> GetAll()
        {
            return _ctx.Students.ToList();
        }

        public List<StudentWithCourses> GetStudentsWithCourses()
        {
            List<StudentWithCourses> studentsWithCourses = _ctx.Students
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Course)
                .Select(s => new StudentWithCourses
                {
                    StudentId = s.StudentId,
                    FullName = $"{s.FirstName} {s.LastName}",
                    Courses = s.Enrollments.Select(e => e.Course.CourseName).ToList()
                })
                .ToList();

            return studentsWithCourses;
        }
    }
}
