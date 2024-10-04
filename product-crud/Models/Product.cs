using System.ComponentModel.DataAnnotations;

namespace product_crud.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }


        [Required]

        public decimal Price { get; set; }
    }
}
