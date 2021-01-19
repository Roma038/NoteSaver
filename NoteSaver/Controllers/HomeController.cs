using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoteSaver.Models;

namespace NoteSaver.Controllers
{
    public class HomeController : Controller
    {
        NoteContext db = new NoteContext();
        

        public ActionResult Index()
        {

            return View(db.Notes);
        }

        [HttpPost]
        public ActionResult Change(Note note)
        {
            
            var _note = db.Notes.Where(i => i.Id == note.Id).FirstOrDefault();
            _note.Body = note.Body;
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }

        
        public ActionResult Update(int id)
        {
            var _note = db.Notes.Where(i => i.Id == id).FirstOrDefault();
            ViewBag.noteId = _note.Id;
            ViewBag.noteBody = _note.Body;
            return View();
        }
        
        public ActionResult Delete(int id)
        {
            var _note = db.Notes.Where(i => i.Id == id).FirstOrDefault();
            db.Notes.Remove(_note);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddNote()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNote(Note note)
        {
            var _note = note;
            db.Notes.Add(_note);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}