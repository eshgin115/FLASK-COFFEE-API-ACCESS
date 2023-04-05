using APICOFFE.Client.Dtos.FeedBack;
using APICOFFE.Contracts.File;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Client.Controllers;
[ApiController]
public class FeedBackController : ControllerBase
{
    private readonly DataContext _dataContext;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;

    public FeedBackController(DataContext dataContext, IFileService fileService, IMapper mapper)
    {
        _dataContext = dataContext;
        _fileService = fileService;
        _mapper = mapper;
    }
    [HttpGet("client/feedback/list")]
    public async Task<IActionResult> IndexAsync()
    {
        var feedBacks = await _dataContext.FeedBacks.Include(f => f.Role)
                                       .Take(5)
                                       .ToListAsync();
        var feedBacksDto = _mapper.Map<List<FeedBackListItemDto>>(feedBacks);

        feedBacksDto.ForEach
                        (fbm => fbm.ProfilePhotoUrl = fbm.ProfilePhotoUrl != null
                        ? _fileService.GetFileUrl(fbm.ProfilePhotoUrl, UploadDirectory.FEEDBACK)
                        : null!);
        return Ok(feedBacksDto);
    }
}
