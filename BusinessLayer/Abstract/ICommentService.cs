using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        void CommentInsert(Comment comment);
        void CommentUpdate(Comment comment);
        void CommentDelete(Comment comment);
        List<Comment> CommentList();
        Comment GetCommentById(int id);
    }
}
