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

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountApplication _accountApplication;
        private readonly AppSettings _appSettings;

        public AccountController(IAccountApplication accountApplication, IOptions<AppSettings> appSettings)
        {
            this._accountApplication = accountApplication;
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
        public IActionResult Insert([FromBody] AccountDTO entityDTO)
        {
            if (entityDTO == null)
                return BadRequest();

            var response = _accountApplication.Insert(entityDTO);
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
        public IActionResult Update([FromBody] AccountDTO entityDTO)
        {
            if (entityDTO == null)
                return BadRequest();

            var response = _accountApplication.Update(entityDTO);
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
        [HttpDelete("Delete/{numeroCuenta}")]
        public IActionResult Delete(string numeroCuenta)
        {
            if (numeroCuenta == "")
                return BadRequest();

            var response = _accountApplication.Delete(numeroCuenta);
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
        [HttpGet("Get/{cedula}")]
        public IActionResult Get(string numeroCuenta)
        {
            if (numeroCuenta == "")
                return BadRequest();

            var response = _accountApplication.Get(numeroCuenta);
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
            var response = _accountApplication.GetAll();
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
            var response = _accountApplication.GetDataPaginatedAll(page, pageSize);
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
            var response = _accountApplication.GetDataPaginated(campo, filtro, page, pageSize);
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
        public async Task<IActionResult> InsertAsync([FromBody] AccountDTO entityDTO)
        {
            if (entityDTO == null)
                return BadRequest();

            var response = await _accountApplication.InsertAsync(entityDTO);
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
        public async Task<IActionResult> UpdateAsync([FromBody] AccountDTO entityDTO)
        {
            if (entityDTO == null)
                return BadRequest();

            var response = await _accountApplication.UpdateAsync(entityDTO);
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
        [HttpPost("DeleteAsync/{cedula}")]
        public async Task<IActionResult> DeleteAsync(string numeroCuenta)
        {
            if (numeroCuenta == "")
                return BadRequest();

            var response = await _accountApplication.DeleteAsync(numeroCuenta);
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
        [HttpGet("GetAsync/{cedula}")]
        public async Task<IActionResult> GetAsync(string numeroCuenta)
        {
            if (numeroCuenta == "")
                return BadRequest();

            var response = await _accountApplication.GetAsync(numeroCuenta);
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
            var response = await _accountApplication.GetAllAsync();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion
    }
}
