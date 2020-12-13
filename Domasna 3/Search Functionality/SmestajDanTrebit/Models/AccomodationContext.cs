using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmestajDanTrebit.Models
{
    public class AccomodationContext : DbContext
    {
        public DbSet<Accomodation> accomodations { get; set; }

        public AccomodationContext() : base("DefaultConnection")
        {
        }


    }
}