using Model.ProjectNet.Configurations;
using Model.ProjectNet.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ProjectNet
{
    public class ProNetDbContext : DbContext
    {
        public ProNetDbContext() : base("name=ProNetConnectionString")
        {
            Database.SetInitializer<ProNetDbContext>(new DropCreateDatabaseIfModelChanges<ProNetDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Configurations.Add(new AbsenceConfiguration());
            modelBuilder.Configurations.Add(new ClasseConfiguration());
            modelBuilder.Configurations.Add(new EleveConfiguration());
            modelBuilder.Configurations.Add(new NoteConfiguration());
        }

        public DbSet<Absence> Absences { get; set; }
        public DbSet<Classe> Classes { get; set; }
        public DbSet<Eleve> Eleves { get; set; }
        public DbSet<Note> Notes { get; set; }

    }
}
