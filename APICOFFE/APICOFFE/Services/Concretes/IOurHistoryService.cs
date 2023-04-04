using APICOFFE.Admin.Dtos.OurHistory;

namespace APICOFFE.Services.Concretes;

public interface IOurHistoryService
{
    Task<OurHistoryListItemDto> GetAsync();
    Task<OurHistoryListItemDto> UpdateAsync(OurHistoryUpdateDto dto);
}
