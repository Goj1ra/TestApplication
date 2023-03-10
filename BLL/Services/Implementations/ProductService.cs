
using AutoMapper;
using BLL.Mapper;
using BLL.Models;
using BLL.Services.Interfaces;
using DAL.Context;
using DAL.Models;
using DAL.Repositories.Interfaces;

namespace BLL.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly AppDbContext _appDbContext;

        public ProductService(IUnitOfWork unitOfWork, AppDbContext context)
        {
            _appDbContext = context;
            _unitofWork = unitOfWork;
        }
        public ICollection<dynamic> GetProductsByCategory()
        {
            using (var context = _appDbContext)
            {
                var productsWithCategory = context.Products
                    .Join(
                        context.Categories,
                        x => x.CategoryId,
                        u => u.Id,
                        (u, x) => new
                        {
                            Name = u.Name,
                            Category = x.Name,
                            Price = u.Price
                        }
                    );
                var products = new List<dynamic>();
                products.AddRange(productsWithCategory.ToList());
                return products;
            }
        }
    }
}
