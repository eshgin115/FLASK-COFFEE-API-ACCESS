using APICOFFE.Admin.Dtos.FoodCategory;
using APICOFFE.Admin.Services.Concretes;
using APICOFFE.Contracts.ModelName;
using APICOFFE.Database.Models;
using APICOFFE.Exceptions;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Admin.Services.Services;

public class FoodCategoryService : IFoodCategoryService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;


    public FoodCategoryService(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }
    public async Task<List<FoodCategoryListItemDto>> ListAsync()
    {
        var foodCategories = await _dataContext.FoodCategories.AsNoTracking().ToListAsync();

        return _mapper.Map<List<FoodCategoryListItemDto>>(foodCategories);
    }
    public async Task<FoodCategoryListItemDto> AddAsync(FoodCategoryCreateDto dto)
    {
        var foodCategory = _mapper.Map<FoodCategory>(dto);

        await _dataContext.FoodCategories.AddAsync(foodCategory);

        await _dataContext.SaveChangesAsync();

        return _mapper.Map<FoodCategoryListItemDto>(foodCategory);
    }


    public async Task<FoodCategoryListItemDto> UpdateAsync(int id, FoodCategoryUpdateDto dto)
    {
        var foodCategory = await _dataContext.FoodCategories.FirstOrDefaultAsync(c => c.Id == id)
            ?? throw new NotFoundException(DomainModelNames.FOOD_CATEGORY, id);

        _mapper.Map(dto, foodCategory);

        await _dataContext.SaveChangesAsync();

        return _mapper.Map<FoodCategoryListItemDto>(foodCategory);
    }
    public async Task DeleteAsync(int id)
    {
        var foodCategory = await _dataContext.FoodCategories.FirstOrDefaultAsync(c => c.Id == id)
                  ?? throw new NotFoundException(DomainModelNames.FOOD_CATEGORY, id);

        _dataContext.FoodCategories.Remove(foodCategory);

        await _dataContext.SaveChangesAsync();
    }

}
