using Common;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface ITransactionDomain
    {
        #region Métodos Síncronos

        int Insert(Movimiento entity);
        int Update(Movimiento entity);
        int Delete(int codigoMovimiento);
        Movimiento Get(int codigoMovimiento);
        IEnumerable<Movimiento> GetAll();
        PagedResult<Movimiento> GetDataPaginated(Expression<Func<Movimiento, bool>> predicate, int page, int pageSize);
        PagedResult<Movimiento> GetDataPaginatedAll(int page, int pageSize);

        #endregion

        #region Métodos Asíncronos

        Task<int> InsertAsync(Movimiento entity);
        Task<int> UpdateAsync(Movimiento entity);
        Task<int> DeleteAsync(int codigoMovimiento);
        Task<Movimiento> GetAsync(int codigoMovimiento);
        Task<IEnumerable<Movimiento>> GetAllAsync();

        #endregion
    }
}
