using APICOFFE.Admin.Dtos.ShortInfo;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Services.Services;

public class ShortInfoService : IShortInfoService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;

    public ShortInfoService(
        DataContext dataContext
           , IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }


   

    public async Task<ShortInfoListItemDto> GetAsync()
    {
        var shortInfo = await _dataContext.ShortInfo.SingleOrDefaultAsync();

        return _mapper.Map<ShortInfoListItemDto>(shortInfo);
    }

    public async Task<ShortInfoListItemDto> UpdateAsync( ShortInfoUpdateDto dto)
    {
        var shortInfo = await _dataContext.ShortInfo.SingleOrDefaultAsync();

        _mapper.Map(dto, shortInfo);

        await _dataContext.SaveChangesAsync();

        return _mapper.Map<ShortInfoListItemDto>(shortInfo);
    }
}
