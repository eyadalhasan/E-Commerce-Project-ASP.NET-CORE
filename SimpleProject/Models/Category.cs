using System.ComponentModel.DataAnnotations;

namespace SimpleProject.Models
{
    public class Category
    {
        public string Name { get; set; }
        [Key]
        public int Id { get; set; }


        public ICollection<Product> Products { get; set; } = new HashSet<Product>();

    }
}
