using EntityLayer;

namespace SocialMediaApp.Models
{
    public class CommentLikeUserCommentModel
    {
        public CommentLike CommentLikeModel { get; set; }  
        public IEnumerable<Comment> CommentModel { get; set; }
        public IEnumerable<User> UserModel { get; set; }
    }
}
