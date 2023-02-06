using Radisson.Domain.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radisson.Domain.Models.Entities
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public string Surame { get; set; }
        public string Text { get; set; }
        public string ImagePath { get; set; }
    }
}
