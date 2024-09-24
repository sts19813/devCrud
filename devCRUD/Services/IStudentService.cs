using devCRUD.Models;
using devCRUD.Models.DTOs;

namespace devCRUD.Services
{
    /// <summary>
    /// Interfaz para el servicio de Student
    /// Define los métodos CRUD para la entidad Student.
    /// </summary>
    public interface IStudentService
    {
        /// <summary>
        /// Método para agregar o actualizar un estudiante.
        /// </summary>
        /// <param name="student">Objeto Student.</param>
        /// <returns>True si la operación fue exitosa, de lo contrario false.</returns>
        bool AddUpdate(Student student);

        /// <summary>
        /// Método para eliminar un estudiante por su ID.
        /// </summary>
        /// <param name="id">ID del estudiante a eliminar.</param>
        /// <returns>True si la operación fue exitosa, de lo contrario false.</returns>
        bool Delete(int id);

        /// <summary>
        /// Método para encontrar un estudiante por su ID.
        /// </summary>
        /// <param name="id">ID del estudiante a encontrar.</param>
        /// <returns>Objeto Student o null si no se encuentra.</returns>
        Student FindById(int id);

        /// <summary>
        /// Método para obtener todos los estudiantes.
        /// </summary>
        /// <returns>Lista de estudiantes.</returns>
        public List<StudentWithCourses> GetStudentsWithCourses();
    }
}
