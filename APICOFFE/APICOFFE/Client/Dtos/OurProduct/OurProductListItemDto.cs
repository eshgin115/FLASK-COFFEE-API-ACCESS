﻿namespace APICOFFE.Client.Dtos.OurProduct;

public class OurProductListItemDto
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public decimal Price { get; set; }
    public string ImageURL { get; set; }
}
