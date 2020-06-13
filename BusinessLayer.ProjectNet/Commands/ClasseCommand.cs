using Model.ProjectNet;
using Model.ProjectNet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ProjectNet.Commands
{
    public class ClasseCommand
    {
        private readonly ProNetDbContext _context;

        public ClasseCommand(ProNetDbContext context)
        {
            _context = context;
        }

        public int Ajouter(Classe c)
        {
            _context.Classes.Add(c);
            return _context.SaveChanges();
        }

        public void Modifier(Classe c)
        {
            Classe updCl = _context.Classes.Where(cl => cl.Id == c.Id).FirstOrDefault();

            if (updCl != null)
            {
                updCl.Niveau = c.Niveau;
                updCl.NomEtablissement = c.NomEtablissement;
            }

            _context.SaveChanges();
        }

        public void Supprimer(int ClasseId)
        {
            Classe delCl = _context.Classes.Where(cl => cl.Id == ClasseId).FirstOrDefault();

            if (delCl != null)
            {
                _context.Classes.Remove(delCl);

                _context.SaveChanges();
            }
        }
    }
}
