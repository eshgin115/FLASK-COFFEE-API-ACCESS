namespace APICOFFE.Admin.Dtos.Subnavbar
{
    public class SubnavbarCreateDto
    {
        public string Name { get; set; } = default!;
        public string ToURL { get; set; } = default!;
        public int Order { get; set; } = default!;
        public int NavbarId { get; set; } = default!;
    }
}
