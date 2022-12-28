using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class PostLike
    {
        [Key]
        public int PostLikeId { get; set; }        
        public DateTime LikeTime { get; set; }
<<<<<<< HEAD

        //User ile ilişkilendirilecek.        
        public int PostLikerId { get; set; }
        public User PostLiker { get; set; }

        //Post ile ilişkilendirilecek.
        public int PostId { get; set; }
        public Post Post { get; set; }
=======
       
        //User ile ilişkilendirilecek.        
        public ICollection<User> PostLikers;
       
        //Post ile ilişkilendirilecek.
        public ICollection<Post> Posts {get; set;}
>>>>>>> 7c22d1494c4d32f53d7ca8e373adcb54a336d9fa
    }
}
