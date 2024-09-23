using devCRUD.Models;
using System;

namespace devCRUD.Services
{
    /// <summary>
    /// interface developer Service
    /// </summary>
    public interface IDeveloperService
    {
        /// <summary>
        /// agrega o actualiza el registro
        /// </summary>
        /// <param name="person">objeto developer</param>
        /// <returns>valor bool con detalle de la operacion</returns>
        bool AddUpdate(Developer person);

        /// <summary>
        /// elimina un registro de la tabla
        /// </summary>
        /// <param name="id">identificador del registro a borrar</param>
        /// <returns>valor bool con detalle de la operacion</returns>
        bool Delete(Guid id);

        /// <summary>
        /// busca un dev por medio de su id
        /// </summary>
        /// <param name="id">identificador para la busqueda</param>
        /// <returns>objeto dev de la busqueda</returns>
        Developer FindById(Guid id);

        /// <summary>
        /// obtiene toda la tabla de devs
        /// </summary>
        /// <returns>listado de objetos con toda la info</returns>
        List<Developer> GetAll();
        
    }
}
