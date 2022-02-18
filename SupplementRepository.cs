using kanusaoft1.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kanusaoft1.Models
{
    public class SupplementRepository : IsupplementRepository
    {
        private readonly AppDbContext _appDbContext;

        public SupplementRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        public IEnumerable<supplement> Allsuplements
        {
            get
            {
                return _appDbContext.supplements.Include(l => l.location);
            }
        }

        public supplement GetSupplementByname(string name)
        {
            return _appDbContext.supplements.FirstOrDefault(s => s.name == name);
        }
    }
}
