using APICOFFE.Admin.Dtos.FeedBack;

namespace APICOFFE.Admin.Services.Concretes;

public interface IFeedbackSevice
{
    Task<FeedBackListItemDto> AddAsync(FeedBackCreateDto dto);
    Task<FeedBackListItemDto> UpdateAsync(int id, FeedBackUpdateRequestDto dto);
    Task<List<FeedBackListItemDto>> ListAsync();
    Task DeleteAsync(int id);
}
