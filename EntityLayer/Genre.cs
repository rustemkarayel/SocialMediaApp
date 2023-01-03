using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        [StringLength(25)]
        public string GenreName { get; set; }

        //Post ile ilişkilendirilecek.
        public virtual ICollection<Post> Posts { get; set; }
    }
}
