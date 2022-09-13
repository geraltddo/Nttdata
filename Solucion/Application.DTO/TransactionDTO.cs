using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class TransactionDTO
    {
        public int CodigoMovimiento { get; set; }
        public string Fecha { get; set; }
        public string TipoMovimiento { get; set; }
        public decimal? Valor { get; set; }
        public decimal? Saldo { get; set; }
    }
}
