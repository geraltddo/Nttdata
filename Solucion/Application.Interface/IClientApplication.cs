using Application.DTO;
using Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Main
{
    public interface IClientApplication
    {
        #region Métodos Síncronos

        Response<bool> Insert(ClientDTO entityDTO);
        Response<bool> Update(ClientDTO entityDTO);
        Response<bool> Delete(int Clientid);
        Response<ClientDTO> Get(int Clientid);
        Response<IEnumerable<ClientDTO>> GetAll();
        Response<PagedResult<ClientDTO>> GetDataPaginated(string campo, string filtro, int page, int pageSize);
        Response<PagedResult<ClientDTO>> GetDataPaginatedAll(int page, int pageSize);

        #endregion


        #region Métodos Asíncronos

        Task<Response<bool>> InsertAsync(ClientDTO entityDTO);
        Task<Response<bool>> UpdateAsync(ClientDTO entityDTO);
        Task<Response<bool>> DeleteAsync(int Clientid);
        Task<Response<ClientDTO>> GetAsync(int Clientid);
        Task<Response<IEnumerable<ClientDTO>>> GetAllAsync();

        #endregion
    }
}
