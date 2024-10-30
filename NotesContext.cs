using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Notatki_Studenckie_v3
{
    public class NotesContext : DbContext
    {
        public DbSet<QuickNote> QuickNotes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Topic> Topics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=NotesDatabase;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuickNote>().HasData
                (
                new QuickNote { QuickNoteId = 1, QuickTextDb = "[przykładowa notatka]" }
                );
            modelBuilder.Entity<Category>().HasData
                (
                new Category { CategoryId = 1, CategoryNameDb = "[Kategoria 1]" }
                );
            modelBuilder.Entity<Topic>().HasData
                (
                new Topic { TopicId = 1, TopicTextDb = "Losowa notatka, która zawiera jakieś informacje", CategoryRefId = 1 }
                );
        }
    }
}
