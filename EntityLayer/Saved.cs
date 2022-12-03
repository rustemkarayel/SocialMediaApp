using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Saved
    {
        [Key]
        public int SavedId { get; set; }

        //User ile ilişkilendirilecek.
        public int UserId { get; set; }
        public User user { get; set; }

        //Post ile ilişkilendirilecek.
        public int PostId { get; set; }
        public Post post { get; set; }

        //SavedCollection ile ilişkilendirilecek.
        public ICollection<SavedCollection> SavedCollections { get; set; }


    }
}
