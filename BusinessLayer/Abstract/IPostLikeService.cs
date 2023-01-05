using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPostLikeService
    {
        void PostLikeInsert(PostLike PostLike);
        void PostLikeUpdate(PostLike PostLike);
        void PostLikeDelete(PostLike PostLike);
        List<PostLike> PostLikeList();
        PostLike GetPostLikeById(int id);
    }
}
