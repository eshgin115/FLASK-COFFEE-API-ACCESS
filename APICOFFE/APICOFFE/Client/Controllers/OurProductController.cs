using APICOFFE.Client.Dtos.OurProduct;
using APICOFFE.Contracts.File;
using APICOFFE.Contracts.OurProduct;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Client.Controllers;

[ApiController]
[Route("client-our-product")]
public class OurProductController : ControllerBase
{
    private readonly DataContext _dataContext;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;

    public OurProductController(DataContext dataContext, IFileService fileService, IMapper mapper)
    {
        _dataContext = dataContext;
        _fileService = fileService;
        _mapper = mapper;
    }
    [HttpGet("our-products")]
    public async Task<IActionResult> ListAsync(int foodCategoryId)
    {
     
          var  product = await _dataContext.Foods
                .Include(f => f.FoodCategory)
                .Include(f => f.FoodImages)
                .Where(f => f.FoodCategory.Id == foodCategoryId)
                .ToListAsync();


        var productDto = _mapper.Map<List<OurProductListItemDto>>(product);

        productDto.ForEach
                        (fbm => fbm.ImageURL = fbm.ImageURL != null
                        ? _fileService.GetFileUrl(fbm.ImageURL, UploadDirectory.FOOD_IMAGE)
                        : null!);
      return Ok(productDto);
    }
}
