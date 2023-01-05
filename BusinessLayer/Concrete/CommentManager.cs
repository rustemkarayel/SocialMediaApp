using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal commentDal;
        public CommentManager(ICommentDal commentDal) { 
            this.commentDal = commentDal;
        }

        public void CommentDelete(Comment comment)
        {
            commentDal.delete(comment);
        }

        public void CommentInsert(Comment comment)
        {
            commentDal.insert(comment);
        }

        public List<Comment> CommentList()
        {
            return commentDal.list();
        }

        public void CommentUpdate(Comment comment)
        {
            commentDal.update(comment);
        }

        public Comment GetCommentById(int id)
        {
            return commentDal.get(comment=>comment.CommentId== id);
        }
    }
}
