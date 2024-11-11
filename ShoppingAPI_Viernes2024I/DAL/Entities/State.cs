using ShoppingAPI_Viernes2024I.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.ShoppingAPI_Viernes2024I.DAL.Entities
{
    public class State : AuditBase
    {
        [Display(Name = "Estado/Departamento")]//identificar nombre mas facil
        [MaxLength(50, ErrorMessage = "el campo {0} debe tener maximo {1} caracteres ")] //longitud Maxima
        [Required(ErrorMessage = "Es campo {0} es obligatorio ")] //Campo Obligatoria

        public String Name { get; set; }
        //Así realacionamos 2 tablas con Entity Framework Core
        [Display(Name = "País")]
        public Country? Country { get; set; }

        //Foreign key
        [Display(Name = "Id País")]
        public Guid? CountryId { get; set; }

    }
}
