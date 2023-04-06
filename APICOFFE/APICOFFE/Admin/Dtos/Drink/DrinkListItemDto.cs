namespace APICOFFE.Admin.Dtos.Drink;

public class DrinkListItemDto
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Content { get; set; } = default!;
    public decimal Price { get; set; } = default!;
    public string ImageURL { get; set; } = default!;
    public List<ItemDto>? DrinkTags { get; set; } = default!;
    public List<ItemDto>? DrinkSizes { get; set; } = default!;
    public string CategoryName { get; set; } = default!;
    public class ItemDto
    {

        public int Id { get; set; } = default!;
        public string Name { get; set; } = null!;
    }

}
