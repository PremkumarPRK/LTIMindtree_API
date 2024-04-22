using LTIMindtree_API.Models;
using Microsoft.EntityFrameworkCore;

namespace LTIMindtree_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Blogpost> Blogposts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
