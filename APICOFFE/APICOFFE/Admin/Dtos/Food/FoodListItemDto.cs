namespace APICOFFE.Admin.Dtos.Food;

public class FoodListItemDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public decimal Price { get; set; }
    public string ImageURL { get; set; }
    public bool IsVegan { get; set; }
    public string Ingredients { get; set; } = null!;
    public List<ItemDto>? FoodTags { get; set; }
    public List<ItemDto>? FoodSizes { get; set; }
    public string CategoryName { get; set; }
    public class ItemDto
    {
        public ItemDto()
        {

        }
        public ItemViewModel(int id, string? name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }

}
