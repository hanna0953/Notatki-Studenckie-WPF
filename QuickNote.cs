using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Notatki_Studenckie_v3
{
    public class QuickNote
    {
        public QuickNote() { }
        public QuickNote(string text) { QuickTextDb = text; }
        public int QuickNoteId { get; set; }
        public string QuickTextDb { get; set; } = string.Empty;
    }
}
