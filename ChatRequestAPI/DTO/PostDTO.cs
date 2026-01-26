using static Enums.PostEnum;

namespace DTO
{
    public class PostDTO
    {
        public Guid? user_id { get; set; }
        public string? content { get; set; }
        public PostPrivacy privacy { get; set; } = PostPrivacy.Friends;
        public int? media_count { get; set; } = 0;
        public int like_count { get; set; } = 0;
        public int comment_count { get; set; } = 0;
        public List<Post_mediaDTO> mediaDTOs { get; set; }
    }
}

