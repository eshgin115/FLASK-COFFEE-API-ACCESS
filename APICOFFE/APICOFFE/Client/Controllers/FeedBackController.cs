using APICOFFE.Client.Dtos.FeedBack;
using APICOFFE.Contracts.File;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Client.Controllers;
[ApiController]
[Route("clinet-feedback")]
public class FeedbackController:ControllerBase
{
    private readonly DataContext _dataContext;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;

    public FeedbackController(DataContext dataContext, IFileService fileService, IMapper mapper)
    {
        _dataContext = dataContext;
        _fileService = fileService;
        _mapper = mapper;
    }
    [HttpGet("feedbacks")]
    public async Task<IActionResult> ListAsync()
    {
        var feedBacks =
                       await _dataContext.FeedBacks.Include(f => f.Role)
                                   .Take(5)
                                   .ToListAsync();
        var feedBacksDto = _mapper.Map<List<FeedBackListItemDto>>(feedBacks);

        feedBacks.ForEach
                        (fbm => fbm.ImageNameInFileSystem = fbm.ImageNameInFileSystem != null
                        ? _fileService.GetFileUrl(fbm.ImageNameInFileSystem, UploadDirectory.FEEDBACK)
                        : null!);

        return Ok(feedBacksDto);
    }
}
