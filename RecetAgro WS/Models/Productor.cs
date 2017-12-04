using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecetAgro_WS.Models
{
    public class Productor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Apellido paterno")]
        public string ApellidoPaterno { get; set; }
        
        [StringLength(50)]
        [Display(Name = "Apellido materno")]
        public string ApellidoMaterno { get; set; }
        
        [StringLength(50)]
        [Display(Name = "Teléfono")]
        [Phone]
        public string Telefono { get; set; }

        [StringLength(50)]
        [Display(Name = "Correo electrónico")]
        [EmailAddress]
        public string Email { get; set; }

        public IList<Huerto> Huertos { get; set; }

    }
}