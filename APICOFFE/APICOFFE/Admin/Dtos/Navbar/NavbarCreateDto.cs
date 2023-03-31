namespace APICOFFE.Admin.Dtos.Navbar
{
    public class NavbarCreateDto
    {
        public string Name { get; set; } = default!;
        public string ToURL { get; set; } = default!;
        public int Order { get; set; }
        public bool IsViewOnHeader { get; set; }
        public bool IsViewOnFooter { get; set; }
    }
}
