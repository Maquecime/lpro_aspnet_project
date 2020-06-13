using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ProjectNet.Entities
{
    public class Absence
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DateAbsence { get; set; }

        [Required]
        [MaxLength(50)]
        public string Motif { get; set; }

        public int EleveId { get; set; }

        public Eleve Eleve { get; set; }
    }
}
