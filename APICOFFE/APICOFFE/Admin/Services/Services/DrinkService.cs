using APICOFFE.Admin.Dtos.Drink;
using APICOFFE.Admin.Services.Concretes;
using APICOFFE.Contracts.File;
using APICOFFE.Database.Models;
using APICOFFE.Exceptions;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Admin.Services.Services;

public class DrinkService : IDrinkService
{
    private readonly DataContext _dataContext;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;
    private readonly ILogger<DrinkService> _logger;
    public DrinkService
        (DataContext dataContext,
        IFileService fileService,
        IMapper mapper,
        ILogger<DrinkService> logger)
    {
        _dataContext = dataContext;
        _fileService = fileService;
        _mapper = mapper;
        _logger = logger;
    }
    #region List

    public async Task<List<DrinkListItemDto>> ListAsync()
    {
        var drinks = await _dataContext.Drinks
                                        .Include(f => f.DrinkTags)!
                                        .ThenInclude(ft => ft.Tag)!
                                        .Include(f => f.DrinkSizes)!
                                        .ThenInclude(fs => fs.Size)
                                        .Include(f => f.DrinkCategory)!
                                        .AsNoTracking()
                                        .ToListAsync();
        var drinksDto = _mapper.Map<List<DrinkListItemDto>>(drinks);
        drinksDto.ForEach(fbm => fbm.ImageURL = fbm.ImageURL != null
        ? _fileService.GetFileUrl(fbm.ImageURL, UploadDirectory.DRINK_IMAGE)
        : null!);
        return drinksDto;
    }
    #endregion

    #region Add
    public async Task<DrinkListItemDto> AddAsync(DrinkCreateDto dto)
    {
        CheckingDrinkCategory(dto.DrinkCategoryId);

        CheckingSize(dto.SizeIds!);

        CheckingTag(dto.TagIds!);

        var drink = await AddDrinkAsync(dto);

        await AddDrinkSizeAsync(drink, dto.SizeIds!);

        await AddDrinkTagAsync(drink, dto.TagIds!);

        await _dataContext.Drinks.AddAsync(drink);

        await _dataContext.SaveChangesAsync();

        return await GetDrinkListItemDtoAsync(drink);
    }
    #endregion

    #region Update
    public async Task<DrinkListItemDto> UpdateAsync(int id, DrinkUpdateDto dto)
    {
        var drink = await _dataContext.Drinks
                 .Include(p => p.DrinkTags)
                 .Include(p => p.DrinkSizes)
                 .FirstOrDefaultAsync(p => p.Id == id)
                 ?? throw new NotFoundException("Drink", id);

        CheckingDrinkCategory(dto.DrinkCategoryId);

        CheckingSize(dto.SizeIds!);

        CheckingTag(dto.TagIds!);

        _mapper.Map(dto, drink);

        await UpdateDrinkTag(drink, dto);

        await UpdateDrinkSize(drink, dto);

        await _dataContext.SaveChangesAsync();

        return await GetDrinkListItemDtoAsync(drink);
    }
    #endregion

    #region Delete
    public async Task DeleteAsync(int id)
    {
        var drink = await _dataContext.Drinks
               //.Include(f => f.OrderProducts)
               .FirstOrDefaultAsync(f => f.Id == id)
               ?? throw new NotFoundException("Drink", id);


        _dataContext.Drinks.Remove(drink);

        await _fileService.DeleteAsync(drink.ImageNameInFileSystem, UploadDirectory.DRINK_IMAGE);


        await _dataContext.SaveChangesAsync();
    }
    #endregion

    #region 
    private async Task UpdateDrinkTag(Drink drink, DrinkUpdateDto dto)
    {
        var TagsInDb = drink.DrinkTags!.Select(pt => pt.TagId).ToList();
        var TagsInDbToRemove = TagsInDb.Except(dto.TagIds).ToList();
        var TagsToAdd = dto.TagIds.Except(TagsInDb).ToList();

        drink.DrinkTags!.RemoveAll(pt => TagsInDbToRemove.Contains(pt.TagId));

        foreach (var tagId in TagsToAdd)
            await _dataContext.DrinkTags.AddAsync(_mapper.Map<DrinkTag>((tagId, drink)));
    }
    private async Task UpdateDrinkSize(Drink drink, DrinkUpdateDto dto)
    {

        var SizesInDb = drink.DrinkSizes!.Select(ps => ps.SizeId).ToList();
        var SizesInDbToRemove = SizesInDb.Except(dto.SizeIds).ToList();
        var SizesToAdd = dto.SizeIds.Except(SizesInDb).ToList();

        drink.DrinkSizes!.RemoveAll(pt => SizesInDbToRemove.Contains(pt.SizeId));

        foreach (var sizeId in SizesToAdd)
            await _dataContext.DrinkSizes.AddAsync(_mapper.Map<DrinkSize>((sizeId, drink)));

    }
    private async Task AddDrinkSizeAsync(Drink drink, List<int> SizeIds)
    {
        foreach (var sizeId in SizeIds)
            await _dataContext.DrinkSizes.AddAsync(_mapper.Map<DrinkSize>((sizeId, drink)));
    }
    private async Task AddDrinkTagAsync(Drink drink, List<int> TagIds)
    {
        foreach (var tagId in TagIds)
            await _dataContext.DrinkTags.AddAsync(_mapper.Map<DrinkTag>((tagId, drink)));
    }
    private async Task<Drink> AddDrinkAsync(DrinkCreateDto dto)
    {
        var drink = _mapper.Map<Drink>(dto);

        var ImageNameInSystem = await _fileService.UploadAsync(dto.Image!, UploadDirectory.DRINK_IMAGE);
        drink.ImageNameInFileSystem = ImageNameInSystem;
        return drink;
    }
    private void CheckingTag(List<int> sagIds)
    {
        foreach (var tagId in sagIds!)
            if (!_dataContext.Tags.Any(c => c.Id == tagId))
                throw new NotFoundException("Tag", tagId);
    }
    private void CheckingSize(List<int> sizeIds)
    {
        foreach (var sizeId in sizeIds!)
            if (!_dataContext.Sizes.Any(c => c.Id == sizeId))
                throw new NotFoundException("Size", sizeId);
    }
    private void CheckingDrinkCategory(int drinkCategoryId)
    {
        if (!_dataContext.DrinkCategories.Any(c => c.Id == drinkCategoryId))
            throw new NotFoundException("DrinkCategory", drinkCategoryId);
    }
    private async Task<DrinkListItemDto> GetDrinkListItemDtoAsync(Drink drink)
    {
        var drinkInDb = await _dataContext.Drinks
                                      .Include(f => f.DrinkTags)!
                                      .ThenInclude(ft => ft.Tag)!
                                      .Include(f => f.DrinkSizes)!
                                      .ThenInclude(fs => fs.Size)
                                      .Include(f => f.DrinkCategory)!
                                      .FirstOrDefaultAsync(d => d.Id == drink.Id);
        var drinkDto = _mapper.Map<DrinkListItemDto>(drinkInDb);
        drinkDto.ImageURL = drinkDto.ImageURL != null
            ? _fileService.GetFileUrl(drinkDto.ImageURL, UploadDirectory.DRINK_IMAGE)
            : null!;

        return _mapper.Map<DrinkListItemDto>(drinkInDb);
    }
    #endregion
}
