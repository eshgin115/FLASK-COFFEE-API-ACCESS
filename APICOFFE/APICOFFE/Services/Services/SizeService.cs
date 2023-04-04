using APICOFFE.Admin.Dtos.Size;
using APICOFFE.Database.Models;
using APICOFFE.Exceptions;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Services.Services;

public class SizeService : ISizeService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;


    public SizeService(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }
    public async Task<SizeListItemDto> AddAsync(SizeCreateDto dto)
    {
        var size = _mapper.Map<Size>(dto);
        await _dataContext.Sizes.AddAsync(size);

        await _dataContext.SaveChangesAsync();

        return _mapper.Map<SizeListItemDto>(size);
    }

    public async Task DeleteAsync(int id)
    {
        var size = await _dataContext.Sizes/*.Include(s => s.FoodSizes)*/.FirstOrDefaultAsync(c => c.Id == id)
             ?? throw new NotFoundException("Size", id);

        _dataContext.Sizes.Remove(size);
        await _dataContext.SaveChangesAsync();
    }

    public async Task<List<SizeListItemDto>> ListAsync()
    {
        var sizes = await _dataContext.Sizes.AsNoTracking().ToListAsync();

        return _mapper.Map<List<SizeListItemDto>>(sizes);
    }

    public async Task<SizeListItemDto> UpdateAsync(int id, SizeUpdateDto dto)
    {
        var size = await _dataContext.Sizes.FirstOrDefaultAsync(c => c.Id == id)
         ?? throw new NotFoundException("Size", id);

        _mapper.Map(dto, size);

        await _dataContext.SaveChangesAsync();

        return _mapper.Map<SizeListItemDto>(size);
    }
}
