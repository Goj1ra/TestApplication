
using BLL.Models;

namespace BLL.Services.Interfaces
{
    public interface IProductService
    {
        string CreateProduct(ProductModel productModel);
        ICollection<dynamic> GetProductsByCategory();
    }
}
