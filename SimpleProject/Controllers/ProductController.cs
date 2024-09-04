using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;
using SimpleProject.Models.Services.Implementations;
using SimpleProject.Models.Services.Interfaces;
using SimpleProject.Models;
using System.Runtime.InteropServices;
using System.Threading.Tasks.Dataflow;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleProject.ViewModels;
using AutoMapper;

namespace SimpleProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productservice;

        private readonly IFileService _fileService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;






        public ProductController(IProductService productservice, IFileService fileService, ICategoryService categoryService, IMapper mapper)
        {
            _productservice = productservice;
            _fileService = fileService;
            _categoryService = categoryService;
            _mapper = mapper;



            //_productservice.AddProduct(new Models.Product() { Id = 3, Name = "Tahina" });
        }
        //[Route("category/index")]// Attribute routing  
        public async Task<IActionResult> Index()
        {

            var products = await _productservice.GetProducts();
            ViewBag.Count = products.Count;
            return View(products);

            //return ControllerContext.MyDisplayRouteInfo();// I have to download rick.samples.routeInfo

        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            ViewData["categories"] = new SelectList(await _categoryService.GetCategoriesAsync(), "Id", "Name");


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddProductViewModel model)
        {
            try

            {
                if (ModelState.IsValid)
                {

                    //Product product = new Product() { Name = model.Name, Price = model.Price, CategoryID = model.CategoryId };
                    Product product = _mapper.Map<Product>(model);





                    var result = await _productservice.AddProduct(product, model.Files);
                    if (result != "success")
                    {
                        ModelState.AddModelError(string.Empty, result);
                        ViewData["categories"] = new SelectList(await _categoryService.GetCategoriesAsync(), "Id", "Name");

                        return View(model);
                    }



                    //return RedirectToAction("Index");
                    return RedirectToAction(nameof(Index));
                    //return View("index");// but no produts as index so error inside html file
                }
                else
                {
                    ViewData["categories"] = new SelectList(await _categoryService.GetCategoriesAsync(), "Id", "Name");

                    return View(model);// stay them fulled
                    //return RedirectToAction() Will reset the fields
                }

            }
            catch (Exception ex)
            {
                {
                    return Ok(ex);

                }
            }

        }

        [HttpGet("{controller}/details/{id}")]

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productservice.GetProductById(id);
            return View(product);




        }

        [HttpGet]

        public async Task<IActionResult> Update(int id)
        {
            var product = await _productservice.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return View(product);

            }

        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, [Bind("Id,Name,Price,File")] Product model)
        {


            var product = await _productservice.GetProductById(id);
            try
            {
                if (id == model.Id)
                {

                    //var path = await _fileService.UploadFile(model?.File, "/images");
                    //model.Path = path;
                    await _productservice.UpdateProduct(model);

                    var products = await _productservice.GetProducts();
                    return RedirectToAction(nameof(Index));



                }




                else
                {
                    return NotFound();
                }


            }
            catch
            {
                return View();
            }


        }
        [HttpGet]

        public async Task<IActionResult> IsProductNameExist(string name)
        {

            bool isExist = await _productservice.IsProductNameExist(name);
            return Json(!isExist);

        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var prodcut = await _productservice.GetProductById(id);
            if (prodcut == null)
            {
                return NotFound();
            }
            return View(prodcut);




        }
        [HttpPost, ActionName("delete")]
        public async Task<IActionResult> Deleteconfirm(int id)
        {
            try
            {
                var product = await _productservice.GetProductById(id);
                if (product == null)
                {
                    return NotFound();
                }
                _productservice.DeleteProduct(product);
                return RedirectToAction(nameof(Index));


            }
            catch
            {
                return NotFound();
            }

        }




    }
}
