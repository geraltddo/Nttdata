using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public partial class Cuenta
    {
        public int CodigoCuenta { get; set; }
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal? SaldoInicial { get; set; }
        public bool? Estado { get; set; }
    }
}
