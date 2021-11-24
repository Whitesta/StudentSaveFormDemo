using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentSaveFormDemo.Models.EntityFramework;

namespace StudentSaveFormDemo.Controllers
{
    public class ClubsController : Controller
    {
        // GET: Clubs
        DbMvcSchoolEntities club = new DbMvcSchoolEntities();
        public ActionResult Index()
        {
            var clubs = club.TblClubs.ToList();
            return View(clubs);
        }
        [HttpGet]
         public ActionResult ClubAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ClubAdd(TblClubs clubs)
        {
            club.TblClubs.Add(clubs);
            club.SaveChanges();
            return View();
        }
        public ActionResult Delete(int id)
        {
            var deleteClub = club.TblClubs.Find(id);
            club.TblClubs.Remove(deleteClub);
            club.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetClub(int id=0)
        {
            var getClub = club.TblClubs.Find(id);
            return View("GetClub",getClub);
        }

        public ActionResult Update( TblClubs p)
        {
            var clb = club.TblClubs.Find(p.ClubID);
            clb.ClubName = p.ClubName;
            club.SaveChanges();
            return RedirectToAction("Index","Clubs");
        }
    }
}