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
    public class ClientDomain : IClientDomain
    {
        private readonly IClientRepository _clientRepository;

        public ClientDomain(IClientRepository clientRepository)
        {
            this._clientRepository = clientRepository;
        }

        #region Métodos Síncronos

        public int Insert(Cliente entity)
        {
            return _clientRepository.Insert(entity);
        }

        public int Update(Cliente entity)
        {
            return _clientRepository.Update(entity);
        }

        public int Delete(int Clientid)
        {
            var entity = Get(Clientid);
            return _clientRepository.Delete(entity);
        }

        public Cliente Get(int Clientid)
        {
            return _clientRepository.Get(x => x.Clientid == Clientid);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _clientRepository.GetAll();
        }
        public PagedResult<Cliente> GetDataPaginated(Expression<Func<Cliente, bool>> predicate, int page, int pageSize)
        {
            return _clientRepository.GetDataPaginated(predicate, page, pageSize);
        }

        public PagedResult<Cliente> GetDataPaginatedAll(int page, int pageSize)
        {
            return _clientRepository.GetDataPaginatedAll(page, pageSize);
        }

        #endregion


        #region Métodos Asíncronos

        public async Task<int> InsertAsync(Cliente entity)
        {
            return await _clientRepository.InsertAsync(entity);
        }

        public async Task<int> UpdateAsync(Cliente entity)
        {
            return await _clientRepository.UpdateAsync(entity);
        }

        public async Task<int> DeleteAsync(int Clientid)
        {
            var entity = Get(Clientid);
            return await _clientRepository.DeleteAsync(entity);
        }

        public async Task<Cliente> GetAsync(int Clientid)
        {
            return await _clientRepository.GetAsync(x => x.Clientid == Clientid);
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _clientRepository.GetAllAsync();
        }

        #endregion
    }
}
