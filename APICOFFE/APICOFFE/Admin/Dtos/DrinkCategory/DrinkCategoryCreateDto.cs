using System.ComponentModel.DataAnnotations;

namespace APICOFFE.Admin.Dtos.DrinkCategory;

public class DrinkCategoryCreateDto
{

    [Required]
    public string Name { get; set; } = default!;
}
