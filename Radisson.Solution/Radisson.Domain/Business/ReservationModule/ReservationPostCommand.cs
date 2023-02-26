﻿using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Radisson.Application.AppCode.Infrastructure;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Radisson.Domain.Business.ReservationModule
{
    public class ReservationPostCommand : IRequest<JsonResponse>
    {
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
        public class ReservationPostCommandHandler : IRequestHandler<ReservationPostCommand, JsonResponse>
        {
            private readonly RadissonDbContext db;

            public ReservationPostCommandHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<JsonResponse> Handle(ReservationPostCommand request, CancellationToken cancellationToken)
            {
                var data = new Reservation();
                data.PeopleCloud = new List<PeopleinReservation>();
                data.Name = request.Name;
                data.Surname = request.Surname;
                data.Email = request.Email;
                data.CheckIn = request.CheckIn;
                data.CheckOut = request.CheckOut;
                data.RoomTypeId = request.RoomTypeId;
                data.Price = request.Price;
                var peoplein = new PeopleinReservation();
                peoplein.PeopleFirst = request.P1;
                peoplein.PeopleSecond = request.P2;
                peoplein.PeopleThird = request.P3;
                data.PeopleCloud.Add(peoplein);
                var rooms = await db.Rooms.Where(r => r.RoomTypeId == data.RoomTypeId && r.Aviable == true && r.DeletedDate == null).ToListAsync(cancellationToken);
                if (rooms.Count == 0)
                {
                    return new JsonResponse
                    {
                        Error = true,
                        Message = "Təəssüf ki seçilən növdə boş otaq yoxdur"

                    };
                    //return null;
                }
                else
                {
                    await db.Reservations.AddAsync(data, cancellationToken);
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
}
