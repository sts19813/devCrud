using System.ComponentModel.DataAnnotations;

namespace devCRUD.Models
{
    public class Developer
    {
        /// <summary>
        /// propiedad para identificar el Dev tipo Guid
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// propiedad para el nombre del dev
        /// </summary>
        public string? name { get; set; }


        /// <summary>
        /// propiedad para el correo del dev
        /// </summary>
        public string? correo { get; set; }
    }
}
