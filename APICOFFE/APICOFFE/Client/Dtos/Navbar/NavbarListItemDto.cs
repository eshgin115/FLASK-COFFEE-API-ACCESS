namespace APICOFFE.Client.Dtos.Navbar;

public class NavbarListItemDto
{

    public string Name { get; set; } = default!;
    public string URL { get; set; } = default!;
    public List<SubnavbarListItemDto> SubnavbarItems { get; set; } = default!;

    public class SubnavbarListItemDto
    {
        public SubnavbarListItemDto(string name, string toURL)
        {
            Name = name;
            ToURL = toURL;
        }

        public string Name { get; set; }
        public string ToURL { get; set; }
    }
}
