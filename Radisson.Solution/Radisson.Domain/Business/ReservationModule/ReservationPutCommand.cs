using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Radisson.Application.AppCode.Infrastructure;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Radisson.Domain.Business.ReservationModule
{
    public class ReservationPutCommand : IRequest<JsonResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int RoomTypeId { get; set; }
        public int Price { get; set; }
        public int P1 { get; set; }
        public int P2 { get; set; }
        public int P3 { get; set; }
        public class ReservationPutCommandHandler : IRequestHandler<ReservationPutCommand, JsonResponse>
        {
            private readonly RadissonDbContext db;

            public ReservationPutCommandHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<JsonResponse> Handle(ReservationPutCommand request, CancellationToken cancellationToken)
            {
                var data = await db.Reservations
                    .Include(r=>r.PeopleCloud)
                    .FirstOrDefaultAsync(re => re.Id == request.Id && re.DeletedDate == null, cancellationToken);
                if (data == null)
                {
                    return null;
                }

                data.Name = request.Name;
                data.Surname = request.Surname;
                data.Email = request.Email;
                data.CheckIn = request.CheckIn;
                data.CheckOut = request.CheckOut;
                data.Price = request.Price;
                if (data.RoomId == 0)
                {
                    data.RoomTypeId = request.RoomTypeId;
                }
                var peoples = db.ReservePeopleCloud.FirstOrDefault(p => p.ReservationId == data.Id && p.DeletedDate == null);
                if (peoples == null)
                {
                    return null;
                }
                peoples.PeopleFirst = request.P1;
                peoples.PeopleSecond = request.P2;
                peoples.PeopleThird = request.P3;

                db.ReservePeopleCloud.Update(peoples);
                await db.SaveChangesAsync(cancellationToken);

                return new JsonResponse
                {
                    Error = false,
                    Message = "Success"
                };
            }
        }
    }
}
