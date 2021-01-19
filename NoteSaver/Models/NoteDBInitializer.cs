using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NoteSaver.Models
{
    public class NoteDBInitializer : DropCreateDatabaseAlways<NoteContext>
    {
        protected override void Seed(NoteContext db)
        {
            db.Notes.Add(new Note { Id = 1 , Body = "Hi everyone, its first note in here" });
            base.Seed(db);
        }
    }
}