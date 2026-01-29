using static Enums.PostEnum;

namespace DTO
{
    public class PostDTO : AuditableDTO
    {
        public Guid? user_id { get; set; }
        public Guid? posts_id { get; set; }
        public string? content { get; set; }
        public PostPrivacy privacy { get; set; }
        public PostStatus status { get; set; }
        public int? media_count { get; set; } = 0;
        public int? like_count { get; set; } = 0;
        public int? comment_count { get; set; } = 0;
        public UserPublicDTO? user { get; set; }
        public List<Post_mediaDTO>? mediaDTOs { get; set; }
        public List<Post_likesDTO>? userLikes { get; set; }
        public List<PostCommentsDTO>? userComments { get; set; }
    }
}

