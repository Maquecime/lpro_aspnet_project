using Model.ProjectNet;
using Model.ProjectNet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ProjectNet.Commands
{
    public class AbsenceCommand
    {
        private readonly ProNetDbContext _context;

        public AbsenceCommand(ProNetDbContext context)
        {
            _context = context;
        }

        public int Ajouter(Absence a)
        {
            _context.Absences.Add(a);
            return _context.SaveChanges();
        }

        public void Modifier(Absence a)
        {
            Absence updAbs = _context.Absences.Where(abs => abs.Id == a.Id).FirstOrDefault();

            if(updAbs != null)
            {
                updAbs.Motif = a.Motif;
                updAbs.DateAbsence = a.DateAbsence;
                updAbs.Eleve = a.Eleve;
            }

            _context.SaveChanges();
        }

        public void Supprimer(int AbsenceId)
        {
            Absence delAbs = _context.Absences.Where(abs => abs.Id == AbsenceId).FirstOrDefault();

            if(delAbs != null)
            {
                _context.Absences.Remove(delAbs);

                _context.SaveChanges();
            }
        }
    }
}
