using Azure.Core;
using LTIMindtree_API.Data;
using LTIMindtree_API.DTOs;
using LTIMindtree_API.Models;
using LTIMindtree_API.Repository.Implementation;
using LTIMindtree_API.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LTIMindtree_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogpostController : ControllerBase
    {
        private readonly IBlogpostRepository blogpostRepository;
        private readonly ICategoryRepository categoryRepository;

        public BlogpostController(IBlogpostRepository blogpostRepository, ICategoryRepository categoryRepository)
        {
            this.blogpostRepository = blogpostRepository;
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<ActionResult> GetAllBlogposts()
        {
            var blogsposts = await blogpostRepository.GetAll();
            var result = new List<ViewBlogpostDto>();
            foreach (var item in blogsposts)
            {
                result.Add(new ViewBlogpostDto
                {
                    Title = item.Title,
                    ShortDescription = item.ShortDescription,
                    Content = item.Content,
                    Imageurl = item.Imageurl,
                    UrlHandle = item.UrlHandle,
                    Author = item.Author,
                    PublishedDate = item.PublishedDate,
                    IsVisible = item.IsVisible,
                    Categories = item.Categories.Select(x => new ViewCategoryDto
                    {
                        CategoryId = x.CategoryId,
                        CategoryName = x.CategoryName,
                        UrlHnadle = x.UrlHnadle,
                    }).ToList(),
                });
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("ViewMyBlogposts")]
        [Authorize(Roles = "Reader")]
        public async Task<ActionResult> GetAllMyBlogposts([FromQuery] string username)
        {
            var blogsposts = await blogpostRepository.GetMyAll(username);
            if(blogsposts == null)
            {
                return NotFound();
            }
            var result = new List<ViewBlogpostDto>();
            foreach (var item in blogsposts)
            {
                result.Add(new ViewBlogpostDto
                {
                    Title = item.Title,
                    ShortDescription = item.ShortDescription,
                    Content = item.Content,
                    Imageurl = item.Imageurl,
                    UrlHandle = item.UrlHandle,
                    Author = item.Author,
                    PublishedDate = item.PublishedDate,
                    IsVisible = item.IsVisible,
                    Categories = item.Categories.Select(x => new ViewCategoryDto
                    {
                        CategoryId = x.CategoryId,
                        CategoryName = x.CategoryName,
                        UrlHnadle = x.UrlHnadle,
                    }).ToList(),
                });
            }
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateBlogpost(AddBlogpostDto blogpost)
        {
            var data = new Blogpost 
            {
                Title = blogpost.Title,
                ShortDescription = blogpost.ShortDescription,
                Content = blogpost.Content,
                Imageurl = blogpost.Imageurl,
                UrlHandle = blogpost.UrlHandle,
                Author = blogpost.Author,
                PublishedDate = blogpost.PublishedDate,
                IsVisible = blogpost.IsVisible,
                Categories = new List<Category>()
            };

            foreach (var item in blogpost.Categories)
            {
                var existingCategory = await categoryRepository.GetById(item);
                if (existingCategory is not null)
                {
                    data.Categories.Add(existingCategory);
                }
            }
            var result = await blogpostRepository.Add(data);

            return Ok(result);
        }
    }
}
