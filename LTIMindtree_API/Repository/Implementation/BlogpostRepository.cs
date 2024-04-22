using LTIMindtree_API.Data;
using LTIMindtree_API.Models;
using LTIMindtree_API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace LTIMindtree_API.Repository.Implementation
{
    public class BlogpostRepository : IBlogpostRepository
    {
        private readonly ApplicationDbContext dbContext;

        public BlogpostRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Blogpost> Add(Blogpost blogpost)
        {
            await dbContext.AddAsync(blogpost);
            await dbContext.SaveChangesAsync();
            return blogpost;
        }

        public async Task<IEnumerable<Blogpost>> GetAll()
        {
            var blogposts = await dbContext.Blogposts.Include(x => x.Categories).ToListAsync();
            return blogposts;
        }

        public async Task<IEnumerable<Blogpost?>> GetMyAll(string username)
        {
            var blogposts = await dbContext.Blogposts.Include(x => x.Categories).Where(x => x.CreatedBy == username).ToListAsync();
            if (blogposts == null) 
            {
                return null;
            }
            return blogposts;
        }

        public Task<Blogpost> GetById(Blogpost blogpost)
        {
            throw new NotImplementedException();
        }
    }
}
