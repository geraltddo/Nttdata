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
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionApplication _transactionApplication;
        private readonly AppSettings _appSettings;

        public TransactionController(ITransactionApplication transactionApplication, IOptions<AppSettings> appSettings)
        {
            this._transactionApplication = transactionApplication;
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
        public IActionResult Insert([FromBody] TransactionDTO entityDTO)
        {
            if (entityDTO == null)
                return BadRequest();

            var response = _transactionApplication.Insert(entityDTO);
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
        public IActionResult Update([FromBody] TransactionDTO entityDTO)
        {
            if (entityDTO == null)
                return BadRequest();

            var response = _transactionApplication.Update(entityDTO);
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
        [HttpDelete("Delete/{codigoMovimiento}")]
        public IActionResult Delete(int codigoMovimiento)
        {
            if (codigoMovimiento == 0)
                return BadRequest();

            var response = _transactionApplication.Delete(codigoMovimiento);
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
        [HttpGet("Get/{codigoMovimiento}")]
        public IActionResult Get(int codigoMovimiento)
        {
            if (codigoMovimiento == 0)
                return BadRequest();

            var response = _transactionApplication.Get(codigoMovimiento);
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
            var response = _transactionApplication.GetAll();
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
            var response = _transactionApplication.GetDataPaginatedAll(page, pageSize);
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
            var response = _transactionApplication.GetDataPaginated(campo, filtro, page, pageSize);
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
        public async Task<IActionResult> InsertAsync([FromBody] TransactionDTO entityDTO)
        {
            if (entityDTO == null)
                return BadRequest();

            var response = await _transactionApplication.InsertAsync(entityDTO);
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
        public async Task<IActionResult> UpdateAsync([FromBody] TransactionDTO entityDTO)
        {
            if (entityDTO == null)
                return BadRequest();

            var response = await _transactionApplication.UpdateAsync(entityDTO);
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
        [HttpPost("DeleteAsync/{codigoMovimiento}")]
        public async Task<IActionResult> DeleteAsync(int codigoMovimiento)
        {
            if (codigoMovimiento == 0)
                return BadRequest();

            var response = await _transactionApplication.DeleteAsync(codigoMovimiento);
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
        [HttpGet("GetAsync/{codigoMovimiento}")]
        public async Task<IActionResult> GetAsync(int codigoMovimiento)
        {
            if (codigoMovimiento == 0)
                return BadRequest();

            var response = await _transactionApplication.GetAsync(codigoMovimiento);
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
            var response = await _transactionApplication.GetAllAsync();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion
    }
}
