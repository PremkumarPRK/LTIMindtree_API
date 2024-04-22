using LTIMindtree_API.Data;
using LTIMindtree_API.Models;
using LTIMindtree_API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace LTIMindtree_API.Repository.Implementation
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CommentRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Comment> Add(Comment comment)
        {
            await dbContext.Comments.AddAsync(comment);
            await dbContext.SaveChangesAsync();
            return comment;
        }

        public async Task<IEnumerable<Comment>> GetAll(int id)
        {
            return await dbContext.Comments.Where(x => x.BlogpostId == id).ToListAsync();
        }
    }
}
