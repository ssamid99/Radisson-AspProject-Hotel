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
    public class Subscribe : BaseEntity, IPageable
    {
        public string Email { get; set; }
        public DateTime? ApproveDate { get; set; }
        public bool IsApproved { get; set; } = false;
    }
}
