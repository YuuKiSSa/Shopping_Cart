using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping_Cart.Models
{
    public class Product
    {
        
        [Key]
        [MaxLength(3)]
        public string Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public double Evaluation { get; set; }

        public virtual ICollection<Record> Cart { get; set; }
    }
}
