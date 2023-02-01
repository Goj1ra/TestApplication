
namespace BLL.Models
{
    public class CategoryModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? ParentCategoryId { get; set; }
        public CategoryModel ParentCategory { get; set; }
    }
}
