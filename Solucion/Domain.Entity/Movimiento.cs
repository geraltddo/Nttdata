using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public partial class Movimiento
    {
        public int CodigoMovimiento { get; set; }
        public string Fecha { get; set; }
        public string TipoMovimiento { get; set; }
        public decimal? Valor { get; set; }
        public decimal? Saldo { get; set; }
    }
}
