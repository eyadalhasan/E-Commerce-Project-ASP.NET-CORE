using Microsoft.AspNetCore.Mvc;
using SimpleProject.Models;

namespace SimpleProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //ViewBag.Name = "Eyad";
            //ViewData["title"] = "ee";
            Product product1 = new Product() { Id = 1, Name = "Mohamad" };
            Product product2 = new Product() { Id = 2, Name = "Ahmad" };
            List<Product> products = new List<Product>();
            products.Add(product1);
            products.Add(product2);

            return View(products);
        }
        //public IActionResult Details([FromQuery]string name, [FromQuery]decimal price)
        //{
        //    return View();
        //}
        //public IActionResult Details([FromQuery] Product product)
        //{

        //    return View(product);
        //}

        //fromRoute (url)
        //from query from querystring
        //from form (from form)

        //from header [Fromheader(Name="numberof") int number)
        //[HttpGet("{controller}/details/{number}")]

        public IActionResult Details([FromRoute] int number)
        {
            return View();
        }



    }
}

