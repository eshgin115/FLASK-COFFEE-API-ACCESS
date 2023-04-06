namespace APICOFFE.Admin.Dtos.Food;

public class FoodCreateDto
{
    public bool IsVegan { get; set; }
    public string Ingredients { get; set; } = null!;
    public int CategoryId { get; set; }
    public IFormFile MainImage { get; set; } = null!;
    public List<IFormFile> Images { get; set; } = null!;
    public string Title { get; set; } = null!;
    public decimal Price { get; set; }

    public string Content { get; set; } = null!;
    public List<int>? TagIds { get; set; }
    public List<int>? SizeIds { get; set; }
}
