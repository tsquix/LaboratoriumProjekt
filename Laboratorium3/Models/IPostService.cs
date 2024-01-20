using Laboratorium3.Models;
namespace Laboratorium3.Models
{
    public interface IPostService
    {
        int Add(Post item);
        void Delete(int id);
        void Update(Post item);
        List<Post> FindAll();
        Post? FindById(int id);
    }
}

