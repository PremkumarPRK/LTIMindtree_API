using LTIMindtree_API.Data;
using LTIMindtree_API.Models;
using LTIMindtree_API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace LTIMindtree_API.Repository.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Category> Add(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await dbContext.Categories.ToListAsync();
        }

        public Task<Category> GetById(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
