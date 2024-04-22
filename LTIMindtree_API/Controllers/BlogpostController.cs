using LTIMindtree_API.Data;
using LTIMindtree_API.Models;
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

        public BlogpostController(IBlogpostRepository blogpostRepository)
        {
            this.blogpostRepository = blogpostRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<ActionResult> GetAllBlogposts()
        {
            var blogsposts = await blogpostRepository.GetAll();
            return Ok(blogsposts);
        }

        [HttpGet]
        [Route("ViewMyBlogposts")]
        [Authorize(Roles = "Reader")]
        public async Task<ActionResult> GetAllMyBlogposts(string username)
        {
            var blogsposts = await blogpostRepository.GetMyAll(username);
            return Ok(blogsposts);
        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateBlogpost(Blogpost blogpost)
        {
            var result = await blogpostRepository.Add(blogpost);
            return Ok(result);
        }
    }
}
