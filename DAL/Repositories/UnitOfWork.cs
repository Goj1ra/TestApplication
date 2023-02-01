
using DAL.Context;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Interfaces
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        private IBaseRepository<Product> products;
        private IBaseRepository<Category> categories;

        public UnitOfWork(DbContextOptions options)
        {
            _dbContext = new AppDbContext(options);
        }

        public IBaseRepository<Product> Products
        {
            get
            {
                if(this.products == null)
                {
                    this.products = new BaseRepository<Product>(_dbContext);
                }
                return products;
            }
        }

        public IBaseRepository<Category> Categories
        {
            get
            {
                if(this.categories == null)
                {
                    this.categories = new BaseRepository<Category>(_dbContext);
                }
                return categories;
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
