using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace guestbook.Models
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        //[NotMapped]
        //[Compare("password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        //public string confirmPassword { get; set; }

        public virtual ICollection<message>? messages { get; set; }
    }
}
