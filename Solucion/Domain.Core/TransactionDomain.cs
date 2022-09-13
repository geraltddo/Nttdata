using Common;
using Domain.Entity;
using Domain.Interface;
using Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public class TransactionDomain: ITransactionDomain
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionDomain(ITransactionRepository transactionRepository)
        {
            this._transactionRepository = transactionRepository;
        }

        #region Métodos Síncronos

        public int Insert(Movimiento entity)
        {
            return _transactionRepository.Insert(entity);
        }

        public int Update(Movimiento entity)
        {
            return _transactionRepository.Update(entity);
        }

        public int Delete(int codigoMovimiento)
        {
            var entity = Get(codigoMovimiento);
            return _transactionRepository.Delete(entity);
        }

        public Movimiento Get(int codigoMovimiento)
        {
            return _transactionRepository.Get(x => x.CodigoMovimiento == codigoMovimiento);
        }

        public IEnumerable<Movimiento> GetAll()
        {
            return _transactionRepository.GetAll();
        }
        public PagedResult<Movimiento> GetDataPaginated(Expression<Func<Movimiento, bool>> predicate, int page, int pageSize)
        {
            return _transactionRepository.GetDataPaginated(predicate, page, pageSize);
        }

        public PagedResult<Movimiento> GetDataPaginatedAll(int page, int pageSize)
        {
            return _transactionRepository.GetDataPaginatedAll(page, pageSize);
        }

        #endregion


        #region Métodos Asíncronos

        public async Task<int> InsertAsync(Movimiento entity)
        {
            return await _transactionRepository.InsertAsync(entity);
        }

        public async Task<int> UpdateAsync(Movimiento entity)
        {
            return await _transactionRepository.UpdateAsync(entity);
        }

        public async Task<int> DeleteAsync(int codigoMovimiento)
        {
            var entity = Get(codigoMovimiento);
            return await _transactionRepository.DeleteAsync(entity);
        }

        public async Task<Movimiento> GetAsync(int codigoMovimiento)
        {
            return await _transactionRepository.GetAsync(x => x.CodigoMovimiento == codigoMovimiento);
        }

        public async Task<IEnumerable<Movimiento>> GetAllAsync()
        {
            return await _transactionRepository.GetAllAsync();
        }

        #endregion
    }
}
