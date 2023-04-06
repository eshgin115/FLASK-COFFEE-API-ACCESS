namespace APICOFFE.Admin.Dtos.Drink;

public class DrinkUpdateDto
{
    public IFormFile? Image { get; set; } = null!;
    public int DrinkCategoryId { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public decimal Price { get; set; }
    public List<int> TagIds { get; set; } = null!;
    public List<int> SizeIds { get; set; } = null!;
}
