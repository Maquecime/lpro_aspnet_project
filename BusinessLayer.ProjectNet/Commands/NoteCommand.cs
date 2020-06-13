using Model.ProjectNet;
using Model.ProjectNet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ProjectNet.Commands
{
    public class NoteCommand
    {
        private readonly ProNetDbContext _context;

        public NoteCommand(ProNetDbContext context)
        {
            _context = context;
        }

        public int Ajouter(Note n)
        {
            _context.Notes.Add(n);
            return _context.SaveChanges();
        }

        public void Modifier(Note n)
        {
            Note updNt = _context.Notes.Where(nt => nt.Id == n.Id).FirstOrDefault();

            if (updNt != null)
            {
                updNt.Appreciation = n.Appreciation;
                updNt.DateNote = n.DateNote;
                updNt.Matiere = n.Matiere;
                updNt.NoteValue = n.NoteValue;
                updNt.Eleve = n.Eleve;

            }

            _context.SaveChanges();
        }

        public void Supprimer(int NoteId)
        {
            Note delNt = _context.Notes.Where(nt => nt.Id == NoteId).FirstOrDefault();

            if (delNt != null)
            {
                _context.Notes.Remove(delNt);

                _context.SaveChanges();
            }
        }
    }
}
