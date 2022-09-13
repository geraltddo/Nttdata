using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public abstract class PagedResultBase
    {
        public int PaginaActual { get; set; }
        public int TotalPaginas { get; set; }
        public int TamanoPagina { get; set; }
        public int Filas { get; set; }

        public int PrimeraFilaEnPagina
        {

            get { return PaginaActual == 0 ? 1 : (PaginaActual - 1) * TamanoPagina + 1; }
        }

        public int UltimaFilaEnPagina
        {
            get { return Math.Min(PaginaActual * TamanoPagina, Filas); }
        }
    }

    public class PagedResult<T> : PagedResultBase where T : class
    {
        public IEnumerable<T> Registros { get; set; }

        public PagedResult()
        {
            Registros = new List<T>();
        }
    }
}
