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
    public class RequestController : Controller
    {
        private readonly IRequestRepository _requestRepository;
        private readonly Tank _tank;

        public RequestController(IRequestRepository requestRepository, Tank tank)
        {
            _requestRepository = requestRepository;
            _tank = tank;
        }

        public IActionResult List()
        {
            return View();
        }

        [HttpPost]
        public IActionResult List(Request request)
        {
            var items = _tank.GetTankItems();

            _tank.TankItems = items;

            if(_tank.TankItems.Count == 0)
            {
                ModelState.AddModelError("", "Your Tank Is Empty");
            }

            if (ModelState.IsValid)
            {
                _requestRepository.CreateRequest(request);
                _tank.ClearTank();
                return RedirectToAction("RequestComplete");
            }

            return View(request);
            
        }
        public IActionResult RequestComplete()
        {
            ViewBag.RequestCompleteMessage = "Thanks For Your Order";
            return View();
        }


    }
}
