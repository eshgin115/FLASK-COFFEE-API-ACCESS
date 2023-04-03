using APICOFFE.Admin.Dtos.Subnavbar;
using APICOFFE.Database.Models;
using APICOFFE.Exceptions;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Services.Services;

public class SubnavbarService : ISubnavbarService
{
    private readonly DataContext _dataContext;
    private readonly ILogger<SubnavbarService> _logger;
    private readonly IMapper _mapper;

    public SubnavbarService(DataContext dataContext, ILogger<SubnavbarService> logger, IMapper mapper)
    {
        _dataContext = dataContext;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<List<SubnavbarListItemDto>> ListAsync()
    {
        var subnavbars = await _dataContext.Subnavbars.Include(s => s.Navbar).ToListAsync();
        return _mapper.Map<List<SubnavbarListItemDto>>(subnavbars);
    }
    public async Task<SubnavbarListItemDto> AddAsync(SubnavbarCreateDto dto)
    {
        if (!_dataContext.Navbars.Any(n => n.Id == dto.NavbarId))
                  throw new NotFoundException("Navbar",dto.NavbarId);

        var subnavbar = _mapper.Map<Subnavbar>(dto);
        await _dataContext.Subnavbars.AddAsync(subnavbar);

        await _dataContext.SaveChangesAsync();

       return _mapper.Map<SubnavbarListItemDto>(subnavbar);
    }

    public async Task<SubnavbarListItemDto> UpdateAsync(int id, SubnavbarUpdateDto dto)
    {
        var subnavbar = await _dataContext.Subnavbars.FirstOrDefaultAsync(b => b.Id == id)
            ?? throw new NotFoundException("Subnavbar",id);


        if (!_dataContext.Navbars.Any(n => n.Id == dto.NavbarId))
            throw new NotFoundException("Navbar", id);

        _mapper.Map(dto, subnavbar);
        await _dataContext.SaveChangesAsync();


        return _mapper.Map<SubnavbarListItemDto>(subnavbar);

    }

    public async Task DeleteAsync(int id)
    {
        var subnavbar = await _dataContext.Subnavbars.FirstOrDefaultAsync(b => b.Id == id)
            ?? throw new NotFoundException("subnavbar",id);

        _dataContext.Subnavbars.Remove(subnavbar);
        await _dataContext.SaveChangesAsync();

    }
}
