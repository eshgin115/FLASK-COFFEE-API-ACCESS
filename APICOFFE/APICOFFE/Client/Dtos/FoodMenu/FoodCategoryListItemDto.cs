namespace APICOFFE.Client.Dtos.FoodMenu;

public class FoodCategoryListItemDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public List<FoodListItemDto> Foods { get; set; }

    public class FoodListItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public decimal Price { get; set; }
        public string ImageURL { get; set; }

    }
}
