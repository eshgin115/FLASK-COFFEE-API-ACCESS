using System.ComponentModel.DataAnnotations;

namespace APICOFFE.Admin.Dtos.ShortInfo;

public class ShortInfoUpdateDto
{
    [Required]
    public string PhoneNumber { get; set; } = null!;
    [Required]
    public string PlaceInfo { get; set; } = null!;
    [Required]
    public string ShortеTitleStreet { get; set; } = null!;
    [Required]
    public string TitleStreet { get; set; } = null!;
    [Required]
    public string WorkingHoursByDay { get; set; } = null!;
    [Required]
    public string HoursOfWork { get; set; } = null!;
}
