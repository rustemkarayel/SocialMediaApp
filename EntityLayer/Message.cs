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
        public DateOnly SendDate { get; set; }
        public TimeOnly SendTime { get; set; }

        //User ile ilişkilendirilecek.
        [ForeignKey ("Sender")]
        public int SenderId { get; set; }
        public User Sender { get; set; }
    }
}
