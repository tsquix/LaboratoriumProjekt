using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("posts")]
    public class PostEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Content { get; set; }

        [Required]
        [MaxLength(50)]
        public string Author { get; set; }

        public DateTime PublicationDate { get; set; }

        [MaxLength(30)]
        public string Tags { get; set; }

        [MaxLength(100)]
        public string Comment { get; set; }

        public int? OrganizationId { get; set; }
        public OrganizationEntity? Organization { get; set; }
    }
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ISet<Content> Contents { get; set; }
    }
    public class Content
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ISet<Author> Authors { get; set; }
    }
    public class AuthorContent
    {
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int ContentId { get; set; }
        public Content Contents { get; set; }
    }
}
