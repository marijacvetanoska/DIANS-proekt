using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SmestajDanTrebit.Models
{
    public class Accomodation
    {
        [Key]
        public long Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public String Name { get; set; }
        public String InternationalName { get; set; }
    }
}