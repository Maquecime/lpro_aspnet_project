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
    class AbsenceConfiguration : EntityTypeConfiguration<Absence>
    {
        public AbsenceConfiguration()
        {
            ToTable("PRONET_Absence");
            HasKey(a => a.Id);

            Property(a => a.Id).HasColumnName("ABS_ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.Motif).HasColumnName("ABS_MOTIF").IsRequired().HasMaxLength(50);
            Property(a => a.DateAbsence).HasColumnName("ABS_DATEABS").IsRequired();

            HasRequired(a => a.Eleve).WithMany(e => e.Absences).HasForeignKey(e => e.EleveId);

        }
    }
}
