﻿namespace APICOFFE.Client.Dtos.FeedBack;

public class FeedBackListItemDto
{
    public string ProfilePhotoUrl { get; set; } = default!;
    public string FullName { get; set; } = default!;
    public string RoleName { get; set; } = default!;
    public string Content { get; set; } = default!;
}
