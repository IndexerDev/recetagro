using RecetAgro_WS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecetAgro_WS.Dtos
{
    public class ProductorDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]        
        public string ApellidoPaterno { get; set; }

        [StringLength(50)]        
        public string ApellidoMaterno { get; set; }

        [StringLength(50)]        
        [Phone]
        public string Telefono { get; set; }

        [StringLength(50)]        
        [EmailAddress]
        public string Email { get; set; }
        
    }
}