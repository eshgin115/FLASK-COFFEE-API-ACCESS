using APICOFFE.Admin.Dtos.WelcomeSlider;
using APICOFFE.Admin.Services.Concretes;
using APICOFFE.Contracts.File;
using APICOFFE.Database.Models;
using APICOFFE.Exceptions;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Admin.Services.Services;

public class WelcomeSliderService : IWelcomeSliderService
{
    private readonly DataContext _dataContext;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;

    public WelcomeSliderService(
        DataContext dataContext,
        IFileService fileService,
        IMapper mapper)
    {
        _dataContext = dataContext;
        _fileService = fileService;
        _mapper = mapper;
    }

    public async Task<List<WelcomeSliderListItemDto>> ListAsync()
    {
        var welcomeSliders = await _dataContext.WelcomeSliders.AsNoTracking().ToListAsync();
        var welcomeSliderDto = _mapper.Map<List<WelcomeSliderListItemDto>>(welcomeSliders);

        welcomeSliderDto.ForEach(fbm => fbm.ImageURL = fbm.ImageURL != null
        ? _fileService.GetFileUrl(fbm.ImageURL, UploadDirectory.WELCOME_SLIDER)
        : null!);
        return welcomeSliderDto;
    }
    public async Task DeleteAsync(int id)
    {
        var welcomeSlider = await _dataContext.WelcomeSliders.FirstOrDefaultAsync(b => b.Id == id)
                                              ?? throw new NotFoundException("WelcomeSlider", id);

        await _fileService.DeleteAsync(welcomeSlider.ImageNameInFileSystem, UploadDirectory.WELCOME_SLIDER);

        _dataContext.WelcomeSliders.Remove(welcomeSlider);
        await _dataContext.SaveChangesAsync();
    }

    public async Task<WelcomeSliderListItemDto> AddAsync(WelcomeSliderCreateDto dto)
    {

        if (_dataContext.WelcomeSliders.Any(n => n.Order == dto.Order))
            throw new ExistException("Order allready exist");

        string imageNameInSystem = null;

        if (dto.Image is not null) imageNameInSystem =
                   await _fileService.UploadAsync(dto!.Image!, UploadDirectory.WELCOME_SLIDER);


        var welcomeSlider = _mapper.Map<WelcomeSlider>(dto);
        welcomeSlider.ImageNameInFileSystem = imageNameInSystem;
        await _dataContext.WelcomeSliders.AddAsync(welcomeSlider);

        await _dataContext.SaveChangesAsync();

        return _mapper.Map<WelcomeSliderListItemDto>(welcomeSlider);
    }

    public async Task<WelcomeSliderListItemDto> UpdateAsync(int id, WelcomeSliderUpdateDto dto)
    {
        var welcomeSlider = await _dataContext.WelcomeSliders.FirstOrDefaultAsync(b => b.Id == id)
                                  ?? throw new NotFoundException("welcomeSlider", id);


        if (_dataContext.WelcomeSliders.Any(s => s.Order == dto.Order) && dto.Order != welcomeSlider.Order)
            throw new ExistException("Order allready exist");

        string imageFileNameInSystem = null!;
        if (dto.Image is not null)
        {
            await _fileService.DeleteAsync(welcomeSlider.ImageNameInFileSystem, UploadDirectory.WELCOME_SLIDER);
            imageFileNameInSystem = await _fileService.UploadAsync(dto.Image, UploadDirectory.WELCOME_SLIDER);
        }

        _mapper.Map(dto, welcomeSlider);
        welcomeSlider.ImageNameInFileSystem = imageFileNameInSystem ?? welcomeSlider.ImageNameInFileSystem;

        await _dataContext.SaveChangesAsync();

        return _mapper.Map<WelcomeSliderListItemDto>(welcomeSlider);
    }
}
