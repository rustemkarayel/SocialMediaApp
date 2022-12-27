using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class SavedCollection
    {
        [Key]
        public int SavedCollectionId { get; set; }

        //Saved ile ilişkilendirilecek.
        public int SavedId { get; set; }
        public Saved Saved { get; set; }

        //Collection ile ilişkilendirilecek.
        public int CollectionId { get; set; }
        public Collections Collection { get; set; }



    }
}
