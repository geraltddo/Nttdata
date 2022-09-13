using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class PersonDTO
    {
        public int CodigoPersona { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public int? Edad { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}
