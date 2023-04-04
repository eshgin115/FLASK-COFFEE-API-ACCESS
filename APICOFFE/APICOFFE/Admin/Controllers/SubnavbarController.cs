﻿using APICOFFE.Admin.Dtos.Subnavbar;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.AspNetCore.Mvc;

namespace APICOFFE.Admin.Controllers
{
    [ApiController]
    public class SubnavbarController : ControllerBase
    {
        private readonly ISubnavbarService _subnavbarService;

        public SubnavbarController(ISubnavbarService subnavbarService)
        {
            _subnavbarService = subnavbarService;
        }
        #region List
        [HttpGet("subnavbar/list")]
        public async Task<IActionResult> ListAsync()
        {
            return Ok(await _subnavbarService.ListAsync());
        }
        #endregion

        #region Add
        [HttpPost("subnavbar/add")]
        public async Task<IActionResult> AddAsync(SubnavbarCreateDto dto)
        {
            return Created(string.Empty, await _subnavbarService.AddAsync(dto));
        }

        #endregion

        #region Update
        [HttpPut("subnavbar/update/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, SubnavbarUpdateDto dto)
        {
            return Ok(await _subnavbarService.UpdateAsync(id, dto));
        }

        #endregion

        #region delete
        [HttpDelete("subnavbar/delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _subnavbarService.DeleteAsync(id);

            return NoContent();
        }
        #endregion
    }
}
