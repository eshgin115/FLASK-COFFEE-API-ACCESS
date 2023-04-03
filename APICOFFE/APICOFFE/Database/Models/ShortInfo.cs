using APICOFFE.Database.Models.Common;

namespace APICOFFE.Database.Models;

public class ShortInfo : BaseEntity<int>, IAuditable
{
    public string PhoneNumber { get; set; } = null!;
    public string PlaceInfo { get; set; } = null!;
    public string ShortеTitleStreet { get; set; } = null!;
    public string TitleStreet { get; set; } = null!;
    public string WorkingHoursByDay { get; set; } = null!;
    public string HoursOfWork { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}