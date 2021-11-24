using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentSaveFormDemo.Models.EntityFramework;


namespace StudentSaveFormDemo.Controllers
{
    public class LessonsController : Controller
    {
        // GET: Default
        DbMvcSchoolEntities db = new DbMvcSchoolEntities();
        public ActionResult Index()
        {
            var lessons = db.TblLessons.ToList();   
            return View(lessons);
        }
        [HttpGet]
        public ActionResult NewLessonAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewLessonAdd(TblLessons add)
        {
            db.TblLessons.Add(add);
            db.SaveChanges();
            return View();
           
        }
        public ActionResult Delete(int id)
        {
            var deleteLesson = db.TblLessons.Find(id);
            db.TblLessons.Remove(deleteLesson);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetLesson(int id)
        {
            var getLesson = db.TblLessons.Find(id);
            return View("GetLesson",getLesson);
        }

        public ActionResult Update(TblLessons l)
        {
            var lssn = db.TblLessons.Find(l.LessonId);
            lssn.LessonAd = l.LessonAd;
            db.SaveChanges();
            return RedirectToAction("Index", "Lessons");
        }
    }
}