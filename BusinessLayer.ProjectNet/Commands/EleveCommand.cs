using Model.ProjectNet;
using Model.ProjectNet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ProjectNet.Commands
{
    public class EleveCommand
    {
        private readonly ProNetDbContext _context;

        public EleveCommand(ProNetDbContext context)
        {
            _context = context;
        }

        public int Ajouter(Eleve e)
        {
            _context.Eleves.Add(e);
            return _context.SaveChanges();
        }

        public void Modifier(Eleve e)
        {
            Eleve updEl = _context.Eleves.Where(el => el.Id == e.Id).FirstOrDefault();

            if (updEl != null)
            {
                updEl.Nom = e.Nom;
                updEl.Prenom = e.Prenom;
                updEl.DateNaissance = e.DateNaissance;
                updEl.Classe = e.Classe;
            }

            _context.SaveChanges();
        }

        public void Supprimer(int EleveId)
        {
            Eleve delEl = _context.Eleves.Where(el => el.Id == EleveId).FirstOrDefault();

            if (delEl != null)
            {
                _context.Eleves.Remove(delEl);

                _context.SaveChanges();
            }
        }
    }
}
