using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentSaveFormDemo.Models.EntityFramework;

namespace StudentSaveFormDemo.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        DbMvcSchoolEntities std = new DbMvcSchoolEntities();
        public ActionResult Index()
        {
            var student = std.TblStudents.ToList();
            return View(student);
        }
        [HttpGet]
        public ActionResult AddStudent()
        {
            List<SelectListItem> value = (from i in std.TblClubs.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.ClubName,
                                              Value = i.ClubID.ToString()
                                          }).ToList();
            ViewBag.vl = value;
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(TblStudents students)
        {
            var club = std.TblClubs.Where(c => c.ClubID == students.TblClubs.ClubID).FirstOrDefault();
            students.TblClubs = club;
            std.TblStudents.Add(students);
            std.SaveChanges();
            return Redirect("Index");
        }
        public ActionResult Delete(int id)
        {
            var deleteStudent = std.TblStudents.Find(id);
            std.TblStudents.Remove(deleteStudent);
            std.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetStudent(int id)
        {
            var getStudent = std.TblStudents.Find(id);
            List<SelectListItem> value = (from i in std.TblClubs.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.ClubName,
                                              Value = i.ClubID.ToString()
                                          }).ToList();
            ViewBag.vl = value;
            return View("GetStudent", getStudent);
        }

        public ActionResult Update(TblStudents s)
        {
           
            var student = std.TblStudents.Find(s.StudentID);
            student.StudentFirstName = s.StudentFirstName;
            student.StudentLastName = s.StudentLastName;
            student.StudentNote = s.StudentNote;
            student.StudentFoto = s.StudentFoto;
            student.StudentClub = s.StudentClub;
            student.StudentGender = s.StudentGender;
            std.SaveChanges();
            return RedirectToAction("Index", "Students");
        }
    }
}