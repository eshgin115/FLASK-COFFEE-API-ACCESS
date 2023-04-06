using APICOFFE.Admin.Dtos.OurHistory;

namespace APICOFFE.Admin.Services.Concretes;

public interface IOurHistoryService
{
    Task<OurHistoryListItemDto> GetAsync();
    Task<OurHistoryListItemDto> UpdateAsync(OurHistoryUpdateDto dto);
}
