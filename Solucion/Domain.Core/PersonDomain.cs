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
    public class PersonDomain: IPersonDomain
    {
        private readonly IPersonRepository _personRepository;
        public PersonDomain(IPersonRepository personRepository) 
        {
            this._personRepository = personRepository;
        }

        #region Métodos Síncronos

        public int Insert(Persona entity)
        {
            return _personRepository.Insert(entity);
        }

        public int Update(Persona entity)
        {
            return _personRepository.Update(entity);
        }

        public int Delete(string numeroPersona)
        {
            var entity = Get(numeroPersona);
            return _personRepository.Delete(entity);
        }

        public Persona Get(string identificacion)
        {
            return _personRepository.Get(x => x.Identificacion == identificacion);
        }

        public IEnumerable<Persona> GetAll()
        {
            return _personRepository.GetAll();
        }
        public PagedResult<Persona> GetDataPaginated(Expression<Func<Persona, bool>> predicate, int page, int pageSize)
        {
            return _personRepository.GetDataPaginated(predicate, page, pageSize);
        }

        public PagedResult<Persona> GetDataPaginatedAll(int page, int pageSize)
        {
            return _personRepository.GetDataPaginatedAll(page, pageSize);
        }

        #endregion


        #region Métodos Asíncronos

        public async Task<int> InsertAsync(Persona entity)
        {
            return await _personRepository.InsertAsync(entity);
        }

        public async Task<int> UpdateAsync(Persona entity)
        {
            return await _personRepository.UpdateAsync(entity);
        }

        public async Task<int> DeleteAsync(string numeroPersona)
        {
            var entity = Get(numeroPersona);
            return await _personRepository.DeleteAsync(entity);
        }

        public async Task<Persona> GetAsync(string identificacion)
        {
            return await _personRepository.GetAsync(x => x.Identificacion == identificacion);
        }

        public async Task<IEnumerable<Persona>> GetAllAsync()
        {
            return await _personRepository.GetAllAsync();
        }

        #endregion
    }
}
