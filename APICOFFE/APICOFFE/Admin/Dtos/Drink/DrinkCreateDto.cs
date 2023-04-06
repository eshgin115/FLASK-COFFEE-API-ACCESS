namespace APICOFFE.Admin.Dtos.Drink;

public class DrinkCreateDto
{
    public string Title { get; set; } = null!;
    public decimal Price { get; set; }
    public int DrinkCategoryId { get; set; }
    public IFormFile Image { get; set; } = null!;
    public string Content { get; set; } = null!;
    public List<int>? TagIds { get; set; }
    public List<int>? SizeIds { get; set; }
}
