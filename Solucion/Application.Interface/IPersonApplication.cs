using Application.DTO;
using Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IPersonApplication
    {
        #region Métodos Síncronos

        Response<bool> Insert(PersonDTO entityDTO);
        Response<bool> Update(PersonDTO entityDTO);
        Response<bool> Delete(string identificacion);
        Response<PersonDTO> Get(string identificacion);
        Response<IEnumerable<PersonDTO>> GetAll();
        Response<PagedResult<PersonDTO>> GetDataPaginated(string campo, string filtro, int page, int pageSize);
        Response<PagedResult<PersonDTO>> GetDataPaginatedAll(int page, int pageSize);

        #endregion


        #region Métodos Asíncronos

        Task<Response<bool>> InsertAsync(PersonDTO entityDTO);
        Task<Response<bool>> UpdateAsync(PersonDTO entityDTO);
        Task<Response<bool>> DeleteAsync(string identificacion);
        Task<Response<PersonDTO>> GetAsync(string identificacion);
        Task<Response<IEnumerable<PersonDTO>>> GetAllAsync();

        #endregion
    }
}
