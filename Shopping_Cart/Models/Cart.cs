using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping_Cart.Models
{
    public class Cart
    {
        public Cart()
        {
            Id = new Guid();
            Product = new List<Product>();
        }

        public Guid Id { get; set; }

        public virtual ICollection<Product> Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
