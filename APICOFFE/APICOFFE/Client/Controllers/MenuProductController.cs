using APICOFFE.Client.Dtos.MenuProduct;
using APICOFFE.Contracts.File;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Client.Controllers;

[ApiController]
[Route("client-menu-product")]
public class MenuProductController : ControllerBase
{
    private readonly DataContext _dataContext;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;

    public MenuProductController(DataContext dataContext, IFileService fileService, IMapper mapper)
    {
        _dataContext = dataContext;
        _fileService = fileService;
        _mapper = mapper;
    }
    [HttpGet("menu-products")]
    public async Task<IActionResult> ListAsync()
    {
        var foodMenu = await _dataContext.FoodCategories
            .Include(fc => fc.Foods!)
            .ThenInclude(fc => fc.FoodImages)
            .ToListAsync();
        var foodMenuModel = _mapper.Map<List<MenuProductListItemDto>>(foodMenu);


        foodMenuModel.ForEach(f => f.Foods.ForEach(ff => ff.ImageURL = ff.ImageURL != null
        ? _fileService.GetFileUrl(ff.ImageURL, UploadDirectory.FOOD_IMAGE)
        : null!));

        return Ok(foodMenuModel);
    }
}
