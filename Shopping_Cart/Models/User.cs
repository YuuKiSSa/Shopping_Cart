using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping_Cart.Models
{
    public class User
    {
        
        [MaxLength(20)]
        [Key]
        public string UserId { get; set; }
        [MaxLength(20)]

        public string Password { get; set; }

        public virtual Record cart { get; set; }
    }
}
