using System.Threading.Tasks;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _product;

        public ProductsController(IProductService category)
        {
            _product = category;
        }


        public async Task<IActionResult> Index()
        {
            var result = await _product.GetProductsAsync();
            return View(result);
        }
    }
}