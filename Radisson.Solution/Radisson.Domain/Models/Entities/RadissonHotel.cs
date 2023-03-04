using Radisson.Domain.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radisson.Domain.Models.Entities
{
    public class RadissonHotel : BaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string FullText { get; set; }
        public string ImagePath { get; set; }
    }
}
