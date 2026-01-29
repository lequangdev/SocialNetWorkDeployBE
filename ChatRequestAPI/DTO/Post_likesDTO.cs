

namespace DTO
{
    public class Post_likesDTO
    {
        public Guid post_likes_id { get; set; }
        public Guid user_id { get; set; }
        public string? likes_type { get; set; }
    }
}
