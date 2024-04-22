using LTIMindtree_API.DTOs;
using LTIMindtree_API.Models;
using LTIMindtree_API.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LTIMindtree_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categoreis = await categoryRepository.GetAll();
            var result = new List<ViewCategoryDto>();
            foreach (var item in categoreis)
            {
                 result.Add(new ViewCategoryDto { 
                     CategoryId =  item.CategoryId,
                     CategoryName = item.CategoryName,
                     UrlHnadle = item.UrlHnadle
                 });   
            }
            return Ok(categoreis);
        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateCategory([FromBody] AddCategoryDto category)
        {
            var data = new Category
            {
                CategoryName = category.CategoryName,
                UrlHnadle = category.UrlHnadle,
                CreatedBy = category.CreatedBy,
                CreatedOn = category.CreatedOn,
            };
            var result = await categoryRepository.Add(data);
            var showresult = new ViewCategoryDto
            {
                CategoryId = result.CategoryId,
                CategoryName = result.CategoryName,
                UrlHnadle = result.UrlHnadle,
                CreatedBy = result.CreatedBy,
                CreatedOn = result.CreatedOn
            };
            return Ok(showresult);
        }
    }
}
