using LTIMindtree_API.Models;

namespace LTIMindtree_API.Repository.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> Add(Category category);
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(Category category);
    }
}
