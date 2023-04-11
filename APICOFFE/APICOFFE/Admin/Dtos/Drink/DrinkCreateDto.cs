using System.ComponentModel.DataAnnotations;

namespace APICOFFE.Admin.Dtos.Drink;

public class DrinkCreateDto
{
    [Required]
    public string Title { get; set; } = null!;
    [Required]
    public decimal Price { get; set; }
    [Required]
    public int DrinkCategoryId { get; set; }
    [Required]
    public IFormFile Image { get; set; } = null!;
    [Required]
    public string Content { get; set; } = null!;
    [Required]
    public List<int>? TagIds { get; set; }
    [Required]
    public List<int>? SizeIds { get; set; }
}
