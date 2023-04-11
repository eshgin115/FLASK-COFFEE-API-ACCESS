using System.ComponentModel.DataAnnotations;

namespace APICOFFE.Admin.Dtos.DrinkCategory;

public class DrinkCategoryUpdateDto
{

    [Required]
    public string Name { get; set; } = null!;

}
