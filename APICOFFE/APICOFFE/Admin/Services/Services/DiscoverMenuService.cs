using APICOFFE.Admin.Dtos.DiscoverMenu;
using APICOFFE.Admin.Services.Concretes;
using APICOFFE.Contracts.File;
using APICOFFE.Database.Models;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Admin.Services.Services
{
    public class DiscoverMenuService : IDiscoverMenuService
    {
        private readonly DataContext _dataContext;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public DiscoverMenuService(
            DataContext dataContext,
            IFileService fileService,
            IMapper mapper)
        {
            _dataContext = dataContext;
            _fileService = fileService;
            _mapper = mapper;
        }

        public async Task<DiscoverMenuUpdateResponseDto> GetAsync()
        {
            var discoverMenu = await _dataContext.DiscoverMenu
                  .Include(dm => dm.DiscoverMenuImages)
                  .AsNoTracking()
                  .SingleOrDefaultAsync();

            var discoverMenuDto = _mapper.Map<DiscoverMenuUpdateResponseDto>(discoverMenu);
            discoverMenuDto.ImageURL = discoverMenuDto.ImageURL != null
                ? _fileService.GetFileUrl(discoverMenuDto.ImageURL, UploadDirectory.DISCOVER_MENU_IMAGE)
                : null;

            return discoverMenuDto;
        }

        public async Task<DiscoverMenuUpdateResponseDto> UpdateAsync(DiscoverMenuUpdateRequsetDto dto)
        {
            var discoverMenu = await _dataContext.DiscoverMenu
                .Include(dm => dm.DiscoverMenuImages)
                .SingleOrDefaultAsync();

            _mapper.Map(dto, discoverMenu);

            await UpdateDiscoverMenuImage(dto,discoverMenu!);

            await _dataContext.SaveChangesAsync();

            return _mapper.Map<DiscoverMenuUpdateResponseDto>(discoverMenu);
        }

        private async Task UpdateDiscoverMenuImage(DiscoverMenuUpdateRequsetDto dto,DiscoverMenu discoverMenu)
        {
            foreach (var image in dto.Images!)
            {
                foreach (var imageInDb in discoverMenu!.DiscoverMenuImages!)
                    await _fileService.DeleteAsync(imageInDb.ImageNameInFileSystem, UploadDirectory.DISCOVER_MENU_IMAGE);

                var imageNameInSystem = await _fileService.UploadAsync(image, UploadDirectory.DISCOVER_MENU_IMAGE);

                await _dataContext.DiscoverMenuImages
                    .AddAsync(_mapper.Map<DiscoverMenuImage>((image, discoverMenu, imageNameInSystem)));
            }
        }
    }
}
