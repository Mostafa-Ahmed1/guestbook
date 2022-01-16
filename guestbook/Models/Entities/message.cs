using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace guestbook.Models
{
    public class message
    {
        public int id { get; set; }
        public string msg { get; set; }
        public DateTime time { get; set; }
        
        public int? chatId { get; set; }
        public virtual message chat { get; set; }

        public int userId { get; set; }
        public virtual User User { get; set; }
    }
}
