using APICOFFE.Admin.Dtos.FeedBack;
using APICOFFE.Admin.Services.Concretes;
using APICOFFE.Contracts.File;
using APICOFFE.Contracts.ModelName;
using APICOFFE.Database.Models;
using APICOFFE.Exceptions;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Admin.Services.Services
{
    public class FeedbackService : IFeedbackSevice
    {
        private readonly DataContext _dataContext;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        public FeedbackService
            (DataContext dataContext,
            IFileService fileService,
            IMapper mapper)
        {
            _dataContext = dataContext;
            _fileService = fileService;
            _mapper = mapper;
        }
        #region List
        public async Task<List<FeedBackListItemDto>> ListAsync()
        {

            var feedBacks = await _dataContext.FeedBacks.AsNoTracking().Include(f => f.Role).ToListAsync();

            var feedBacksDto = _mapper.Map<List<FeedBackListItemDto>>(feedBacks);

            feedBacksDto.ForEach(fbm => fbm.ProfilePhotoUrl = fbm.ProfilePhotoUrl != null
            ? _fileService.GetFileUrl(fbm.ProfilePhotoUrl, UploadDirectory.FEEDBACK)
            : null!);

            return feedBacksDto;
        }
        #endregion

        #region Add
        public async Task<FeedBackListItemDto> AddAsync(FeedBackCreateDto dto)
        {
            var role = await _dataContext.Roles.FirstOrDefaultAsync(r => r.Id == dto.RoleId)
                                                ?? throw new NotFoundException(DomainModelNames.ROLE, dto.RoleId);
            var feedBack = _mapper.Map<FeedBack>(dto);

            feedBack.ImageNameInFileSystem =
                 await _fileService.UploadAsync(dto.ProfilePhoto, UploadDirectory.FEEDBACK);

            await _dataContext.FeedBacks.AddAsync(feedBack);

            await _dataContext.SaveChangesAsync();

            return _mapper.Map<FeedBackListItemDto>(feedBack);
        }
        #endregion

        #region Update
        public async Task<FeedBackListItemDto> UpdateAsync(int id, FeedBackUpdateRequestDto dto)
        {

            var feedBack = await _dataContext.FeedBacks.
                FirstOrDefaultAsync(fb => fb.Id == id) ?? throw new NotFoundException(DomainModelNames.FEED_BACK, id);

            var role = await _dataContext.Roles.AsNoTracking().
                  FirstOrDefaultAsync(r => r.Id == dto.RoleId) 
                  ?? throw new NotFoundException(DomainModelNames.ROLE, dto.RoleId!);



            var feedBackPpImageNameInFileSystem= await FeedBackImageUpdateAsync(dto, feedBack);


            _mapper.Map(dto, feedBack);

            feedBack.ImageNameInFileSystem = feedBackPpImageNameInFileSystem ?? feedBack.ImageNameInFileSystem;
            await _dataContext.SaveChangesAsync();

            return _mapper.Map<FeedBackListItemDto>(feedBack);
        }


        #endregion

        #region Delete
        public async Task DeleteAsync(int id)
        {
            var feedBack = await _dataContext.FeedBacks
                .FirstOrDefaultAsync(f => f.Id == id) ?? throw new NotFoundException(DomainModelNames.FEED_BACK, id);

            if (feedBack.ImageNameInFileSystem is not null)
                await _fileService.DeleteAsync(feedBack.ImageNameInFileSystem, UploadDirectory.FEEDBACK);

            _dataContext.FeedBacks.Remove(feedBack);
            await _dataContext.SaveChangesAsync();
        }
        #endregion
        private async Task<string> FeedBackImageUpdateAsync(FeedBackUpdateRequestDto dto,FeedBack feedBack)
        {
            if (dto.ProfilePhoto is not null)
            {
                await _fileService.DeleteAsync
                    (feedBack.ImageNameInFileSystem, UploadDirectory.FEEDBACK);

                return  await _fileService.UploadAsync
                    (dto.ProfilePhoto, UploadDirectory.FEEDBACK);
            }
            return default!;
        }
    }
}
