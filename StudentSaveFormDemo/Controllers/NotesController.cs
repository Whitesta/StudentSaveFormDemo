using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentSaveFormDemo.Models.EntityFramework;
using StudentSaveFormDemo.Models;

namespace StudentSaveFormDemo.Controllers
{
    public class NotesController : Controller
    {
        // GET: Notes
        DbMvcSchoolEntities note = new DbMvcSchoolEntities();
        public ActionResult Index()
        {
            var notes = note.TblNotes.ToList();
            return View(notes);
        }
        [HttpGet]
       public ActionResult AddNote()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNote(TblNotes tblNotes)
        {
            note.TblNotes.Add(tblNotes);
            note.SaveChanges();
            return Redirect("Index");
        }
        public ActionResult Delete(int id)
        {
            var deleteNote = note.TblNotes.Find(id);
            note.TblNotes.Remove(deleteNote);
            note.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetNote(int id)
        {
            var getNote = note.TblNotes.Find(id);
            return View("GetNote", getNote);
        }

        [HttpPost]
        public ActionResult GetNote(Class1 model, TblNotes n, int exam1 = 0, int exam2 = 0, int exam3 = 0, int project = 0 )
        {
            if (model.Islem == "Calculate")
            {
                int avarage = (exam1 + exam2 + exam3 + project) / 4;
                ViewBag.avrg = avarage;
            }
            if (model.Islem == "NoteUpdate")
            {
                var noteUpdate = note.TblNotes.Find(n.NoteID);
                noteUpdate.Exam1 = n.Exam1;
                noteUpdate.Exam2 = n.Exam2;
                noteUpdate.Exam3 = n.Exam3;
                noteUpdate.Project = n.Project;
                noteUpdate.Avarage = n.Avarage;
                note.SaveChanges();
                return RedirectToAction("Index", "Notes");
            }

            return View();
        }

        
    }
}