using Model.ProjectNet.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ProjectNet.Configurations
{
    class NoteConfiguration : EntityTypeConfiguration<Note>
    {
        public NoteConfiguration()
        {
            ToTable("PRONET_Note");
            HasKey(n => n.Id);

            Property(n => n.Id).HasColumnName("NOTE_ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(n => n.Matiere).HasColumnName("NOTE_MATIERE").IsRequired().HasMaxLength(20);
            Property(n => n.Appreciation).HasColumnName("NOTE_APPEC").IsOptional().HasMaxLength(50);
            Property(n => n.DateNote).HasColumnName("NOTE_DATENOTE").IsRequired();
            Property(n => n.NoteValue).HasColumnName("NOTE_VALUE").IsRequired();

            HasRequired(n => n.Eleve).WithMany(e => e.Notes).HasForeignKey(n => n.EleveId);

        }
    }
}
