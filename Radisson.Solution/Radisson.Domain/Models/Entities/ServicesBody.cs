using Radisson.Application.AppCode.Infrastructure;
using Radisson.Domain.AppCode.Infrastructure;

namespace Radisson.Domain.Models.Entities
{
    public class ServicesBody : BaseEntity, IPageable
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImagePath { get; set; }
        public int ServicesHeaderId { get; set; }
        public ServicesHeader ServicesHeader { get; set; }
    }
}
