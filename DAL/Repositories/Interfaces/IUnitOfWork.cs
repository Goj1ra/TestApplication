
using DAL.Models;

namespace DAL.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Product> Products { get; }
        IBaseRepository<Category> Categories { get; }

        void Save();
    }
}
