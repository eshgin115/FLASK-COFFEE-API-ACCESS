using APICOFFE.Client.Dtos.BestCoffee;
using APICOFFE.Contracts.File;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Client.Controllers;

[ApiController]
[Route("best-coffee")]
public class BestCoffee : ControllerBase
{
    private readonly DataContext _dataContext;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;

    public BestCoffee(DataContext dataContext, IFileService fileService, IMapper mapper)
    {
        _dataContext = dataContext;
        _fileService = fileService;
        _mapper = mapper;
    }
    [HttpGet("best-coffee")]

    public async Task<IActionResult> InvokeAsync()
    {
        var bestCoffee = await _dataContext.Drinks
           .OrderByDescending(bc => bc.OrderProducts
           .Where(op => op.Order.Status == Contracts.Order.Status.Completed).Count())
           .Include(d => d.DrinkCategory)
           .Where(dc => dc.DrinkCategory.Name == "coffee")
           .AsNoTracking()
           .Take(5)
           .ToListAsync();


        var bestCoffeeDto = _mapper.Map<List<BestCoffeeListItemDto>>(bestCoffee);
        bestCoffeeDto.ForEach(bcm => bcm.ImageURL = bcm.ImageURL != null
                        ? _fileService.GetFileUrl(bcm.ImageURL, UploadDirectory.DRINK_IMAGE)
                        : null!);

        return Ok(bestCoffeeDto);
    }
}
