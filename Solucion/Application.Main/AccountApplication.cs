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
    public class AccountApplication: IAccountApplication
    {
        private readonly IAccountDomain _accountDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<AccountApplication> _logger;

        public AccountApplication(IAccountDomain accountDomain, IMapper mapper, IAppLogger<AccountApplication> logger)
        {
            this._accountDomain = accountDomain;
            this._mapper = mapper;
            this._logger = logger;
        }

        #region Métodos Síncronos

        public Response<bool> Insert(AccountDTO entityDTO)
        {
            var response = new Response<bool>();
            try
            {
                var entity = _mapper.Map<Cuenta>(entityDTO);
                var existe = _accountDomain.Get(entity.NumeroCuenta);
                if (existe == null)
                {
                    var afectados = _accountDomain.Insert(entity);
                    if (afectados == 0) throw new Exception("No se ha podido realizar la acción solicitada");
                }
                else
                    throw new Exception("Ya existe la cuenta");

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

        public Response<bool> Update(AccountDTO entityDTO)
        {
            var response = new Response<bool>();
            try
            {
                var entity = _mapper.Map<Cuenta>(entityDTO);
                var afectados = _accountDomain.Update(entity);

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

        public Response<bool> Delete(string numeroCuenta)
        {
            var response = new Response<bool>();
            try
            {
                var afectados = _accountDomain.Delete(numeroCuenta);

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

        public Response<AccountDTO> Get(string numeroCuenta)
        {
            var response = new Response<AccountDTO>();
            try
            {
                var entity = _accountDomain.Get(numeroCuenta);
                response.Data = _mapper.Map<AccountDTO>(entity);
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

        public Response<IEnumerable<AccountDTO>> GetAll()
        {
            var response = new Response<IEnumerable<AccountDTO>>();
            try
            {
                var entity = _accountDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<AccountDTO>>(entity);
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

        public Response<PagedResult<AccountDTO>> GetDataPaginated(string campo, string filtro, int page, int pageSize)
        {
            var response = new Response<PagedResult<AccountDTO>>();
            var linq = new FilterLinq<Cuenta>();
            try
            {
                /*creo el filtro para la paginación*/
                var predicate = linq.CreateFilterExpresion(campo, filtro);
                var entity = _accountDomain.GetDataPaginated(predicate, page, pageSize);
                response.Data = _mapper.Map<PagedResult<AccountDTO>>(entity);
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


        public Response<PagedResult<AccountDTO>> GetDataPaginatedAll(int page, int pageSize)
        {
            var response = new Response<PagedResult<AccountDTO>>();
            try
            {
                var entity = _accountDomain.GetDataPaginatedAll(page, pageSize);
                response.Data = _mapper.Map<PagedResult<AccountDTO>>(entity);
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

        public async Task<Response<bool>> InsertAsync(AccountDTO entityDTO)
        {
            var response = new Response<bool>();
            try
            {
                var entity = _mapper.Map<Cuenta>(entityDTO);
                var afectados = await _accountDomain.InsertAsync(entity);

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
        public async Task<Response<bool>> UpdateAsync(AccountDTO entityDTO)
        {
            var response = new Response<bool>();
            try
            {
                var entity = _mapper.Map<Cuenta>(entityDTO);
                var afectados = await _accountDomain.UpdateAsync(entity);

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
        public async Task<Response<bool>> DeleteAsync(string numeroCuenta)
        {
            var response = new Response<bool>();
            try
            {
                var afectados = await _accountDomain.DeleteAsync(numeroCuenta);

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
        public async Task<Response<AccountDTO>> GetAsync(string numeroCuenta)
        {
            var response = new Response<AccountDTO>();
            try
            {
                var entity = await _accountDomain.GetAsync(numeroCuenta);
                response.Data = _mapper.Map<AccountDTO>(entity);
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
        public async Task<Response<IEnumerable<AccountDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<AccountDTO>>();
            try
            {
                var entity = await _accountDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<AccountDTO>>(entity);
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
