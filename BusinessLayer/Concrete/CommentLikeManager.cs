using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentLikeManager : ICommentLikeService
    {
        ICommentLikeDal CommentLikeDal;
        public CommentLikeManager(ICommentLikeDal CommentLikeDal)
        {
            this.CommentLikeDal = CommentLikeDal;
        }

        public void CommentLikeDelete(CommentLike CommentLike)
        {
            CommentLikeDal.delete(CommentLike);
        }

        public void CommentLikeInsert(CommentLike CommentLike)
        {
            CommentLikeDal.insert(CommentLike);
        }

        public List<CommentLike> CommentLikeList()
        {
            return CommentLikeDal.list();
        }

        public void CommmentLikeUpdate(CommentLike CommentLike)
        {
            CommentLikeDal.update(CommentLike);
        }

        public CommentLike GetCommentLikeById(int id)
        {
            return CommentLikeDal.get(CommentLike=>CommentLike.CommentLikeId== id);
        }
    }
}
