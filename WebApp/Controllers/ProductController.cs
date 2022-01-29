using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        HttpClient _client;
        IConfiguration _configuration;
        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
            Uri baseAddress = new Uri(_configuration["ApiAddress"]);
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        public IActionResult Index()
        {
            IEnumerable<ProductModel> model = new List<ProductModel>();
            var response = _client.GetAsync(_client.BaseAddress + "/product").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                model = JsonSerializer.Deserialize<IEnumerable<ProductModel>>(data);
            }
            return View(model);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = GetCategories();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductModel model)
        {
            string data = JsonSerializer.Serialize(model);
            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            var response = _client.PostAsync(_client.BaseAddress + "/product", stringContent).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Categories = GetCategories();
            return View();
        }

        private IEnumerable<CategoryModel> GetCategories()
        {
            IEnumerable<CategoryModel> model = new List<CategoryModel>();
            var response = _client.GetAsync(_client.BaseAddress + "/category").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                model = JsonSerializer.Deserialize<IEnumerable<CategoryModel>>(data);
            }
            return model;
        }
    }
}
