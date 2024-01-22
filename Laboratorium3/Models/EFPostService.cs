
using Data.Entities;
using Data;
using Laboratorium3.Mappers;
using Microsoft.Extensions.Hosting;

namespace Laboratorium3.Models
{
    public class EFPostService : IPostService
    {
        private AppDbContext _context;

        public EFPostService(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Post post)
        {
            var entity = _context.Posts.Add(PostMapper.ToEntity(post));
            _context.SaveChanges();
            return entity.Entity.Id;
        }

        public void Delete(int id)
        {
            PostEntity? find = _context.Posts.Find(id);
            if (find != null)
            {
                _context.Posts.Remove(find);
                _context.SaveChanges(); 
            }
        }

        // co to kurwa jest
        public void DeleteById(int id)
        {
            PostEntity entity = _context.Posts.Find(id);
            if (entity != null)
            {
                _context.Posts.Remove(entity);
                _context.SaveChanges();
            }
        }
        public void Update(Post post)
        {
            _context.Posts.Update(PostMapper.ToEntity(post));
            _context.SaveChanges();

        }
        public List<Post> FindAll()
        {
            return _context.Posts.Select(e => PostMapper.FromEntity(e)).ToList();
        }

        public Post FindById(int id)
        {
            return PostMapper.FromEntity(_context.Posts.Find(id));
        }

       
        public List<OrganizationEntity> FindAllOrganizations()
        {
            return _context.Organizations.ToList();//nie wiem czy tu
        }

        public List<OrganizationEntity> FindAllOrganizationsForVieModel()
        {
            throw new NotImplementedException();
        }

        public PagingList<Post> FindPage(int page, int size)
        {
            return PagingList<Post>.Create(
                (p, s) => _context.Posts
                .OrderBy(c => c.Content)
                .Skip((p-1) *s)
                .Take(s)
                .Select(PostMapper.FromEntity)
                .ToList()
                ,
                page,
                size,
                _context.Posts.Count()
                );
        }

    }


}
