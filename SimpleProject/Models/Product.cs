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
    //[DatabaseGenerated(DatabaseGeneratedOption
    //    .Identity)]
    public int Id { get; set; }

    public string Name { get; set; }


    public decimal Price { get; set; }

    [ForeignKey("Category")] //or nameof(Category) 
    public int CategoryID { get; set; }
    public Category? Category { get; set; }

    public ICollection<ProductImages> ProductImages { get; set; } = new HashSet<ProductImages>();



    // 1 category==>M product








}
