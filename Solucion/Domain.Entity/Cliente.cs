using System;

namespace Domain.Entity
{
    public partial class Cliente
    {
        public int CodigoCliente { get; set; }
        public int Clientid { get; set; }
        public string Clave { get; set; }
        public bool Estado { get; set; }
        public int CodigoPersona { get; set; }

        public virtual Persona CodigoPersonaNavigation { get; set; }
    }
}
