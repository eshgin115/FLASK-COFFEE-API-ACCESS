namespace APICOFFE.Admin.Dtos.Subnavbar;

public class SubnavbarUpdateDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string ToURL { get; set; } = default!;
    public int Order { get; set; }
    public int NavbarId { get; set; }
}
