﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public OrganizationEntity? Organization { get; set; }
        public int? OrganizationId { get; set; }
    }
}
