using APICOFFE.Client.Dtos.DiscoverMenu;
using APICOFFE.Contracts.File;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Client.Controllers;

[ApiController]
[Route("client-discover-menu")]
public class DiscoverMenuController : ControllerBase
{
    private readonly DataContext _dataContext;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;

    public DiscoverMenuController(DataContext dataContext, IFileService fileService, IMapper mapper)
    {
        _dataContext = dataContext;
        _fileService = fileService;
        _mapper = mapper;
    }
    [HttpGet("discover-menu")]
    public async Task<IActionResult> GetAsync()
    {
        var discoverMenu = await _dataContext.DiscoverMenu
           .Include(dm => dm.DiscoverMenuImages)
           .AsNoTracking()
           .SingleOrDefaultAsync();

        var discoverMenuDto = _mapper.Map<DiscoverMenuListItemDto>(discoverMenu);
        discoverMenuDto.ImageURLs = 
            discoverMenuDto.ImageURLs.Select(url => url = _fileService
            .GetFileUrl(url, UploadDirectory.DISCOVER_MENU_IMAGE)).ToList();


        return Ok(discoverMenuDto);
    }
}
