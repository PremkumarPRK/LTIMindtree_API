using LTIMindtree_API.Models;

namespace LTIMindtree_API.Repository.Interface
{
    public interface ICommentRepository
    {
        Task<Comment> Add(Comment comment);
        Task<IEnumerable<Comment>> GetAll(int id);
    }
}
