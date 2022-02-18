using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kanusaoft1.Models
{
    public interface IRequestRepository
    {
        void CreateRequest(Request request);
    }
}
