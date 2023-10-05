using System.ComponentModel.DataAnnotations;

namespace Shopping_Cart.Models
{
    public class Product
    {
        public Product() 
        {
            Id = new Guid();
        }

        public Guid Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public byte Image { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
