using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Helpers;
using Application.Interface;
using Application.Main;
using Application.DTO;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientApplication _clientApplication;
        private readonly AppSettings _appSettings;

        public ClientController(IClientApplication clientApplication, IOptions<AppSettings> appSettings)
        {
            this._clientApplication = clientApplication;
            this._appSettings = appSettings.Value;
        }

        #region Métodos Síncronos
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityDTO"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("Insert")]
        public IActionResult Insert([FromBody] ClientDTO entityDTO)
        {
            if (entityDTO == null)
                return BadRequest();

            var response = _clientApplication.Insert(entityDTO);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityDTO"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPut("Update")]
        public IActionResult Update([FromBody] ClientDTO entityDTO)
        {
            if (entityDTO == null)
                return BadRequest();

            var response = _clientApplication.Update(entityDTO);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpDelete("Delete/{clientId}")]
        public IActionResult Delete(int clientId)
        {
            if (clientId == 0)
                return BadRequest();

            var response = _clientApplication.Delete(clientId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("Get/{clientId}")]
        public IActionResult Get(int clientId)
        {
            if (clientId == 0)
                return BadRequest();

            var response = _clientApplication.Get(clientId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var response = _clientApplication.GetAll();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("GetDataPaginatedAll")]
        public IActionResult GetDataPaginatedAll(int page, int pageSize)
        {
            var response = _clientApplication.GetDataPaginatedAll(page, pageSize);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("GetDataPaginated")]
        public IActionResult GetDataPaginated(string campo, string filtro, int page, int pageSize)
        {
            var response = _clientApplication.GetDataPaginated(campo, filtro, page, pageSize);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        #endregion

        #region Métodos Asíncronos
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityDTO"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody] ClientDTO entityDTO)
        {
            if (entityDTO == null)
                return BadRequest();

            var response = await _clientApplication.InsertAsync(entityDTO);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityDTO"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] ClientDTO entityDTO)
        {
            if (entityDTO == null)
                return BadRequest();

            var response = await _clientApplication.UpdateAsync(entityDTO);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("DeleteAsync/{clientId}")]
        public async Task<IActionResult> DeleteAsync(int clientId)
        {
            if (clientId == 0)
                return BadRequest();

            var response = await _clientApplication.DeleteAsync(clientId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("GetAsync/{clientId}")]
        public async Task<IActionResult> GetAsync(int clientId)
        {
            if (clientId == 0)
                return BadRequest();

            var response = await _clientApplication.GetAsync(clientId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _clientApplication.GetAllAsync();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion
    }
}
