using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public partial class Persona
    {
        public Persona()
        {
            Cliente = new HashSet<Cliente>();
        }

        public int CodigoPersona { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public int? Edad { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}
