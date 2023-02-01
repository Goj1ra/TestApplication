using DAL.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
    public class Product : Entity
    {
       public string Name { get; set; }
       public string Description { get; set; }

       [Precision(18, 2)]
       public decimal Price { get; set; }
       public DateTime CreateDateTime { get; set; }
       public int? CategoryId { get; set; }
       public Category Category { get; set; }
       public string UserId { get; set; }
       public User User { get; set; }
    
        
    }
}
