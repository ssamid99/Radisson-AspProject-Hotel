using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Radisson.Domain.Models.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Radisson.Domain.Business.RadissonRoleModule
{
    public class RadissonRoleGetSingleQuery : IRequest<RadissonRole>
    {
        public int Id { get; set; }
        public class RadissonRoleGetSingleQueryHandler : IRequestHandler<RadissonRoleGetSingleQuery, RadissonRole>
        {
            private readonly RoleManager<RadissonRole> roleManager;

            public RadissonRoleGetSingleQueryHandler(RoleManager<RadissonRole> roleManager)
            {
                this.roleManager = roleManager;
            }
            public async Task<RadissonRole> Handle(RadissonRoleGetSingleQuery request, CancellationToken cancellationToken)
            {
                var query = await roleManager.Roles.FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);
                if(query == null)
                {
                    return null;
                }
                return query;
            }
        }
    }
}
