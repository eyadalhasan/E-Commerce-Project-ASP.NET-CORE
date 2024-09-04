using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleProject.Models
{
    public class ProductImages
    {
        [Key]
        public int Id { get; set; }
        public string? Path { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        public Product? Product { get; set; }


    }
}
