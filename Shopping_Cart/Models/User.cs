using System.ComponentModel.DataAnnotations;

namespace Shopping_Cart.Models
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        [MaxLength(20)]
        [Required]
        public string UserId { get; set; }
        [MaxLength(20)]
        [Required]
        public string Password { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
