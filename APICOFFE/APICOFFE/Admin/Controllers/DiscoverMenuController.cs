using APICOFFE.Admin.Dtos.DiscoverMenu;
using APICOFFE.Contracts.File;
using APICOFFE.Contracts.Identity;
using APICOFFE.Database.Models;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Admin.Controllers
{
    [ApiController]
    //[Authorize(Roles = RoleNames.ADMIN)]
    public class DiscoverMenuController : ControllerBase
    {
        private readonly IDiscoverMenuService _discoverMenuService;

        public DiscoverMenuController(
            IDiscoverMenuService discoverMenuService)
        {
            _discoverMenuService = discoverMenuService;
        }
        [HttpGet("discovermenu/getsingle")]
        public async Task<IActionResult> UpdateAsync()
        {
            return Ok(await _discoverMenuService.GetAsync());
        }
        [HttpPut("discovermenu/update")]

        public async Task<IActionResult> UpdateAsync([FromForm]DiscoverMenuUpdateRequsetDto dto)
        {
            return Ok(await _discoverMenuService.UpdateAsync(dto));
        }
    }
}
