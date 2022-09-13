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
    public class AccountDomain: IAccountDomain
    {
        private readonly IAccountRepository _accountRepository;
        public AccountDomain(IAccountRepository accountRepository) 
        {
            this._accountRepository = accountRepository;
        }

        #region Métodos Síncronos

        public int Insert(Cuenta entity)
        {
            return _accountRepository.Insert(entity);
        }

        public int Update(Cuenta entity)
        {
            return _accountRepository.Update(entity);
        }

        public int Delete(string numeroCuenta)
        {
            var entity = Get(numeroCuenta);
            return _accountRepository.Delete(entity);
        }

        public Cuenta Get(string numeroCuenta)
        {
            return _accountRepository.Get(x => x.NumeroCuenta == numeroCuenta);
        }

        public IEnumerable<Cuenta> GetAll()
        {
            return _accountRepository.GetAll();
        }
        public PagedResult<Cuenta> GetDataPaginated(Expression<Func<Cuenta, bool>> predicate, int page, int pageSize)
        {
            return _accountRepository.GetDataPaginated(predicate, page, pageSize);
        }

        public PagedResult<Cuenta> GetDataPaginatedAll(int page, int pageSize)
        {
            return _accountRepository.GetDataPaginatedAll(page, pageSize);
        }

        #endregion


        #region Métodos Asíncronos

        public async Task<int> InsertAsync(Cuenta entity)
        {
            return await _accountRepository.InsertAsync(entity);
        }

        public async Task<int> UpdateAsync(Cuenta entity)
        {
            return await _accountRepository.UpdateAsync(entity);
        }

        public async Task<int> DeleteAsync(string numeroCuenta)
        {
            var entity = Get(numeroCuenta);
            return await _accountRepository.DeleteAsync(entity);
        }

        public async Task<Cuenta> GetAsync(string numeroCuenta)
        {
            return await _accountRepository.GetAsync(x => x.NumeroCuenta == numeroCuenta);
        }

        public async Task<IEnumerable<Cuenta>> GetAllAsync()
        {
            return await _accountRepository.GetAllAsync();
        }

        #endregion
    }
}
