using Model.ProjectNet;
using Model.ProjectNet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ProjectNet.Queries
{
    public class AbsenceQuery
    {
        private readonly ProNetDbContext _context;

        public AbsenceQuery(ProNetDbContext context)
        {
            _context = context;
        }

        public IQueryable<Absence> GetAll()
        {
            return _context.Absences;
        }

        public IQueryable<Absence> GetById(int id)
        {
            return _context.Absences.Where(a => a.Id == id);
        }
    }
}
