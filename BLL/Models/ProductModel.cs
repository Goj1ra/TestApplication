
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.Models
{
    public class ProductModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [Precision(18, 2)]
        public decimal Price { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string CategoryName { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
