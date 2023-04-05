using APICOFFE.Admin.Dtos.DrinkCategory;
using APICOFFE.Database.Models;
using APICOFFE.Exceptions;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Services.Services;

public class DrinkCategoryService : IDrinkCategoryService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;


    public DrinkCategoryService(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
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
            ?? throw new NotFoundException("DrinkCategory", id);

        _dataContext.DrinkCategories.Remove(drinkCategory);

        await _dataContext.SaveChangesAsync();
    }

    public async Task<List<DrinkCategoryListItemDto>> ListAsync()
    {
        var drinkCategories = await _dataContext.DrinkCategories.ToListAsync();
        var drinkCategoriesDto = _mapper.Map<List<DrinkCategoryListItemDto>>(drinkCategories);

        return drinkCategoriesDto;
    }

    public async Task<DrinkCategoryListItemDto> UpdateAsync(int id, DrinkCategoryUpdateDto dto)
    {
        var drinkCategory = await _dataContext.DrinkCategories.FirstOrDefaultAsync(c => c.Id == id)
                                ?? throw new NotFoundException("DrinkCategory", id);

        _mapper.Map(dto, drinkCategory);

        await _dataContext.SaveChangesAsync();

        return _mapper.Map<DrinkCategoryListItemDto>(drinkCategory);
    }
}
