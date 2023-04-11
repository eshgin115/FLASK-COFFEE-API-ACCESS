using System.ComponentModel.DataAnnotations;

namespace APICOFFE.Admin.Dtos.Navbar
{
    public class NavbarUpdateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ToURL { get; set; }
        [Required]
        public int Order { get; set; }
        [Required]
        public bool IsViewOnHeader { get; set; }
        [Required]
        public bool IsViewOnFooter { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
