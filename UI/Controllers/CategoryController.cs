using BLL.Models;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UI.Controllers.Base;
using UI.Mapper;
using UI.ViewModels;

namespace UI.Controllers
{
    [Authorize]
    public class CategoryController : ApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("CreateCategory")]
        public string CreateCategory([FromBody] CategoryCreationViewModel categoryCreationViewModel)
        {
            var category = ApiMapper.Mapper.Map<CategoryModel>(categoryCreationViewModel);
            var result = _categoryService.CreateCategory(category);
            if(result != null)
            {
                return result;
            }
            return "Category int't created!";
        }

    }
}
