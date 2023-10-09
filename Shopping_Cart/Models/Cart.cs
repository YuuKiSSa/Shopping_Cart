using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping_Cart.Models
{
    public class Cart
    {
        public Cart()
        {
            Id = new Guid();
        }

        public Guid Id { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

    }
}
