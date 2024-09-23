using devCRUD.Models;

namespace devCRUD.Services
{
    /// <summary>
    /// class de servicio Developer, aqui estan los metodos crud 
    /// nota: implemtenta interfaz IDeveloperService
    /// </summary>
    public class DeveloperService: IDeveloperService
    {
        /// <summary>
        /// contexto
        /// </summary>
        private readonly DatabaseContext _ctx;

        /// <summary>
        /// contructor de la clase
        /// </summary>
        /// <param name="ctx">contexto</param>
        public DeveloperService(DatabaseContext ctx)
        {
            _ctx = ctx;
        }

        /// <summary>
        /// metodo para actualizar o agregar nuevo dev
        /// nota: la diferencia en add o update es por el id del developer. si no existe o existe
        /// </summary>
        /// <param name="Dev">objeto dev</param>
        /// <returns>bool con el resultado de la operacion</returns>
        public bool AddUpdate(Developer Dev)
        {
            try
            {
                if (Dev.Id == null)
                    _ctx.Developers.Add(Dev);
                else
                    _ctx.Developers.Update(Dev);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// elimina un dev
        /// </summary>
        /// <param name="id">guid con el id del dev a eliminar</param>
        /// <returns>bool con el resultado de la operacion</returns>
        public bool Delete(Guid id)
        {
            try
            {
                var person = FindById(id);
                if (person == null)
                    return false;
                _ctx.Developers.Remove(person);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        /// <summary>
        /// encuentra/obtiene un dev
        /// </summary>
        /// <param name="id">guid del dev a encontrar</param>
        /// <returns>objeto developer</returns>
        public Developer FindById(Guid id)
        {
            return _ctx.Developers.Find(id);
        }

        
        /// <summary>
        /// obtiene todos los  dev de la tabla
        /// </summary>
        /// <returns>listado de objetos developers</returns>
        public List<Developer> GetAll()
        {
            return _ctx.Developers.ToList();
        }

    }
}
