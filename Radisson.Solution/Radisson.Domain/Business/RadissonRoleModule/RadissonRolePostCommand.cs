using MediatR;
using Microsoft.AspNetCore.Identity;
using Radisson.Domain.Models.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Radisson.Domain.Business.RadissonRoleModule
{
    public class RadissonRolePostCommand : IRequest<RadissonRole>
    {
        public string Name { get; set; }
        public class RadissonRolePostCommandHandler : IRequestHandler<RadissonRolePostCommand, RadissonRole>
        {
            private readonly RoleManager<RadissonRole> roleManager;

            public RadissonRolePostCommandHandler(RoleManager<RadissonRole> roleManager)
            {
                this.roleManager = roleManager;
            }
            public async Task<RadissonRole> Handle(RadissonRolePostCommand request, CancellationToken cancellationToken)
            {
                var data = new RadissonRole();
                data.Name = request.Name;
                await roleManager.CreateAsync(data);
                //await roleManager.SetRoleNameAsync
                return data;
            }
        }
    }
}
