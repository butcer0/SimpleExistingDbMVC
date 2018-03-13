using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleExistingDbMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleExistingDbMVC.Controllers
{
    public class ActorsController : Controller
    {
        private ActorDbContext _context;
        private ILogger _logger;

        public ActorsController(ActorDbContext context, ILogger<ActorsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                var data = _context.Actors.ToList();
                _logger.LogInformation("***Success hitting the Index page");
                return View(_context.Actors.ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get records in the Index page: {ex.Message}");
                throw;
            }

            
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Actors actors)
        {
            if(ModelState.IsValid)
            {
                _context.Actors.Add(actors);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actors);
        }

    }
}
