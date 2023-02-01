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
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("CreateProduct")]
        public string ProductCreation([FromBody]ProductCreationViewModel productCreationViewModel)
        {
            var product = ApiMapper.Mapper.Map<ProductModel>(productCreationViewModel);
            var result = _productService.CreateProduct(product);
            if(result != null)
            {
                return result;
            }
            return "Bad Request!";
        }

        [HttpGet("GetProducts")]
        public ICollection<dynamic> GetProducts()
        {
            var items = _productService.GetProductsByCategory();
            return items;
        }
    }
}
