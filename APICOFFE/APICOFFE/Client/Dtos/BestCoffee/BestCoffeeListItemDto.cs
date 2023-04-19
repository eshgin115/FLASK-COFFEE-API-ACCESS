namespace APICOFFE.Client.Dtos.BestCoffee;

public class BestCoffeeListItemDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public decimal Price { get; set; }
    public string ImageURL { get; set; } = null!;
}
