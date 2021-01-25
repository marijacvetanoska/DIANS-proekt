﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using SmestajDanTrebit.Models;
using System.Threading;
using System.Globalization;
using System.Data.Entity;

namespace SmestajDanTrebit.Controllers
{
    public class HomeController : Controller
    {
        AccomodationContext db = new AccomodationContext();
        public ActionResult Index()
        {
            return View();
        }

        //Search funkcija koja gi prebaruva hotelite i apartmanite od bazata
        public ActionResult Search(string search)
        {
            return View("FindAccomodation", searchAccomodation(search));
        }

        private DbSet<Accomodation> searchAccomodation(string search)
        {
            return (DbSet<Accomodation>)db.accomodations.Where(x => x.Name.ToLower().ToString().Contains(search.ToLower()) || x.InternationalName.ToLower().ToString().Contains(search.ToLower()));
        }

        public ActionResult FindAccomodation()
        {
               return View(db.accomodations.ToList());
        }

        public ActionResult PlacesToVisit()
        {
            return View();
        }
        //Ovaa funkcija ja povikavme samo ednas na pocetokot za da se popolni
        //bazata so podatoci
        public ActionResult saveToDatabase()
        {
            string filePath = "~/App_Data/hotels&apartments.csv";

            //Read the contents of CSV file.
            string csvData = System.IO.File.ReadAllText(filePath);

            //Execute a loop over the rows.
            foreach (string row in csvData.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    db.accomodations.Add(new Accomodation
                    {
                        Id = Convert.ToInt64(row.Split(',')[0]),
                        Longitude = Convert.ToDouble(row.Split(',')[1]),
                        Latitude = Convert.ToDouble(row.Split(',')[2]),
                        Name = row.Split(',')[3],
                        InternationalName = row.Split(',')[4]
                    });
                    db.SaveChanges();
                }
            }

            return View("Index");
        }

        public ActionResult ShowInfo(int? id)
        {
            Accomodation accomodation = db.accomodations.Find(id);
            return View(accomodation);
        }


        public ActionResult Map()
        {
            return View();
        }
    }


}
