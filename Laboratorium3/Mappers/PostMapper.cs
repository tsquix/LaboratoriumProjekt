using Data.Entities;

using Laboratorium3.Models;

namespace Laboratorium3.Mappers
{
    public class PostMapper
    {
        public static Post FromEntity(PostEntity entity)
        {
            return new Post()
            {
                Id = entity.Id,
                Content = entity.Content,
                Author = entity.Author,
                Tags = (Tags)Enum.Parse(typeof(Tags), entity.Tags), 
                PublicationDate = entity.PublicationDate,
                Comment = entity.Comment,
            };
        }

        public static PostEntity ToEntity(Post model)
        {
            return new PostEntity()
            {
                Id = model.Id,
                Content = model.Content,
                Author = model.Author,
                Tags = model.Tags.ToString(), 
                PublicationDate = model.PublicationDate,
                Comment = model.Comment,
            };
        }
    }
}