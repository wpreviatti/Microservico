using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MicrosWPSShopping.Web.Models;
using MicrosWPSShopping.Web.Services.IServices;
using MicrosWPSShopping.Web.Utils;

namespace MicrosWPSShopping.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService iproductService)
        {
            _productService = iproductService ?? throw new ArgumentNullException(nameof(iproductService));
        }
        [Authorize]
        public async Task<IActionResult> ProductIndex()
        {
            var products = await _productService.FindAllProducts();
            return View(products);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.Create(model);
                if (response != null) return RedirectToAction(nameof(ProductIndex));
            }
            return View(model);
        }
        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.Update(model);
                if (response != null) return RedirectToAction(nameof(ProductIndex));
            }
            return View(model);
        }
        public async Task<IActionResult> ProductUpdate(int id)
        {

            var products = await _productService.GetProductById(id);
            if(products != null)
            return View(products);
            else NotFound(id);
            return View(products);
        }
        [Authorize]
        public async Task<IActionResult> ProductDelete(int id)
        {

            var data = await _productService.GetProductById(id);
            if (data != null)
                return View(data);
            else NotFound(id);
            return View(data);
        }
        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> ProductDelete(ProductModel model)
        {
            var sucesso = await _productService.DeleteById(model.Id);
            if (sucesso) return RedirectToAction(nameof(ProductIndex));
            return View(model);
        }
    }
}
