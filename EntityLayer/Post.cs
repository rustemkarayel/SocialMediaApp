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

        
        //Location ile ilişkilendirilecek.
        public int LocationId { get; set; }
        public Location Location { get; set; }

        //Genre ile ilişkilendirilecek.
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

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

    }
}
