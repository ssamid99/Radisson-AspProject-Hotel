using Radisson.Application.AppCode.Infrastructure;
using Radisson.Domain.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radisson.Domain.Models.Entities
{
    public class BlogPost : BaseEntity, IPageable
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public string ImagePath { get; set; }
        [Required]
        public string Slug { get; set; }
        public DateTime? PublishedDate { get; set; }
        public virtual ICollection<BlogPostComment> Comments { get; set; }
    }
}
