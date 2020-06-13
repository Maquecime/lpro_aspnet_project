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
    class EleveConfiguration : EntityTypeConfiguration<Eleve>
    {
        public EleveConfiguration()
        {
            ToTable("PRONET_Eleve");
            HasKey(e => e.Id);

            Property(e => e.Id).HasColumnName("ELE_ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Nom).HasColumnName("ELE_NOM").IsRequired().HasMaxLength(20);
            Property(e => e.Prenom).HasColumnName("ELE_PRENOM").IsRequired().HasMaxLength(20);
            Property(e => e.DateNaissance).HasColumnName("ELE_DATENAISS").IsRequired();

            HasRequired(e => e.Classe).WithMany(c => c.Eleves).HasForeignKey(e => e.ClasseId);

            HasMany(e => e.Absences).WithRequired(a => a.Eleve).HasForeignKey(a => a.EleveId);
            HasMany(e => e.Notes).WithRequired(n => n.Eleve).HasForeignKey(n => n.EleveId);
        }
    }
}
