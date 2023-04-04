using APICOFFE.Admin.Dtos.Tag;
using APICOFFE.Database.Models;
using APICOFFE.Exceptions;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Services.Services;

public class TagService : ITagService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;


    public TagService(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }
    public async Task<TagListItemDto> AddAsync(TagCreateDto dto)
    {
        var tag = _mapper.Map<Tag>(dto);

        await _dataContext.Tags.AddAsync(tag);

        await _dataContext.SaveChangesAsync();

        return _mapper.Map<TagListItemDto>(tag);
    }

    public async Task DeleteAsync(int id)
    {
        var tag = await _dataContext.Tags/*.Include(s => s.FoodSizes)*/.FirstOrDefaultAsync(c => c.Id == id)
              ?? throw new NotFoundException("Tag", id);

        _dataContext.Tags.Remove(tag);
        await _dataContext.SaveChangesAsync();
    }

    public async Task<List<TagListItemDto>> ListAsync()
    {
        var tags = await _dataContext.Tags.AsNoTracking().ToListAsync();

        return _mapper.Map<List<TagListItemDto>>(tags);
    }

    public async Task<TagListItemDto> UpdateAsync(int id, TagUpdateDto dto)
    {
        var tag = await _dataContext.Tags.FirstOrDefaultAsync(c => c.Id == id)
           ?? throw new NotFoundException("Tag", id);

        _mapper.Map(dto, tag);

        await _dataContext.SaveChangesAsync();

        return _mapper.Map<TagListItemDto>(tag);
    }
}
