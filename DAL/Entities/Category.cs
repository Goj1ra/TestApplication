using DAL.Entities.Base;

namespace DAL.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
    }
}
