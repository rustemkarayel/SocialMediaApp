using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }        
        public DateTime GenerateDate { get; set; }
        [StringLength(300)]
        public string Content { get; set; }
        [StringLength(300)]
        public string Description { get; set; }
<<<<<<< HEAD
        
        //Location ile ilişkilendirilecek.
        public int LocationId { get; set; }
        public Location Location { get; set; }

        //Type ile ilişkilendirilecek.
        public int TypeId { get; set; }
        public Type Type { get; set; }

        //User ile ilişkilendirilecek.
        public int UserId { get; set; }
        public User Creator  { get; set; }

        //Comment ile ilişkilendirilecek.
        public ICollection<Comment> Comments { get; set; }

        //Tag ile ilişkilendirilecek.
        public ICollection<Tag> Tags { get; set; }

        //PostLike ile ilişkilendirilecek.
        public ICollection<PostLike> PostLikes { get; set; }

        //Saved ile ilişkilendirilecek.
        public ICollection<Saved> Saveds { get; set; }
=======
        //User ile ilişkilendirilecek.       
        public int CreatorId { get; set; }
        public User Creator { get; set; }
        //Location ile ilişkilendirilecek.
        public int LocationId {get; set;}
        public Location Location {get; set;}
        //Type ile ilişkilendirilecek.
        public int TypeId {get; set;}
        public Type Type {get; set;}
        //Comment ile ilişkilendirilecek.
        public int CommentId {get; set;}
        public Comment Comment {get; set;}
        //Tag ile ilişkilendirilecek.
        public int TagId {get; set;}
        public Tag Tag {get; set;}
        //Postlike ile ilişkilendirilecek.
        public int PostLikeId {get; set;}
        public PostLike PostLike {get; set;}
        //Saved ile ilişkilendirilecek.
        public int SavedId {get; set;}
        public Saved Saved {get; set;}
        
>>>>>>> 7c22d1494c4d32f53d7ca8e373adcb54a336d9fa
    }
}
