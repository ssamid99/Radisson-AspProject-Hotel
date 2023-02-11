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
    public class RadissonRolePutCommand : IRequest<RadissonRole>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class RadissonRolePutCommandHandler : IRequestHandler<RadissonRolePutCommand, RadissonRole>
        {
            private readonly RoleManager<RadissonRole> roleManager;

            public RadissonRolePutCommandHandler(RoleManager<RadissonRole> roleManager)
            {
                this.roleManager = roleManager;
            }
            public async Task<RadissonRole> Handle(RadissonRolePutCommand request, CancellationToken cancellationToken)
            {
                var data = await roleManager.Roles.FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);
                data.Name = request.Name;
                if(data == null)
                {
                    return null;
                }
                await roleManager.UpdateAsync(data);
                return data;
            }
        }
    }
}
