using APICOFFE.Database.Models.Common;

namespace APICOFFE.Database.Models
{
    public class DiscoverMenu : BaseEntity<int>, IAuditable
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string FirstHrefName { get; set; } = null!;
        public string FirstHrefURL { get; set; } = null!;
        public List<DiscoverMenuImage>? DiscoverMenuImages { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
