using Radisson.Domain.Models.Entities;
using System.Collections.Generic;

namespace Radisson.Domain.Models.ViewModels
{
    public class ServiceHeaderBodyModel
    {
        public ICollection<ServicesHeader> ServicesHeaders { get; set; }
        public ICollection<ServicesBody> ServicesBodies { get; set; }
    }
}
