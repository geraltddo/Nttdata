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
    public class PersonApplication: IPersonApplication
    {
        private readonly IPersonDomain _personDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<PersonApplication> _logger;

        public PersonApplication(IPersonDomain personDomain, IMapper mapper, IAppLogger<PersonApplication> logger)
        {
            this._personDomain = personDomain;
            this._mapper = mapper;
            this._logger = logger;
        }

        #region Métodos Síncronos

        public Response<bool> Insert(PersonDTO entityDTO)
        {
            var response = new Response<bool>();
            try
            {
                var entity = _mapper.Map<Persona>(entityDTO);
                var existe = _personDomain.Get(entity.Identificacion);
                if (existe == null)
                {
                    var afectados = _personDomain.Insert(entity);
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

        public Response<bool> Update(PersonDTO entityDTO)
        {
            var response = new Response<bool>();
            try
            {
                var entity = _mapper.Map<Persona>(entityDTO);
                var afectados = _personDomain.Update(entity);

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

        public Response<bool> Delete(string identificacion)
        {
            var response = new Response<bool>();
            try
            {
                var afectados = _personDomain.Delete(identificacion);

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

        public Response<PersonDTO> Get(string identificacion)
        {
            var response = new Response<PersonDTO>();
            try
            {
                var entity = _personDomain.Get(identificacion);
                response.Data = _mapper.Map<PersonDTO>(entity);
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

        public Response<IEnumerable<PersonDTO>> GetAll()
        {
            var response = new Response<IEnumerable<PersonDTO>>();
            try
            {
                var entity = _personDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<PersonDTO>>(entity);
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

        public Response<PagedResult<PersonDTO>> GetDataPaginated(string campo, string filtro, int page, int pageSize)
        {
            var response = new Response<PagedResult<PersonDTO>>();
            var linq = new FilterLinq<Persona>();
            try
            {
                /*creo el filtro para la paginación*/
                var predicate = linq.CreateFilterExpresion(campo, filtro);
                var entity = _personDomain.GetDataPaginated(predicate, page, pageSize);
                response.Data = _mapper.Map<PagedResult<PersonDTO>>(entity);
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


        public Response<PagedResult<PersonDTO>> GetDataPaginatedAll(int page, int pageSize)
        {
            var response = new Response<PagedResult<PersonDTO>>();
            try
            {
                var entity = _personDomain.GetDataPaginatedAll(page, pageSize);
                response.Data = _mapper.Map<PagedResult<PersonDTO>>(entity);
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

        public async Task<Response<bool>> InsertAsync(PersonDTO entityDTO)
        {
            var response = new Response<bool>();
            try
            {
                var entity = _mapper.Map<Persona>(entityDTO);
                var afectados = await _personDomain.InsertAsync(entity);

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
        public async Task<Response<bool>> UpdateAsync(PersonDTO entityDTO)
        {
            var response = new Response<bool>();
            try
            {
                var entity = _mapper.Map<Persona>(entityDTO);
                var afectados = await _personDomain.UpdateAsync(entity);

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
        public async Task<Response<bool>> DeleteAsync(string identificacion)
        {
            var response = new Response<bool>();
            try
            {
                var afectados = await _personDomain.DeleteAsync(identificacion);

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
        public async Task<Response<PersonDTO>> GetAsync(string identificacion)
        {
            var response = new Response<PersonDTO>();
            try
            {
                var entity = await _personDomain.GetAsync(identificacion);
                response.Data = _mapper.Map<PersonDTO>(entity);
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
        public async Task<Response<IEnumerable<PersonDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<PersonDTO>>();
            try
            {
                var entity = await _personDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<PersonDTO>>(entity);
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
