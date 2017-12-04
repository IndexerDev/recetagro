using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecetAgro_WS.Models
{
    public class Huerto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sagarpa { get; set; }
        public string Ubicacion { get; set; }

        public int ProductorId { get; set; }
        public Productor Productor { get; set; }
    }
}