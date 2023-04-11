using System.ComponentModel.DataAnnotations;

namespace APICOFFE.Admin.Dtos.Food;

public class FoodUpdateDto
{

    [Required]
    public bool IsVegan { get; set; }
    [Required]
    public string Ingredients { get; set; } = null!;
    [Required]
    public int CategoryId { get; set; }
    [Required]
    public string Title { get; set; } = null!;
    [Required]
    public string Content { get; set; } = null!;
    [Required]
    public decimal Price { get; set; }
    [Required]
    public List<int> TagIds { get; set; }
    [Required]
    public List<int> SizeIds { get; set; }
}
