namespace Laboratorium3.Models
{
    public class MemoryPostService :IPostService
    {
        private Dictionary<int, Post> _posts = new Dictionary<int, Post>()
        {
            {1, new Post() { Id = 1, Content = "Wojna", Author = "siergiej96", Tags = Tags.Tag1, Comment = "Wojna na ukrainie jest zła.", PublicationDate = DateTime.Now } }
        };
        private int id = 2;

        private readonly IDateTimeProvider _timeProvider;

        public MemoryPostService(IDateTimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }


        public int Add(Post model)
        {
            // model.Created = _timeProvider.GetDateTime();
            int id = _posts.Keys.Count != 0 ? _posts.Keys.Max() : 0;
            model.Id = id++;
            _posts[model.Id] = model;
            return model.Id;
        }

        public void DeleteById(int id)
        {
            _posts.Remove(id);
        }

        public List<Post> FindAll()
        {
            return _posts.Values.ToList();
        }

        public Post? FindById(int id)
        {
            return _posts[id];
        }

        public void Update(Post post)
        {
            if (_posts.ContainsKey(post.Id))
            {
                _posts[post.Id] = post;
            }
        }

        public void Delete(int id)
        {
            if (_posts.ContainsKey(id))
            {
                _posts.Remove(id);
            }
        }

    }
}
