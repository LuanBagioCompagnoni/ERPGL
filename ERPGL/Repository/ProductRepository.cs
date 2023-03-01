using ERPGL.Context;
using ERPGL.Models;
using ERPGL.Repository.IRepository;

namespace ERPGL.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext context;
        public ProductRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public bool createProduct(Product product) 
        {
            try
            {
                Console.WriteLine($"Creating product {product.code}!");
                context.Product.Add(product);
                context.SaveChanges();
                Console.WriteLine($"Product {product.code} create sucessfuly!");
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error during create product {product.code} in database, error returned: {ex.Message}");
                throw new Exception($"Error during create product {product.code} in database, error returned: {ex.Message}");
            }
        }

        public bool updateProduct(Product product)
        {
            try
            {
                Console.WriteLine($"Updating product {product.code}!");
                context.Update(product);
                context.SaveChanges();
                Console.WriteLine($"Product {product.code} update sucessfuly!");
                return true;
            }
            catch(Exception ex) 
            {
                Console.WriteLine($"Error during update product {product.code} in database, error returned: {ex.Message}");
                throw new Exception($"Error during update product {product.code} in database, error returned: {ex.Message}");
            }
        }

        public bool deleteProduct(string code)
        {
            try
            {
                Console.WriteLine($"Deleting product {code}!");
                var product = getSingleProductByCode(code);
                context.Remove(product);
                context.SaveChanges();
                Console.WriteLine($"Product {code} deleted sucessfuly!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during delete product {code} in database, error returned: {ex.Message}");
                throw new Exception($"Error during delete product {code} in database, error returned: {ex.Message}");
            }
        }

        public Product getSingleProductByCode(string code)
        {
            try
            {
                Console.WriteLine($"Getting product {code}!");
                var product = context.Product.FirstOrDefault(x=>x.code == code);
                Console.WriteLine($"Product {code} getting sucessfuly!");
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during getting product {code} in database, error returned: {ex.Message}");
                throw new Exception($"Error during getting product {code} in database, error returned: {ex.Message}");
            }
        }

        public IEnumerable<Product> getListProducts()
        {
            try
            {
                Console.WriteLine($"Getting all products!");
                var product = context.Product.OrderBy(x=>x.id);
                if (product == null)
                    throw new NullReferenceException("No products are found");
                Console.WriteLine($"Getting all products sucessfuly!");
                return product;
            }
            catch(NullReferenceException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during getting all product in database, error returned: {ex.Message}");
                throw new Exception($"Error during getting all product in database, error returned: {ex.Message}");
            }
        }
    }
}
