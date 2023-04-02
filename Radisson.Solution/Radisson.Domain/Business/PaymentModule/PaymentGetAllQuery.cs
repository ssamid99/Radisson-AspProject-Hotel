using MediatR;
using Radisson.Application.AppCode.Infrastructure;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Radisson.Domain.Business.PaymentModule
{
    public class PaymentGetAllQuery : PaginateModel, IRequest<PagedViewModel<Payment>>
    {
        public class PaymentGetAllQueryHandler : IRequestHandler<PaymentGetAllQuery, PagedViewModel<Payment>>
        {
            private readonly RadissonDbContext db;

            public PaymentGetAllQueryHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<PagedViewModel<Payment>> Handle(PaymentGetAllQuery request, CancellationToken cancellationToken)
            {
                if (request.PageSize < 6)
                {
                    request.PageSize = 6;
                }
                var query = db.Payments
                    .Where(r => r.DeletedDate == null)
                    .OrderByDescending(r => r.CreatedDate)
                    .AsQueryable();
                if (query == null)
                {
                    return null;
                }
                var pagedModel = new PagedViewModel<Payment>(query, request);
                return pagedModel;
            }
        }
    }
}
