using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        [StringLength(100)]
        public string Content { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime SendTime { get; set; }
        public bool IsActive { get; set; }

        //User ile ilişkilendirilecek.
        [ForeignKey ("Sender")]
        public int? SenderId { get; set; }
        public virtual User Sender { get; set; }

        [ForeignKey("Receiver")]
        public int? ReceiverId { get; set; }
        public virtual User Receiver { get; set; }
    }
}
