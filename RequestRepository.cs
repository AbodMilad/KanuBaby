using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kanusaoft1.Models
{
    public class RequestRepository : IRequestRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly Tank _tank;

        public RequestRepository(AppDbContext appDbContext, Tank tank)
        {
            _appDbContext = appDbContext;
            _tank = tank;

        }
        public void CreateRequest(Request request)
        {
            request.RequestPlaced = DateTime.Now;

            _appDbContext.Requests.Add(request);

            var TankItems = _tank.TankItems;

            foreach (var TankItem in TankItems)
            {
                var requestDetail = new RequestDetail()
                {
                    location = TankItem.supplement.location,
                    Supplement = TankItem.supplement.name,
                    RequestId = request.RequestId,
                    Amount = TankItem.supplement.amount
                };

                _appDbContext.RequestDetails.Add(requestDetail);
            }

            _appDbContext.SaveChanges();
        }
    }
}
