using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Saved : BaseEntity
	{
        [Key]
        public int SavedId { get; set; }
        public bool IsActive { get; set; }

        //User ile ilişkilendirilecek.
        public int UserId { get; set; }
        public virtual User User { get; set; }

        //Post ile ilişkilendirilecek.
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        //SavedCollection ile ilişkilendirilecek.
        public virtual ICollection<SavedCollection> SavedCollections { get; set; }


    }
}
