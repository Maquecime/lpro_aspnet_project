﻿using Model.ProjectNet;
using Model.ProjectNet.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ProjectNet.Queries
{
    public class ClasseQuery
    {
        private readonly ProNetDbContext _context;

        public ClasseQuery(ProNetDbContext context)
        {
            _context = context;
        }

        public IQueryable<Classe> GetAll()
        {
            return _context.Classes.Include(c => c.Eleves);
        }

        public IQueryable<Classe> GetById(int id)
        {
            return _context.Classes.Where(c => c.Id == id).Include(c => c.Eleves);
        }
    }
}
