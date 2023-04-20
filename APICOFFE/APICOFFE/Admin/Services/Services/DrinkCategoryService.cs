using APICOFFE.Admin.Dtos.DrinkCategory;
using APICOFFE.Admin.Services.Concretes;
using APICOFFE.Contracts.ModelName;
using APICOFFE.Database.Models;
using APICOFFE.Exceptions;
using APICOFFE.Resources;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace APICOFFE.Admin.Services.Services;

public class DrinkCategoryService : IDrinkCategoryService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResource> _stringLocalizer;


    public DrinkCategoryService
        (DataContext dataContext,
        IMapper mapper,
        IStringLocalizer<SharedResource> stringLocalizer)
    {
        _dataContext = dataContext;
        _mapper = mapper;
        _stringLocalizer = stringLocalizer;
    }
    public async Task<DrinkCategoryListItemDto> AddAsync(DrinkCategoryCreateDto dto)
    {
        var drinkCategory = _mapper.Map<DrinkCategory>(dto);

        await _dataContext.DrinkCategories.AddAsync(drinkCategory);

        await _dataContext.SaveChangesAsync();

        return _mapper.Map<DrinkCategoryListItemDto>(drinkCategory);
    }

    public async Task DeleteAsync(int id)
    {
        var drinkCategory = await _dataContext.DrinkCategories.FirstOrDefaultAsync(c => c.Id == id)
            ?? throw new NotFoundException
            (_stringLocalizer.GetString(DomainModelNames.DRINK_CATEGORY).Value, key: id);

        _dataContext.DrinkCategories.Remove(drinkCategory);

        await _dataContext.SaveChangesAsync();
    }

    public async Task<List<DrinkCategoryListItemDto>> ListAsync()
    {
        var drinkCategories = await _dataContext.DrinkCategories.AsNoTracking().ToListAsync();

        return _mapper.Map<List<DrinkCategoryListItemDto>>(drinkCategories); 
    }

    public async Task<DrinkCategoryListItemDto> UpdateAsync(int id, DrinkCategoryUpdateDto dto)
    {
        var drinkCategory = await _dataContext.DrinkCategories.FirstOrDefaultAsync(c => c.Id == id)
                                ?? throw new NotFoundException(DomainModelNames.DRINK_CATEGORY, key: id);

        _mapper.Map(dto, drinkCategory);

        await _dataContext.SaveChangesAsync();

        return _mapper.Map<DrinkCategoryListItemDto>(drinkCategory);
    }
}
