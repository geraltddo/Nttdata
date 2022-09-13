using Common;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IClientDomain
    {
        #region Métodos Síncronos

        int Insert(Cliente entity);
        int Update(Cliente entity);
        int Delete(int Clientid);
        Cliente Get(int Clientid);
        IEnumerable<Cliente> GetAll();
        PagedResult<Cliente> GetDataPaginated(Expression<Func<Cliente, bool>> predicate, int page, int pageSize);
        PagedResult<Cliente> GetDataPaginatedAll(int page, int pageSize);

        #endregion

        #region Métodos Asíncronos

        Task<int> InsertAsync(Cliente entity);
        Task<int> UpdateAsync(Cliente entity);
        Task<int> DeleteAsync(int Clientid);
        Task<Cliente> GetAsync(int Clientid);
        Task<IEnumerable<Cliente>> GetAllAsync();

        #endregion
    }
}
