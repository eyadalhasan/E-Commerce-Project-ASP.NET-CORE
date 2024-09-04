using Microsoft.AspNetCore.Mvc;
using SimpleProject.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SimpleProject.ViewModels
{
    public class AddProductViewModel
    {

        [Required(ErrorMessage = "The Name field is required.")]
        //[StringLength(100)]
        [Remote(action: "IsProductNameExist", controller: "Product", HttpMethod = "POST", ErrorMessage = "Name already exists.")]
        public string Name { get; set; }

        [Range(0.01, 10000, ErrorMessage = "The Price must be between 0.01 and 10000.")]
        public decimal Price { get; set; }
        [NotMapped]
        public List<IFormFile>? Files { get; set; }
        public int CategoryId { get; set; }


    }
}
