namespace APICOFFE.Client.Dtos.Basket;

public class PlaceOrderDto
{
    public List<FoodListItemDto> FoodListItemDtos { get; set; } = new List<FoodListItemDto>();
    public List<DrinkListItemDto> DrinkListItemDtos { get; set; } = new List<DrinkListItemDto>();
    public class FoodListItemDto
    {
        public int? Id { get; set; }
        public decimal Quantity { get; set; }
        public int SizId { get; set; }
    }
    public class DrinkListItemDto
    {
        public int? Id { get; set; }
        public decimal Quantity { get; set; }
        public int SizeId { get; set; }
    }
}
