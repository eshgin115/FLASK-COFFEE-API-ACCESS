namespace APICOFFE.Client.Dtos.Product;

public class ModalDto
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public int? QuantityFood { get; set; }
    public int? QuantityDrink { get; set; }
    public int? SizeId { get; set; }

    public ModalDto(int id, decimal price, int? quantityFood, int? quantityDrink, int? sizeId)
    {
        Id = id;
        Price = price;
        QuantityFood = quantityFood;
        QuantityDrink = quantityDrink;
        SizeId = sizeId;
    }

    public ModalDto()
    {

    }
}
