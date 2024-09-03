using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SimpleProject.Models;
using System.ComponentModel.DataAnnotations;

//namespace SimpleProject.Models
//{
//    public class Product
//    {
//        public int Id { get; set; }
//        //[BindProperty(Name = "proname")]
//        //Bindnever
//        [Required]
//        public string Name { get; set; }


//        //[BindProperty(Name = "prodprice")]
//        //[Required]
//        [Range(1, double.MaxValue, ErrorMessage = "Min value is 1 and max 3")]
//        public int Price { get; set; }
//    }
//}


using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The Name field is required.")]
    //[StringLength(100)]
    [Remote(action: "IsProductNameExist", controller: "Product", HttpMethod = "POST", ErrorMessage = "Name already exists.")]
    public string Name { get; set; }

    [Range(0.01, 10000, ErrorMessage = "The Price must be between 0.01 and 10000.")]
    public decimal Price { get; set; }

    [NotMapped]
    public IFormFile? File { get; set; }
    public string? Path { get; set; }
    [ForeignKey("Category")] //or nameof(Category) 
    public int CategoryID { get; set; }
    public Category ?Category { get; set; }








}
