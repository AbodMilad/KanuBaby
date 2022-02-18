using kanusaoft1.Model;
using kanusaoft1.Models;
using kanusaoft1.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kanusaoft1.Controllers
{
    public class TankController : Controller
    {
        private readonly IsupplementRepository _supplementRepository;
        private readonly Tank _tank;

        public TankController(IsupplementRepository supplementRepository, Tank tank)
        {
            _supplementRepository = supplementRepository;
            _tank = tank;
        }
        public ViewResult Index()
        {
            var items = _tank.GetTankItems();
            _tank.TankItems = items;

            var tankViewModel = new TankViewModel
            {
                Tank = _tank,
            TankTotal = _tank.GetTankTotal()
            };
        return View(tankViewModel);
        }

        public RedirectToActionResult AddToTank (string name)
        {
            var selectedsupplement = _supplementRepository.Allsuplements.FirstOrDefault(s => s.name == name);

            if (selectedsupplement != null)
            {
                _tank.AddToTank(selectedsupplement, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromTank (string name)
        {
            var selectedSupplement = _supplementRepository.Allsuplements.FirstOrDefault(s => s.name == name);

            if(selectedSupplement != null)
            {
                _tank.RemoveFromTank(selectedSupplement);
            }
            return RedirectToAction("Index");
        }
    }
}

