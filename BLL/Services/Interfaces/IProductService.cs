
using BLL.Models;

namespace BLL.Services.Interfaces
{
    public interface IProductService
    {
        ICollection<dynamic> GetProductsByCategory();
    }
}
