using kanusaoft1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kanusaoft1.Models
{
    public class Tank
    {
        private readonly AppDbContext _appDbContext;

        public string TankId { get; set; }
        public List<TankItem> TankItems { get; set; }

        private Tank(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public static Tank GetTank(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            var context = service.GetService<AppDbContext>();

            string tankId = session.GetString("TankId") ?? Guid.NewGuid().ToString();

            session.SetString("TankId", tankId);
            return new Tank(context) { TankId = tankId };
        }
        public void AddToTank(supplement supplement, int amount)
        {
            var TankItem =
                _appDbContext.TankItems.SingleOrDefault(
                    t => t.supplement.name == supplement.name && t.TankId == TankId);
            if (TankItem == null)
            {
                TankItem = new TankItem
                {
                    TankId = TankId,
                    supplement = supplement,
                    Amount = 1
                };
                _appDbContext.TankItems.Add(TankItem);
            }
            else
            {
                TankItem.Amount++;
            }
            _appDbContext.SaveChanges();
           
        }
        public int RemoveFromTank(supplement supplement)
        {
            var TankItem =
               _appDbContext.TankItems.SingleOrDefault(
                   t => t.supplement.name == supplement.name && t.TankId == TankId);
            var localAmount = 0;
            if (TankItem != null)
            {
                if (TankItem.Amount > 1)
                {
                    TankItem.Amount--;
                    localAmount = TankItem.Amount;
                    
                }
                else
                {
                    _appDbContext.TankItems.Remove(TankItem);
                }
            }
            _appDbContext.SaveChanges();
            return localAmount;

        }
        public List<TankItem> GetTankItems()
        {
            return TankItems ??
                (TankItems =
                _appDbContext.TankItems.Where(c => c.TankId == TankId)
                .Include(t => t.supplement)
                .ToList());
        }

        public void ClearTank()
        {
            var TankItems = _appDbContext.TankItems.Where(Tank => Tank.TankId == TankId);

            _appDbContext.TankItems.RemoveRange(TankItems);
            _appDbContext.SaveChanges();
        }

        public decimal GetTankTotal()
        {
            var total = _appDbContext.TankItems.Where(c => c.TankId == TankId)
                .Select(c => c.supplement.amount *  c.Amount).Sum();
            return total;
        }
    }
}
