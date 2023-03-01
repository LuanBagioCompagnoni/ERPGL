using ERPGL.Models;

namespace ERPGL.Repository.IRepository
{
    public interface IProductRepository
    {

        bool createProduct(Product product);
        bool updateProduct(Product product);
        bool deleteProduct(string code);
        Product getSingleProductByCode(string code);
        IEnumerable<Product> getListProducts();

    }
}
