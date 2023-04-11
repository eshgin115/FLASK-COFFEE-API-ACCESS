using System.ComponentModel.DataAnnotations;

namespace APICOFFE.Admin.Dtos.FoodCategory;

public class FoodCategoryCreateDto
{
    [Required]
    public string Name { get; set; } = null!;
}
