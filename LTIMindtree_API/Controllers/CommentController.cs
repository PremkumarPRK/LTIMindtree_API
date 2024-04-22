using LTIMindtree_API.DTOs;
using LTIMindtree_API.Models;
using LTIMindtree_API.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LTIMindtree_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Reader")]
        [Route("{id:int}")]
        public async Task<IActionResult> GetAllCommnets([FromRoute] int id)
        {
            var results = await commentRepository.GetAll(id);
            var showresults = new List<ViewCommentDto>();
            foreach (var item in results)
            {
                showresults.Add(new ViewCommentDto
                {
                    BlogpostId = item.BlogpostId,
                    CommentText = item.CommentText,
                    CreatedBy = item.CreatedBy,
                    CreatedOn = item.CreatedOn,
                });
            }
            return Ok(showresults);
        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateComment(AddCommentDto comment)
        {
            var data = new Comment
            {
                BlogpostId = comment.BlogpostId,
                CommentText = comment.CommentText,
                CreatedBy = comment.CreatedBy,
                CreatedOn = comment.CreatedOn,
            };
            var result = await commentRepository.Add(data);
            return Ok(result);
        }
    }
}
