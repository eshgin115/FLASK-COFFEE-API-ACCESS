using APICOFFE.Admin.Dtos.OurHistory;
using APICOFFE.Contracts.File;
using APICOFFE.Exceptions;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Services.Services;

public class OurHistoryService : IOurHistoryService
{

    private readonly DataContext _dataContext;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;

    public OurHistoryService(
        DataContext dataContext,
        IFileService fileService,
        IMapper mapper)
    {
        _dataContext = dataContext;
        _fileService = fileService;
        _mapper = mapper;
    }
    public async Task<OurHistoryListItemDto> GetAsync()
    {
        var ourHistory = await _dataContext.OurHistory.SingleOrDefaultAsync();
        var dto = _mapper.Map<OurHistoryListItemDto>(ourHistory);
        dto.ImageURL = dto.ImageURL != null
            ? _fileService.GetFileUrl(dto.ImageURL, UploadDirectory.OUR_HISTORY)
            : null;
        return dto;
    }

    public async Task<OurHistoryListItemDto> UpdateAsync(OurHistoryUpdateDto dto)
    {

        var ourHistory = await _dataContext.OurHistory.SingleOrDefaultAsync()
            ?? throw new NotFoundException("OurHistory");

        _mapper.Map(dto, ourHistory);

        if (dto.Image is not null)
        {
            await _fileService.DeleteAsync(ourHistory.ImageNameInFileSystem, UploadDirectory.OUR_HISTORY);
            var imageFileNameInSystem = await _fileService.UploadAsync(dto.Image!, UploadDirectory.OUR_HISTORY);
            ourHistory.ImageNameInFileSystem = imageFileNameInSystem;
        }

        await _dataContext.SaveChangesAsync();

       return _mapper.Map<OurHistoryListItemDto>(ourHistory);
    }
}
