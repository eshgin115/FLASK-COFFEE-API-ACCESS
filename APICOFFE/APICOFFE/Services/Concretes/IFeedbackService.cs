using APICOFFE.Admin.Dtos.FeedBack;

namespace APICOFFE.Services.Concretes;

public interface IFeedbackService
{
    Task<FeedBackListItemDto> AddAsync(FeedBackCreateDto dto);
    Task<FeedBackListItemDto> UpdateAsync(int id, FeedBackUpdateRequestDto dto);
    Task<List<FeedBackListItemDto>> ListAsync();
    Task DeleteAsync(int id);

}
