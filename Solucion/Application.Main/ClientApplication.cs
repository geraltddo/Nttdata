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
    public class ClientApplication : IClientApplication
    {
        private readonly IClientDomain _clientDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<ClientApplication> _logger;

        public ClientApplication(IClientDomain clientDomain, IMapper mapper, IAppLogger<ClientApplication> logger)
        {
            this._clientDomain = clientDomain;
            this._mapper = mapper;
            this._logger = logger;
        }

        #region Métodos Síncronos

        public Response<bool> Insert(ClientDTO entityDTO)
        {
            var response = new Response<bool>();
            try
            {
                var entity = _mapper.Map<Cliente>(entityDTO);
                var existe = _clientDomain.Get(entity.Clientid);
                if (existe == null)
                {
                    var afectados = _clientDomain.Insert(entity);
                    #region comment
                    //if (afectados > 0)
                    //{
                    //    var cliente = _clientDomain.Get(entityDTO.Clientid);
                    //    decimal? amortizacion = 0;
                    //    for (int i = 0; i < 12; i++)
                    //    {
                    //        var valorAnual = cliente.MontoAhorro * (1 + ((cliente.TasaAnual) / 100));
                    //        var desgloce = new DesgloceMensual();
                    //        desgloce.CodigoCliente = cliente.CodigoCliente;
                    //        desgloce.SaldoInicial = cliente.MontoAhorro;
                    //        if (i == 0)
                    //        {
                    //            desgloce.Interes = (valorAnual - cliente.MontoAhorro) / 12;
                    //            desgloce.Amortizacion = desgloce.SaldoInicial + desgloce.Interes;
                    //            amortizacion = desgloce.Amortizacion;
                    //        }
                    //        else
                    //        {
                    //            desgloce.Interes = (valorAnual - cliente.MontoAhorro) / 12;
                    //            desgloce.Amortizacion = amortizacion + desgloce.Interes;
                    //            amortizacion = desgloce.Amortizacion;
                    //        }
                    //        var desgAfectado = _mounthlyDomain.Insert(desgloce);
                    //    }
                    //}
                    #endregion
                    if (afectados == 0) throw new Exception("No se ha podido realizar la acción solicitada");
                }
                else
                    throw new Exception("Ya existe el cliente");

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

        public Response<bool> Update(ClientDTO entityDTO)
        {
            var response = new Response<bool>();
            try
            {
                var entity = _mapper.Map<Cliente>(entityDTO);
                var afectados = _clientDomain.Update(entity);

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

        public Response<bool> Delete(int clientId)
        {
            var response = new Response<bool>();
            try
            {
                var afectados = _clientDomain.Delete(clientId);

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

        public Response<ClientDTO> Get(int clientId)
        {
            var response = new Response<ClientDTO>();
            try
            {
                var entity = _clientDomain.Get(clientId);
                response.Data = _mapper.Map<ClientDTO>(entity);
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

        public Response<IEnumerable<ClientDTO>> GetAll()
        {
            var response = new Response<IEnumerable<ClientDTO>>();
            try
            {
                var entity = _clientDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<ClientDTO>>(entity);
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

        public Response<PagedResult<ClientDTO>> GetDataPaginated(string campo, string filtro, int page, int pageSize)
        {
            var response = new Response<PagedResult<ClientDTO>>();
            var linq = new FilterLinq<Cliente>();
            try
            {
                /*creo el filtro para la paginación*/
                var predicate = linq.CreateFilterExpresion(campo, filtro);
                var entity = _clientDomain.GetDataPaginated(predicate, page, pageSize);
                response.Data = _mapper.Map<PagedResult<ClientDTO>>(entity);
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


        public Response<PagedResult<ClientDTO>> GetDataPaginatedAll(int page, int pageSize)
        {
            var response = new Response<PagedResult<ClientDTO>>();
            try
            {
                var entity = _clientDomain.GetDataPaginatedAll(page, pageSize);
                response.Data = _mapper.Map<PagedResult<ClientDTO>>(entity);
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

        public async Task<Response<bool>> InsertAsync(ClientDTO entityDTO)
        {
            var response = new Response<bool>();
            try
            {
                var entity = _mapper.Map<Cliente>(entityDTO);
                var afectados = await _clientDomain.InsertAsync(entity);

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
        public async Task<Response<bool>> UpdateAsync(ClientDTO entityDTO)
        {
            var response = new Response<bool>();
            try
            {
                var entity = _mapper.Map<Cliente>(entityDTO);
                var afectados = await _clientDomain.UpdateAsync(entity);

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
        public async Task<Response<bool>> DeleteAsync(int clientId)
        {
            var response = new Response<bool>();
            try
            {
                var afectados = await _clientDomain.DeleteAsync(clientId);

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
        public async Task<Response<ClientDTO>> GetAsync(int clientId)
        {
            var response = new Response<ClientDTO>();
            try
            {
                var entity = await _clientDomain.GetAsync(clientId);
                response.Data = _mapper.Map<ClientDTO>(entity);
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
        public async Task<Response<IEnumerable<ClientDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<ClientDTO>>();
            try
            {
                var entity = await _clientDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<ClientDTO>>(entity);
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
