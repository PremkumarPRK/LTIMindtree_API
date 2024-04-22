using LTIMindtree_API.Models;

namespace LTIMindtree_API.Repository.Interface
{
    public interface IBlogpostRepository
    {
        Task<Blogpost> Add(Blogpost blogpost);
        Task<IEnumerable<Blogpost>> GetAll();
        Task<IEnumerable<Blogpost?>> GetMyAll(string username);
        Task<Blogpost> GetById(Blogpost blogpost);
    }
}
