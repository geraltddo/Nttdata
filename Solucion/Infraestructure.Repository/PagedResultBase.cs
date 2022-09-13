using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infraestructure.Repository
{
    public static class PagedResultBase
    {
        /// <summary>
        /// Obtiene la información del Entity actual y lo pagina, retornando un Result de tipo IList
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static PagedResult<T> GetPaginatedData<T>(this IQueryable<T> query, int page, int pageSize) where T : class
        {
            var result = new PagedResult<T>();
            result.PaginaActual = page;
            result.TamanoPagina = pageSize;
            result.Filas = query.Count();


            var pageCount = (double)result.Filas / pageSize;
            result.TotalPaginas = (int)Math.Ceiling(pageCount);

            var skip = page == 0 ? 0 : page * pageSize;

            result.Registros = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }
    }
}
