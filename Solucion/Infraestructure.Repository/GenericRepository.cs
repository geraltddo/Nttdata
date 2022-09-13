using Common;
using Infraestructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class GenericRepository<TEntity> : BaseRepository<TEntity>, IGenericRepository<TEntity> where TEntity : class
    {
        public GenericRepository(IDbContext dbContext) : base(dbContext) { }

        #region Métidos síncronos
        public virtual int Insert(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            return _dbContext.SaveChanges();
        }

        public virtual int Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            return _dbContext.SaveChanges();
        }

        public virtual int Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            return _dbContext.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().AsNoTracking().FirstOrDefault(predicate);
        }
        public IEnumerable<TEntity> GetAllFiltered(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().AsNoTracking().Where(predicate).ToList();
        }
        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _dbContext.Set<TEntity>().ToList();
            }
            catch
            {
                throw;
            }
        }

        public PagedResult<TEntity> GetDataPaginated(Expression<Func<TEntity, bool>> predicate, int page, int pageSize)
        {
            try
            {
                if (predicate != null)
                {
                    var func = predicate.Compile();
                    return _dbContext.Set<TEntity>().Where(o => func(o)).GetPaginatedData(page, pageSize);
                }
                else return null;
            }
            catch
            {
                throw;
            }
        }

        public PagedResult<TEntity> GetDataPaginatedAll(int page, int pageSize)
        {
            try
            {
                return _dbContext.Set<TEntity>().GetPaginatedData(page, pageSize);
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region Métodos Asíncronos

        public async Task<int> InsertAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity).ConfigureAwait(false);
            var afectados = await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return afectados;
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            var afectados = await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return afectados;
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            var afectados = await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return afectados;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>().Where(predicate).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync().ConfigureAwait(false);
        }

        #endregion
    }
}
