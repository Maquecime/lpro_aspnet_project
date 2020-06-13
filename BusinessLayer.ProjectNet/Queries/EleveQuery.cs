using Model.ProjectNet;
using Model.ProjectNet.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ProjectNet.Queries
{
    public class EleveQuery
    {
        private readonly ProNetDbContext _context;

        public EleveQuery(ProNetDbContext context)
        {
            _context = context;
        }

        public IQueryable<Eleve> GetAll()
        {
            return _context.Eleves.Include(e => e.Notes).Include(e => e.Absences).Include(e => e.Classe);              
        }

        public IQueryable<Eleve> GetById(int id)
        {
            return _context.Eleves.Where(e => e.Id == id).Include(e => e.Notes).Include(e => e.Absences);
        }
    }
}
