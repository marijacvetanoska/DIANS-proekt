﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using SmestajDanTrebit.Models;
using System.Threading;
using System.Globalization;

namespace SmestajDanTrebit.Controllers
{
    public class HomeController : Controller
    {
        AccomodationContext db = new AccomodationContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string search)
        {
            return View("FindAccomodation", db.accomodations.Where(x => x.Name.ToLower().ToString().Contains(search.ToLower()) || x.InternationalName.ToLower().ToString().Contains(search.ToLower())));
        }

        public ActionResult FindAccomodation()
        {
               return View(db.accomodations.ToList());
        }

        public ActionResult PlacesToVisit()
        {
            return View();
        }
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
