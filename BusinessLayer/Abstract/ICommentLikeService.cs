using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentLikeService
    {
        void CommentLikeInsert(CommentLike CommentLike);
        void CommmentLikeUpdate(CommentLike CommentLike);
        void CommentLikeDelete(CommentLike CommentLike);
        List<CommentLike> CommentLikeList();
        CommentLike GetCommentLikeById(int id);
    }
}
