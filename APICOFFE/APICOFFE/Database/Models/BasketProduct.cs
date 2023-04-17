using APICOFFE.Database.Models.Common;

namespace APICOFFE.Database.Models
{
    public class BasketProduct : BaseEntity<int>, IAuditable
    {
        public int BasketId { get; set; }
        public Basket? Basket { get; set; }
        public decimal Price { get; set; }
        public int? FoodId { get; set; }
        public Food? Food { get; set; }
        public int? DrinkId { get; set; }
        public Drink? Drink { get; set; }
        public int? QuantityFood { get; set; }
        public int? QuantityDrink { get; set; }
        public int? SizeId { get; set; }
        public Size? Size { get; set; }


        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
