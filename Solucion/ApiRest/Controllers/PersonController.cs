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
    public class PersonController : ControllerBase
    {
        private readonly IPersonApplication _personApplication;
        private readonly AppSettings _appSettings;

        public PersonController(IPersonApplication personApplication, IOptions<AppSettings> appSettings)
        {
            this._personApplication = personApplication;
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
        public IActionResult Insert([FromBody] PersonDTO entityDTO)
        {
            if (entityDTO == null)
                return BadRequest();

            var response = _personApplication.Insert(entityDTO);
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
        public IActionResult Update([FromBody] PersonDTO entityDTO)
        {
            if (entityDTO == null)
                return BadRequest();

            var response = _personApplication.Update(entityDTO);
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
        [HttpDelete("Delete/{identificacion}")]
        public IActionResult Delete(string identificacion)
        {
            if (identificacion == "")
                return BadRequest();

            var response = _personApplication.Delete(identificacion);
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
        [HttpGet("Get/{identificacion}")]
        public IActionResult Get(string identificacion)
        {
            if (identificacion == "")
                return BadRequest();

            var response = _personApplication.Get(identificacion);
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
            var response = _personApplication.GetAll();
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
            var response = _personApplication.GetDataPaginatedAll(page, pageSize);
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
            var response = _personApplication.GetDataPaginated(campo, filtro, page, pageSize);
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
        public async Task<IActionResult> InsertAsync([FromBody] PersonDTO entityDTO)
        {
            if (entityDTO == null)
                return BadRequest();

            var response = await _personApplication.InsertAsync(entityDTO);
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
        public async Task<IActionResult> UpdateAsync([FromBody] PersonDTO entityDTO)
        {
            if (entityDTO == null)
                return BadRequest();

            var response = await _personApplication.UpdateAsync(entityDTO);
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
        [HttpPost("DeleteAsync/{identificacion}")]
        public async Task<IActionResult> DeleteAsync(string identificacion)
        {
            if (identificacion == "")
                return BadRequest();

            var response = await _personApplication.DeleteAsync(identificacion);
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
        [HttpGet("GetAsync/{identificacion}")]
        public async Task<IActionResult> GetAsync(string identificacion)
        {
            if (identificacion == "")
                return BadRequest();

            var response = await _personApplication.GetAsync(identificacion);
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
            var response = await _personApplication.GetAllAsync();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion
    }
}
