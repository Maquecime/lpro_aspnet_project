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
    class ClasseConfiguration : EntityTypeConfiguration<Classe>
    {
        public ClasseConfiguration()
        {
            ToTable("PRONET_Classe");
            HasKey(c => c.Id);

            Property(c => c.Id).HasColumnName("CLA_ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.NomEtablissement).HasColumnName("CLA_NOMETA").IsRequired().HasMaxLength(40);
            Property(c => c.Niveau).HasColumnName("CLA_NIVEAU").IsRequired();

            HasMany(c => c.Eleves).WithRequired(e => e.Classe).HasForeignKey(e => e.ClasseId);
        }
    }
}
