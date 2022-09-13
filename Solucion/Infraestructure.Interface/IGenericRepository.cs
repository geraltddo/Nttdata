using System;
using Common;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        #region Métodos Síncronos
        int Insert(TEntity entity);
        int Update(TEntity entity);
        int Delete(TEntity entity);
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAllFiltered(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll();
        PagedResult<TEntity> GetDataPaginated(Expression<Func<TEntity, bool>> predicate, int page, int pageSize);
        PagedResult<TEntity> GetDataPaginatedAll(int page, int pageSize);

        #endregion


        #region Métodos Asíncronos

        Task<int> InsertAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> DeleteAsync(TEntity entity);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync();

        #endregion
    }
}
