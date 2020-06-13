using Model.ProjectNet;
using Model.ProjectNet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ProjectNet.Queries
{
    public class NoteQuery
    {
        private readonly ProNetDbContext _context;

        public NoteQuery(ProNetDbContext context)
        {
            _context = context;
        }

        public IQueryable<Note> GetAll()
        {
            return _context.Notes;
        }

        public IQueryable<Note> GetById(int id)
        {
            return _context.Notes.Where(e => e.Id == id);
        }
    }
}
