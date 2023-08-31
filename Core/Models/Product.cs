using System.ComponentModel.DataAnnotations;

namespace CoreAuthentication.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public String Category { get; set; }
        public String Name { get; set; }
        public int Quantity { get; set; }
        public String Description { get; set; }
        public double Price { get; set; }
    }
}
