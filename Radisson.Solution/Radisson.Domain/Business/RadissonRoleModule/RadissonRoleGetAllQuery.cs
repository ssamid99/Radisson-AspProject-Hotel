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
    public class RadissonRoleGetAllQuery : IRequest<List<RadissonRole>>
    {
        public class RadissonRoleGetAllQueryHandler : IRequestHandler<RadissonRoleGetAllQuery, List<RadissonRole>>
        {
            private readonly RoleManager<RadissonRole> roleManager;

            public RadissonRoleGetAllQueryHandler(RoleManager<RadissonRole> roleManager)
            {
                this.roleManager = roleManager;
            }
            public async Task<List<RadissonRole>> Handle(RadissonRoleGetAllQuery request, CancellationToken cancellationToken)
            {
                var query = await roleManager.Roles.ToListAsync(cancellationToken);
                if(query == null)
                {
                    return null;
                }
                return query;
            }
        }
    }
}
