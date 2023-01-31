﻿using Radisson.Domain.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radisson.Domain.Models.Entities
{
    public class People : BaseEntity
    {
        public string Text { get; set; }
        public double Price { get; set; }
        public virtual ICollection<PeopleinReservation> PeopleCloud { get; set; }
    }
}
