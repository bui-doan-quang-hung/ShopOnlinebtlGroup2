using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopOnlineAdmin.Web.Models;

namespace ShopOnlineAdmin.Web.Controllers
{
    public class ProductController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:44323/api");
        private readonly HttpClient _httpClient;
        public ProductController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Product> productList = new List<Product>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/product/Get").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                productList = JsonConvert.DeserializeObject<List<Product>>(data);
            }
            return View(productList);
        }
    }
}
