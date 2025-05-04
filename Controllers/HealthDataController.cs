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

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Submit(string city, DateTime recordDate, string diseaseType)
        {
            var record = new HealthData
            {
                City = city,
                RecordDate = recordDate,
                DiseaseType = diseaseType
            };

            _context.HealthDataRecords.Add(record);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}