using AutoMapper;
using BLL.Mapper;
using BLL.Models;
using BLL.Services.Interfaces;
using DAL.Models;
using DAL.Repositories.Interfaces;

namespace BLL.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public string CreateCategory(CategoryModel categoryModel)
        {
            var category = ApplicationMapper.Mapper.Map<Category>(categoryModel);
            _unitOfWork.Categories.Save(category);
            _unitOfWork.Save();
            return "Category is created";
        }
    }
}
