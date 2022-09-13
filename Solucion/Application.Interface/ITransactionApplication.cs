using Application.DTO;
using Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ITransactionApplication
    {
        #region Métodos Síncronos

        Response<bool> Insert(TransactionDTO entityDTO);
        Response<bool> Update(TransactionDTO entityDTO);
        Response<bool> Delete(int codigoMovimiento);
        Response<TransactionDTO> Get(int codigoMovimiento);
        Response<IEnumerable<TransactionDTO>> GetAll();
        Response<PagedResult<TransactionDTO>> GetDataPaginated(string campo, string filtro, int page, int pageSize);
        Response<PagedResult<TransactionDTO>> GetDataPaginatedAll(int page, int pageSize);

        #endregion


        #region Métodos Asíncronos

        Task<Response<bool>> InsertAsync(TransactionDTO entityDTO);
        Task<Response<bool>> UpdateAsync(TransactionDTO entityDTO);
        Task<Response<bool>> DeleteAsync(int codigoMovimiento);
        Task<Response<TransactionDTO>> GetAsync(int codigoMovimiento);
        Task<Response<IEnumerable<TransactionDTO>>> GetAllAsync();

        #endregion
    }
}
