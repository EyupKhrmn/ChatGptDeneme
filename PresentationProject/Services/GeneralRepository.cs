using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationProject.Services
{
    public class GeneralRepository
    {
        private readonly ApplicationDbContext _context;

        public GeneralRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void add(object entity)
        {
            _context.Add(entity);
        }

        public void delete(object entity)
        {
            _context.Remove(entity);
        }

        public void update(object entity)
        {
            _context.Update(entity);
        }
    }
}
