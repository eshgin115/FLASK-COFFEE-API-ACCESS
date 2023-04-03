namespace APICOFFE.Admin.Dtos.Navbar
{
    public class NavbarUpdateDto
    {
        public string Name { get; set; }
        public string ToURL { get; set; }
        public int Order { get; set; }
        public bool IsViewOnHeader { get; set; }
        public bool IsViewOnFooter { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
