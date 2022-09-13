using Application.DTO;
using Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IAccountApplication
    {
        #region Métodos Síncronos

        Response<bool> Insert(AccountDTO entityDTO);
        Response<bool> Update(AccountDTO entityDTO);
        Response<bool> Delete(string numeroCuenta);
        Response<AccountDTO> Get(string numeroCuenta);
        Response<IEnumerable<AccountDTO>> GetAll();
        Response<PagedResult<AccountDTO>> GetDataPaginated(string campo, string filtro, int page, int pageSize);
        Response<PagedResult<AccountDTO>> GetDataPaginatedAll(int page, int pageSize);

        #endregion


        #region Métodos Asíncronos

        Task<Response<bool>> InsertAsync(AccountDTO entityDTO);
        Task<Response<bool>> UpdateAsync(AccountDTO entityDTO);
        Task<Response<bool>> DeleteAsync(string numeroCuenta);
        Task<Response<AccountDTO>> GetAsync(string numeroCuenta);
        Task<Response<IEnumerable<AccountDTO>>> GetAllAsync();

        #endregion
    }
}
