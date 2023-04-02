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
    public class RadissonRoleRemoveCommand : IRequest<RadissonRole>
    {
        public int Id { get; set; }
        public class RadissonRoleRemoveCommandHandler : IRequestHandler<RadissonRoleRemoveCommand, RadissonRole>
        {
            private readonly RoleManager<RadissonRole> roleManager;

            public RadissonRoleRemoveCommandHandler(RoleManager<RadissonRole> roleManager)
            {
                this.roleManager = roleManager;
            }
            public async Task<RadissonRole> Handle(RadissonRoleRemoveCommand request, CancellationToken cancellationToken)
            {
                var data = await roleManager.Roles.FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);
                if(data == null)
                {
                    return null;
                }
                await roleManager.DeleteAsync(data);
                return data;
            }
        }
    }
}
