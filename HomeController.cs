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
    public class HomeController : Controller
    {
        private readonly IsupplementRepository _supplementRepository;
        private readonly IlocationRepository _locationRepository;
        private readonly AppDbContext _appDbContext;

        public HomeController(IsupplementRepository supplementRepository, IlocationRepository loactionRepository, AppDbContext appDbContext)
        {
            _supplementRepository = supplementRepository;
            _locationRepository = loactionRepository;
            _appDbContext = appDbContext;

        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                Supplements = _supplementRepository.Allsuplements
            };
            return View(homeViewModel);
        }

        //Get-CreateLocation
        public IActionResult CreateLocation()
        {
            return View();
        }

        //post-CreateLocation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateLocation(location location)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.locations.Add(location);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(location);
        }

        //Get-Edit
        public IActionResult EditLocation(string name)
        {
            if (name == null)
            {
                return NotFound();
            }
            var location = _appDbContext.locations.Find(name);
            if(location == null)
            {
                return NotFound();
            }
            return View(location);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditLocation(location location)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.locations.Update(location);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(location);
        }

        public IActionResult DeleteL(string name)
        {
            if (name == null)
            {
                return NotFound();
            }
            var location = _appDbContext.locations.Find(name);
            if (location == null)
            {
                return NotFound();
            }
            return View(name);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteLocation(String name)
        {
            var obj = _appDbContext.locations.Find(name);
          
            if( obj == null)
            {
                return NotFound();
            }
                _appDbContext.locations.Remove(obj);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
           
            
        }
    }

}
