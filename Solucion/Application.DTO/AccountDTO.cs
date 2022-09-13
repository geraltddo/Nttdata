using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class AccountDTO
    {
        public int CodigoCuenta { get; set; }
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal? SaldoInicial { get; set; }
        public bool? Estado { get; set; }
    }
}
