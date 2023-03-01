using ERPGL.Models;
using ERPGL.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace ERPGL.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController
    {

        private readonly IProductRepository repository;

        public ProductController(IProductRepository product)
        {
            this.repository = product;
        }

        [HttpPost]
        [Route("create")]
        public bool createProduct([FromBody] Product product)
        {
            try
            {
                repository.createProduct(product);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("update")]
        public bool updateProduct([FromBody] Product product)
        {
            try
            {
                repository.updateProduct(product);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [Route("delete/{code}")]
        public bool deleteProduct([FromRoute]string code)
        {
            try
            {
                repository.deleteProduct(code);
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("getSingleProduct/{code}")]
        public Product getSingleProductByCode([FromRoute] string code)
        {
            try
            {
                var product = repository.getSingleProductByCode(code);
                return product;
            }
            catch(NullReferenceException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("listAll")]
        public IEnumerable<Product> getListProducts()
        {
            try
            {
                var products = repository.getListProducts();
                return products;
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
