using APICOFFE.Admin.Dtos.Food;

namespace APICOFFE.Client.Dtos.MenuProduct;

public class MenuProductListItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<FoodListItemDto> Foods { get; set; }
}
