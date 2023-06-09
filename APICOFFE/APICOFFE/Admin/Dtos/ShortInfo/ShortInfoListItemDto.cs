﻿namespace APICOFFE.Admin.Dtos.ShortInfo;

public class ShortInfoListItemDto
{
    public int Id { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public string PlaceInfo { get; set; } = null!;
    public string ShortеTitleStreet { get; set; } = null!;
    public string TitleStreet { get; set; } = null!;
    public string WorkingHoursByDay { get; set; } = null!;
    public string HoursOfWork { get; set; } = null!;
}
