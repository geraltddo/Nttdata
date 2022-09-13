using Common;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IAccountDomain
    {
        #region Métodos Síncronos

        int Insert(Cuenta entity);
        int Update(Cuenta entity);
        int Delete(string NumeroCuenta);
        Cuenta Get(string NumeroCuenta);
        IEnumerable<Cuenta> GetAll();
        PagedResult<Cuenta> GetDataPaginated(Expression<Func<Cuenta, bool>> predicate, int page, int pageSize);
        PagedResult<Cuenta> GetDataPaginatedAll(int page, int pageSize);

        #endregion

        #region Métodos Asíncronos

        Task<int> InsertAsync(Cuenta entity);
        Task<int> UpdateAsync(Cuenta entity);
        Task<int> DeleteAsync(string NumeroCuenta);
        Task<Cuenta> GetAsync(string NumeroCuenta);
        Task<IEnumerable<Cuenta>> GetAllAsync();

        #endregion
    }
}
