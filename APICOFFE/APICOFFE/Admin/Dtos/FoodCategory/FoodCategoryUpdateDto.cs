using System.ComponentModel.DataAnnotations;

namespace APICOFFE.Admin.Dtos.FoodCategory;

public class FoodCategoryUpdateDto
{
    [Required]
    public string Name { get; set; } = null!;
}
