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
    public class PostManager : IPostService
    {
        IPostDal PostDal;
        public PostManager(IPostDal PostDal)
        {
                this.PostDal= PostDal;
        }
        public Post GetPostById(int id)
        {
            return PostDal.get(Post=>Post.PostId== id);
        }

        public void PostDelete(Post Post)
        {
            PostDal.delete(Post);
        }

        public void PostInsert(Post Post)
        {
            PostDal.insert(Post);
        }

        public List<Post> PostList()
        {
            return PostDal.list();
        }

        public void PostUpdate(Post Post)
        {
            PostDal.update(Post);
        }
    }
}
