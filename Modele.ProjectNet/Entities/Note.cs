using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ProjectNet.Entities
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Matiere { get; set; }

        [Required]
        public DateTime DateNote { get; set; }

        [MaxLength(50)]
        public string Appreciation { get; set; }

        [Required]
        public int NoteValue { get; set; }

        public int EleveId { get; set; }

        public Eleve Eleve { get; set; }
    }
}
