using ERPGL.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;

namespace WebERPGL.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient client;
        private readonly string host = "https://localhost:7000/";
        public ProductController(HttpClient client) 
        { 
            this.client = client;
        }
        public async Task<bool> Create(Product product)
        {
            try
            {
                using var response = await client.PostAsync($"{host}Product/create", new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json"));
                var responseContent = await response.Content.ReadAsStringAsync();
                if(responseContent != null)
                {
                    if (responseContent.Equals("true"))
                        return true;
                    else 
                        return false;
                }
                else
                {
                    throw new NullReferenceException("Received content null!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while request of create product: {ex.Message}");
            }
        }

        public async Task<bool> Update(Product product)
        {
            try
            {
                var response = await client.PutAsync($"{host}Product/update", new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF32, "application/json"));
                var responseContent = await response.Content.ReadAsStringAsync();
                if (responseContent != null)
                {
                    if (responseContent.Equals("true"))
                        return true;
                    else
                        return false;
                }
                else
                {
                    throw new NullReferenceException("Received content null!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while request of update product: {ex.Message}");
            }
        }
        public async Task<bool> Delete(string code)
        {
            try
            {
                var response = await client.DeleteAsync($"{host}Product/delete/{code}");
                var responseContent = await response.Content.ReadAsStringAsync();
                if (responseContent != null)
                {
                    if (responseContent.Equals("true"))
                        return true;
                    else
                        return false;
                }
                else
                {
                    throw new NullReferenceException("Received content null!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while request of delete product: {ex.Message}");
            }
        }
        public async Task<Product> GetSingle(string code)
        {
            try
            {
                var response = await client.GetAsync($"{host}Product/getSingleProduct/{code}");
                var responseContent = await response.Content.ReadAsStringAsync();
                if (responseContent != null)
                {
                    var product = JsonConvert.DeserializeObject<Product>(responseContent);
                    return product;
                }
                else
                {
                    throw new NullReferenceException("Received content null!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while request of get single product: {ex.Message}");
            }
        }
        public async Task<IEnumerable<Product>> ListProducts()
        {
            try
            {
                var response = await client.GetAsync($"{host}Product/listAll/");
                var responseContent = await response.Content.ReadAsStringAsync();
                if (responseContent != null)
                {
                    var product = JsonConvert.DeserializeObject<List<Product>>(responseContent);
                    return product;
                }
                else
                {
                    throw new NullReferenceException("Received content null!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while request of get single product: {ex.Message}");
            }
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Product = await ListProducts();
            return View();
        }

        public async Task<IActionResult> CreateProduct(Product product)
        {
            if (await Create(product))
            {
                return RedirectToAction("Index", "Product");
            }
            return View();
        }

        public async Task<IActionResult> UpdateProduct(Product product)
        {
            if (await Update(product))
            {
                return RedirectToAction("Index", "Product");
            }
            return View();
        }
    }
}
