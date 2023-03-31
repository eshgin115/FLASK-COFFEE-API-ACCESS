using APICOFFE.Database.Models.Common;

namespace APICOFFE.Database.Models
{
    public class DiscoverMenuImage : BaseEntity<int>
    {
        public string ImageName { get; set; } = null!;
        public string ImageNameInFileSystem { get; set; } = null!;

        public int DiscoverMenuId { get; set; }
        public DiscoverMenu? DiscoverMenu { get; set; }
    }
}
