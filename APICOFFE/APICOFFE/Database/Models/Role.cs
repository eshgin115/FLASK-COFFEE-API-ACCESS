using APICOFFE.Database.Models.Common;

namespace APICOFFE.Database.Models
{
    public class Role : BaseEntity<int>, IAuditable
    {
        public string Name { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<User>? Users { get; set; }
        public List<FeedBack>? FeedBacks { get; set; }
    }
}
