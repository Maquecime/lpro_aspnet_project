using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Model.ProjectNet.Entities
{
    public class Eleve
    {


    public Eleve()
        {
            Absences = new List<Absence>();
            Notes = new List<Note>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Nom { get; set; }

        [Required]
        [MaxLength(20)]
        public string Prenom { get; set; }

        [Required]
        public DateTime DateNaissance { get; set; }

        public int ClasseId { get; set; }

        public Classe Classe { get; set; }

        public ICollection<Absence> Absences { get; set; }

        public ICollection<Note> Notes { get; set; }

    }
}
