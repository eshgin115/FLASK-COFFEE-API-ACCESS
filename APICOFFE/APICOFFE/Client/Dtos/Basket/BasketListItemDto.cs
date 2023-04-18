namespace APICOFFE.Client.Dtos.Basket;

public class BasketListItemDto
{
    public List<FoodListItemDto> FoodListItemDtos { get; set; }=new List<FoodListItemDto>();
    public List<DrinkListItemDto> DrinkListItemDtos { get; set; } = new List<DrinkListItemDto>();
    public decimal SubTotal { get; set; }
   
    public class FoodListItemDto
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string Content { get; set; }
        public string? ImageUrl { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Total { get; set; }
        public List<ItemDto>? Sizes { get; set; }
        public int? SizeId { get; set; }
    }
    public class DrinkListItemDto
    {

        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Total { get; set; }
        public List<ItemDto>? Sizes { get; set; }
        public int? SizeId { get; set; }
    }
    public class ItemDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
      
    }
}
