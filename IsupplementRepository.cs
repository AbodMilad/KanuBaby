using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kanusaoft1.Model
{
    public interface IsupplementRepository
    {
        IEnumerable<supplement> Allsuplements { get; }
        supplement GetSupplementByname(string name);
    }
}
