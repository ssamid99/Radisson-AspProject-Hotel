using Radisson.Domain.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radisson.Domain.Models.Entities
{
    public class ServicesHeader : BaseEntity
    {
            public string Title { get; set; }
            public ServicesBody ServicesBody { get; set; }
        
    }
}
