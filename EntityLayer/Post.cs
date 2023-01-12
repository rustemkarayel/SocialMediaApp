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
        public string PostContent { get; set; }
        [StringLength(300)]
        public string Description { get; set; }
        public bool IsActive { get; set; }

        //Location ile ilişkilendirilecek.
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        //Genre ile ilişkilendirilecek.
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        //User ile ilişkilendirilecek.
        public int UserId { get; set; }
        public virtual User Creator  { get; set; }

        //Comment ile ilişkilendirilecek.
        public virtual ICollection<Comment> Comments { get; set; }

        //Tag ile ilişkilendirilecek.
        public virtual ICollection<Tag> Tags { get; set; }

        //PostLike ile ilişkilendirilecek.
        public virtual ICollection<PostLike> PostLikes { get; set; }

        //Saved ile ilişkilendirilecek.
        public virtual ICollection<Saved> Saveds { get; set; }

    }
}
