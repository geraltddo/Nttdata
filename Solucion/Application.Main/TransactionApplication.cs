using Application.DTO;
using Application.Interface;
using AutoMapper;
using Common;
using Domain.Entity;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Application.Main
{
    public class TransactionApplication: ITransactionApplication
    {
        private readonly ITransactionDomain _transactionDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<TransactionApplication> _logger;

        public TransactionApplication(ITransactionDomain transactionDomain, IMapper mapper, IAppLogger<TransactionApplication> logger)
        {
            this._transactionDomain = transactionDomain;
            this._mapper = mapper;
            this._logger = logger;
        }

        #region Métodos Síncronos

        public Response<bool> Insert(TransactionDTO entityDTO)
        {
            var response = new Response<bool>();
            try
            {
                var entity = _mapper.Map<Movimiento>(entityDTO);
                var existe = _transactionDomain.Get(entity.CodigoMovimiento);
                if (existe == null)
                {
                    var afectados = _transactionDomain.Insert(entity);
                    if (afectados == 0) throw new Exception("No se ha podido realizar la acción solicitada");
                }
                else
                    throw new Exception("Ya existe la persona");

                response.IsSuccess = true;
                response.Message = "Registro Exitoso";
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<bool> Update(TransactionDTO entityDTO)
        {
            var response = new Response<bool>();
            try
            {
                var entity = _mapper.Map<Movimiento>(entityDTO);
                var afectados = _transactionDomain.Update(entity);

                if (afectados == 0) throw new Exception("No se ha podido realizar la acción solicitada");

                response.IsSuccess = true;
                response.Message = "Actualización Exitosa";
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<bool> Delete(int codigoMovimiento)
        {
            var response = new Response<bool>();
            try
            {
                var afectados = _transactionDomain.Delete(codigoMovimiento);

                if (afectados == 0) throw new Exception("No se ha podido realizar la acción solicitada");

                response.IsSuccess = true;
                response.Message = "Eliminación Exitosa";
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<TransactionDTO> Get(int codigoMovimiento)
        {
            var response = new Response<TransactionDTO>();
            try
            {
                var entity = _transactionDomain.Get(codigoMovimiento);
                response.Data = _mapper.Map<TransactionDTO>(entity);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<IEnumerable<TransactionDTO>> GetAll()
        {
            var response = new Response<IEnumerable<TransactionDTO>>();
            try
            {
                var entity = _transactionDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<TransactionDTO>>(entity);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa";
                    _logger.LogInformation("Consulta Exitosa");
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }
            return response;
        }

        public Response<PagedResult<TransactionDTO>> GetDataPaginated(string campo, string filtro, int page, int pageSize)
        {
            var response = new Response<PagedResult<TransactionDTO>>();
            var linq = new FilterLinq<Movimiento>();
            try
            {
                /*creo el filtro para la paginación*/
                var predicate = linq.CreateFilterExpresion(campo, filtro);
                var entity = _transactionDomain.GetDataPaginated(predicate, page, pageSize);
                response.Data = _mapper.Map<PagedResult<TransactionDTO>>(entity);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa";
                    _logger.LogInformation("Consulta Exitosa");
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }
            return response;
        }


        public Response<PagedResult<TransactionDTO>> GetDataPaginatedAll(int page, int pageSize)
        {
            var response = new Response<PagedResult<TransactionDTO>>();
            try
            {
                var entity = _transactionDomain.GetDataPaginatedAll(page, pageSize);
                response.Data = _mapper.Map<PagedResult<TransactionDTO>>(entity);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa";
                    _logger.LogInformation("Consulta Exitosa");
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }
            return response;
        }

        #endregion

        #region Métodos Asíncronos

        public async Task<Response<bool>> InsertAsync(TransactionDTO entityDTO)
        {
            var response = new Response<bool>();
            try
            {
                var entity = _mapper.Map<Movimiento>(entityDTO);
                var afectados = await _transactionDomain.InsertAsync(entity);

                if (afectados == 0) throw new Exception("No se ha podido realizar la acción solicitada");

                response.IsSuccess = true;
                response.Message = "Registro Exitoso";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Data = false;
            }
            return response;
        }
        public async Task<Response<bool>> UpdateAsync(TransactionDTO entityDTO)
        {
            var response = new Response<bool>();
            try
            {
                var entity = _mapper.Map<Movimiento>(entityDTO);
                var afectados = await _transactionDomain.UpdateAsync(entity);

                if (afectados == 0) throw new Exception("No se ha podido realizar la acción solicitada");

                response.IsSuccess = true;
                response.Message = "Actualización Exitosa";
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<bool>> DeleteAsync(int codigoMovimiento)
        {
            var response = new Response<bool>();
            try
            {
                var afectados = await _transactionDomain.DeleteAsync(codigoMovimiento);

                if (afectados == 0) throw new Exception("No se ha podido realizar la acción solicitada");

                response.IsSuccess = true;
                response.Message = "Eliminación Exitosa";
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<TransactionDTO>> GetAsync(int codigoMovimiento)
        {
            var response = new Response<TransactionDTO>();
            try
            {
                var entity = await _transactionDomain.GetAsync(codigoMovimiento);
                response.Data = _mapper.Map<TransactionDTO>(entity);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<IEnumerable<TransactionDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<TransactionDTO>>();
            try
            {
                var entity = await _transactionDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<TransactionDTO>>(entity);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        #endregion
    }
}
