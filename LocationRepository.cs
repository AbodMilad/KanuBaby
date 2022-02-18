using kanusaoft1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kanusaoft1.Models
{
    public class LocationRepository : IlocationRepository
    {
        private readonly AppDbContext _appDbContext;

        public LocationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<location> AllLocations => _appDbContext.locations;
    }
}
