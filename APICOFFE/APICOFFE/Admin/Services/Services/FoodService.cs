using APICOFFE.Admin.Dtos.Food;
using APICOFFE.Admin.Services.Concretes;
using APICOFFE.Contracts.File;
using APICOFFE.Database.Models;
using APICOFFE.Exceptions;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Admin.Services.Services;

public class FoodService : IFoodService
{
    private readonly DataContext _dataContext;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;
    private readonly ILogger<FoodService> _logger;
    public FoodService
        (DataContext dataContext,
        IFileService fileService,
        IMapper mapper,
        ILogger<FoodService> logger)
    {
        _dataContext = dataContext;
        _fileService = fileService;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<List<FoodListItemDto>> ListAsync()
    {
        var foods = await _dataContext.Foods
                                         .Include(f => f.FoodTags)!
                                         .ThenInclude(ft => ft.Tag)!
                                         .Include(f => f.FoodSizes)!
                                         .ThenInclude(fs => fs.Size)
                                         .Include(f => f.FoodImages!.Where(fi => fi.IsMain))
                                         .Include(f => f.FoodCategory)!
                                         .ToListAsync();
        var foodsDto = _mapper.Map<List<FoodListItemDto>>(foods);

        foodsDto.ForEach(fbm => fbm.ImageURL = fbm.ImageURL != null
        ? _fileService.GetFileUrl(fbm.ImageURL, UploadDirectory.FOOD_IMAGE)
        : null!);
        return foodsDto;
    }
    public async Task<FoodListItemDto> AddAsync(FoodCreateDto dto)
    {
        CheckingSize(dto.SizeIds!);

        CheckingForCategory(dto.CategoryId);

        CheckingTag(dto.TagIds!);
     
        var food = await AddFoodAsync(dto);

        return await GetFoodListItemDtoAsync(food);
    }
    public Task<FoodListItemDto> UpdateAsync(int id, FoodUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }



    private void CheckingSize(List<int> SizeIds)
    {
        foreach (var sizeId in SizeIds)
            if (!_dataContext.Sizes.Any(c => c.Id == sizeId))
                throw new NotFoundException("Size", sizeId);
    }
    private void CheckingTag(List<int> TagIds)
    {
        foreach (var tagId in TagIds)
            if (!_dataContext.Tags.Any(c => c.Id == tagId))
                throw new NotFoundException("Tag", tagId);
    }
    private void CheckingForCategory(int CategoryId)
    {
        if (!_dataContext.FoodCategories.Any(c => c.Id == CategoryId))
            throw new NotFoundException("FoodCategory", CategoryId);

    }
    private async Task AddFoodSizeAsync(Food food, List<int> SizeIds)
    {
        foreach (var sizeId in SizeIds)
            await _dataContext.FoodSizes.AddAsync(_mapper.Map<FoodSize>((sizeId, food)));
    }
    private async Task AddFoodTagAsync(Food food, List<int> TagIds)
    {
        foreach (var tagId in TagIds)
            await _dataContext.FoodTags.AddAsync(_mapper.Map<FoodTag>((tagId, food)));
    }
    private async Task AddFoodImageAsync(Food food, List<IFormFile> Images)
    {
        foreach (var image in Images!)
        {
            var imageNameInSystem = await _fileService.UploadAsync(image, UploadDirectory.FOOD_IMAGE);
            await _dataContext.FoodImages
                .AddAsync(_mapper.Map<FoodImage>((image, food, false, imageNameInSystem)));
        }
    }
    private async Task AddFoodImageAsync(Food food, IFormFile Image)
    {
        var mainImageNameInSystem = await _fileService.UploadAsync(Image!, UploadDirectory.FOOD_IMAGE);

        await _dataContext.FoodImages
            .AddAsync(_mapper.Map<FoodImage>((Image, food, true, mainImageNameInSystem)));
    }
    private async Task<Food> AddFoodAsync(FoodCreateDto dto)
    {
        var food = _mapper.Map<Food>(dto);

        await AddFoodSizeAsync(food, dto.SizeIds!);

        await AddFoodTagAsync(food, dto.TagIds!);

        await AddFoodImageAsync(food, dto.MainImage);

        await AddFoodImageAsync(food, dto.Images);

        await _dataContext.Foods.AddAsync(food);

        await _dataContext.SaveChangesAsync();

        return food;
    }
    private async Task<FoodListItemDto> GetFoodListItemDtoAsync(Food food)
    {
        var foodInDb = await _dataContext.Foods
                                          .Include(f => f.FoodTags)!
                                          .ThenInclude(ft => ft.Tag)!
                                          .Include(f => f.FoodSizes)!
                                          .ThenInclude(fs => fs.Size)
                                          .Include(f => f.FoodImages!.Where(fi => fi.IsMain))
                                          .Include(f => f.FoodCategory)!
                                          .FirstOrDefaultAsync(f => f.Id == food.Id);
        var foodDto = _mapper.Map<FoodListItemDto>(foodInDb);

        foodDto.ImageURL = foodDto.ImageURL != null
             ? _fileService.GetFileUrl(foodDto.ImageURL, UploadDirectory.FOOD_IMAGE)
             : null!;
        return foodDto;
    }
}
