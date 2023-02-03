using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Radisson.Domain.AppCode.Infrastructure;
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
        public int[] peopleIds { get; set; }
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
                if (request.peopleIds != null)
                {
                    #region database de evvel olub indi olmayan person-larin silinmesi
                    var exceptedIds = db.ReservePeopleCloud.Where(tc => tc.ReservationId == data.Id).Select(tc => tc.PeopleId).ToList()
                                        .Except(request.peopleIds).ToArray();

                    if (exceptedIds.Length > 0)
                    {
                        foreach (var exceptedId in exceptedIds)
                        {
                            var peopleItem = db.ReservePeopleCloud.FirstOrDefault(tc => tc.PeopleId == exceptedId
                                                         && tc.ReservationId == data.Id);
                            if (peopleItem != null)
                            {
                                db.ReservePeopleCloud.Remove(peopleItem);
                            }
                        }
                    }
                    #endregion

                    #region database de evvel olmayan indi elave olunan person-larin add olunmasi
                    var newExceptedIds = request.peopleIds.Except(db.ReservePeopleCloud.Where(tc => tc.ReservationId == data.Id).Select(tc => tc.PeopleId).ToList()).ToArray();

                    if (newExceptedIds.Length > 0 && newExceptedIds.Length <= 3)
                    {
                        foreach (var exceptedId in newExceptedIds)
                        {
                            var peopleItem = new PeopleinReservation();
                            peopleItem.PeopleId = exceptedId;
                            peopleItem.ReservationId = data.Id;

                            await db.ReservePeopleCloud.AddAsync(peopleItem);
                        }
                    }
                    #endregion
                }
                await db.SaveChangesAsync(cancellationToken);

                return new JsonResponse
                {
                    Error = false,
                    Message = "Success"
                };
            }
            public JsonResult RoomType()
            {
                var rt = db.RoomTypes.ToList();
                return new JsonResult(rt);
            }
        }
    }
}
