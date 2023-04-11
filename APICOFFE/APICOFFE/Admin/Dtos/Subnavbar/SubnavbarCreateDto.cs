using System.ComponentModel.DataAnnotations;

namespace APICOFFE.Admin.Dtos.Subnavbar
{
    public class SubnavbarCreateDto
    {
        [Required]
        public string Name { get; set; } = default!;
        [Required]
        public string ToURL { get; set; } = default!;
        [Required]
        public int Order { get; set; } = default!;
        [Required]
        public int NavbarId { get; set; } = default!;
    }
}
