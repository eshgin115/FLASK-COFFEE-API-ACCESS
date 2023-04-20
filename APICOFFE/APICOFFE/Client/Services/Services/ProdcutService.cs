using APICOFFE.Client.Dtos.BestCoffee;
using APICOFFE.Client.Services.Concretes;
using APICOFFE.Contracts.File;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Client.Services.Services;

public class ProdcutService : IProdcutService
{
    private readonly DataContext _dataContext;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;

    public ProdcutService(DataContext dataContext, IFileService fileService, IMapper mapper)
    {
        _dataContext = dataContext;
        _fileService = fileService;
        _mapper = mapper;
    }
    public async Task<List<BestCoffeeListItemDto>> BestCoffeeListAsync()
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

        return bestCoffeeDto;
    }
}
