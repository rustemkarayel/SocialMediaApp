using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPostService
    {
        void PostInsert(Post Post);
        void PostUpdate(Post Post);
        void PostDelete(Post Post);
        List<Post> PostList();
        Post GetPostById(int id);      
    }
}
