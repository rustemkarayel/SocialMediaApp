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
    public class PostLikeManager : IPostLikeService
    {
        IPostLikeDal PostLikeDal;
        public PostLikeManager(IPostLikeDal PostLikeDal)
        {
            this.PostLikeDal = PostLikeDal;
        }

        public PostLike GetPostLikeById(int id)
        {
            return PostLikeDal.get(PostLike=>PostLike.PostLikeId==id);
        }

        public void PostLikeDelete(PostLike PostLike)
        {
            PostLikeDal.delete(PostLike);
        }

        public void PostLikeInsert(PostLike PostLike)
        {
            PostLikeDal.insert(PostLike);
        }

        public List<PostLike> PostLikeList()
        {
            return PostLikeDal.list();
        }

        public void PostLikeUpdate(PostLike PostLike)
        {
            PostLikeDal.update(PostLike);
        }
    }
}
