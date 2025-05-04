using HealthDataApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthDataApp.Controllers
{
    public class HealthDataController : Controller
    {
        private readonly AppDbContext _context;

        public HealthDataController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            try 
            {
                var records = await _context.HealthDataRecords.ToListAsync();
                return View(records);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error loading data: " + ex.Message;
                return View(new List<HealthData>());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Submit(HealthData model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            try
            {
                _context.HealthDataRecords.Add(model);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Data saved successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException dbEx)
            {
                ModelState.AddModelError("", "Database error: " + dbEx.InnerException?.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error: " + ex.Message);
            }

            return View("Index", model);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}