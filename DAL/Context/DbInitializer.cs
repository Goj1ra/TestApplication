
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {

            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    FirstName = "Artem",
                    LastName = "Star",
                    Email = "artem_2003@mail.ru",
                    Password = "Artem@2002",
                    UserName = "No_Mercy",
                    PasswordHash = hasher.HashPassword(null, "Artem@2002"),
                    LockoutEnabled = true
                });

            modelBuilder.Entity<Category>().HasData(
                new Category() {Id = 1, Name = "Clothes" , ParentCategoryId = 1},
                new Category() {Id = 2, Name = "Shoes" , ParentCategoryId = 1},
                new Category() {Id = 3, Name = "Hats", ParentCategoryId = 1}
                );

            modelBuilder.Entity<Product>().HasData(
                new Product() { 
                    Id = 1,
                    Name = "Jeans", 
                    Description ="New jeans from the famous brand", 
                    Price = 15, 
                    CreateDateTime = DateTime.Now, 
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    CategoryId = 1
                },
                 new Product()
                 {
                     Id = 2,
                     Name = "Boots",
                     Description = "Nike boots signed by CR7",
                     Price = 100,
                     CreateDateTime = DateTime.Now,
                     UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                     CategoryId = 2
                 },
                 new Product()
                 {
                     Id = 3,
                     Name = "Cap",
                     Description = "New Cap",
                     Price = 20,
                     CreateDateTime = DateTime.Now,
                     UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                     CategoryId = 3
                 },
                 new Product()
                 {
                     Id = 4,
                     Name = "Trousers",
                     Description = "Well worn trousers",
                     Price = 10,
                     CreateDateTime = DateTime.Now,
                     UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                     CategoryId = 1
                 });
        }

    }
}
