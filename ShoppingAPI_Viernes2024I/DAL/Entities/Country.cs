﻿using System.ComponentModel.DataAnnotations;
using WebAPI.ShoppingAPI_Viernes2024I.DAL.Entities;

namespace ShoppingAPI_Viernes2024I.DAL.Entities
{
    public class Country:AuditBase
    {
        [Display (Name= "Pais")]//identificar nombre mas facil
        [MaxLength(50, ErrorMessage = "el campo {0} debe tener maximo {1} caracteres ")] //longitud Maxima
        [Required (ErrorMessage = "Es campo {0} es obligatorio ")] //Campo Obligatoria
        public string Name { get; set; }

        [Display(Name = "Estados/Departamentos")]
        public ICollection<State>? States { get; set; }
    }
}
