using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ProjectNet.Entities
{
    public class Classe
    {
        public Classe()
        {
            Eleves = new List<Eleve>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string NomEtablissement { get; set; }

        [Required]
        public string Niveau { get; set; }

        public ICollection<Eleve> Eleves { get; set; }

    }
}
