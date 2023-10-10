using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping_Cart.Models
{
    public class Record
    {
        public Record()
        {
            Id = new Guid();
        }

        public Guid Id { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public double Evaluation { get; set; }

        public DateTime DateTime { get; set; }

    }
}
