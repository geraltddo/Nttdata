using Common;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IPersonDomain
    {
        #region Métodos Síncronos

        int Insert(Persona entity);
        int Update(Persona entity);
        int Delete(string identificacion);
        Persona Get(string identificacion);
        IEnumerable<Persona> GetAll();
        PagedResult<Persona> GetDataPaginated(Expression<Func<Persona, bool>> predicate, int page, int pageSize);
        PagedResult<Persona> GetDataPaginatedAll(int page, int pageSize);

        #endregion

        #region Métodos Asíncronos

        Task<int> InsertAsync(Persona entity);
        Task<int> UpdateAsync(Persona entity);
        Task<int> DeleteAsync(string identificacion);
        Task<Persona> GetAsync(string identificacion);
        Task<IEnumerable<Persona>> GetAllAsync();

        #endregion
    }
}
