﻿using System;
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
        
        //Takes a first request from client and return list of notes from database
        public ActionResult Index()
        {

            return View(db.Notes);
        }
        //Takes the updated notes and save changes
        [HttpPost]
        public ActionResult Change(Note note)
        {
            if (note != null)
            {
                var _note = db.Notes.Where(i => i.Id == note.Id).FirstOrDefault();
                _note.Body = note.Body;
                //db.Entry(note).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                db.Dispose();
                
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }

        //If client press "Update" button, request handled by this method
        //This method sends to the client side data from db by ViewBag
        //After handling return to client form
        public ActionResult Update(int? id)
        {
            if (id != null)
            {
                var _note = db.Notes.Where(i => i.Id == id).FirstOrDefault();
                ViewBag.noteId = _note.Id;
                ViewBag.noteBody = _note.Body;
                return View();
            }
            return HttpNotFound();
            
        }
        
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                var _note = db.Notes.Where(i => i.Id == id).FirstOrDefault();
                ViewBag.NoteId = _note.Id;
                ViewBag.NoteBody = _note.Body;
                return View();
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Delete(Note note)
        {
            var _note = db.Notes.Where(i => i.Id == note.Id).FirstOrDefault();

            if (_note != null)
            {
                db.Notes.Remove(_note);
                db.SaveChanges();
                db.Dispose();
                return RedirectToAction("index");
            }
            return HttpNotFound();
        }
        //If client press button "New", request hanled by this method
        //This method return to client view with form
        public ActionResult AddNote()
        {
            return View();
        }
        //Take post request from the client 
        [HttpPost]
        public ActionResult AddNote(Note note)
        {
            var _note = note;
            db.Notes.Add(_note);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Index");
        }
        
    }
}