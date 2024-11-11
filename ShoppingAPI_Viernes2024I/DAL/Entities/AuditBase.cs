using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI_Viernes2024I.DAL.Entities
{
    public class AuditBase
    {
        [Key]//PK
        [Required]// Significa que el campo es obligatorio

        public virtual Guid id  {get; set;} //Esta sera la PK de todas las tablas
        public virtual DateTime? CreatedDate {get; set;} // Guardar todo registro nuevo con su fecha
        public virtual DateTime? ModifiedDate  {get; set;} // guardar registro que se modificon con su fecha
    }
}
