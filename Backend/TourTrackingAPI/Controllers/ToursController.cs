using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourTrackingAPI.Data;
using TourTrackingAPI.Models;

namespace TourTrackingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToursController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ToursController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tour>>> GetTours()
        {
            return await _context.Tours.Include(t => t.Days).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tour>> GetTour(string id)
        {
            var tour = await _context.Tours.Include(t => t.Days).FirstOrDefaultAsync(t => t.Id == id);
            if (tour == null) return NotFound();
            return tour;
        }

        [HttpPost]
        public async Task<ActionResult<Tour>> SaveTour(Tour tour)
        {
            var existingTour = await _context.Tours.Include(t => t.Days).FirstOrDefaultAsync(t => t.Id == tour.Id);

            if (existingTour != null)
            {
                _context.TourDates.RemoveRange(existingTour.Days);
                existingTour.Name = tour.Name;
                existingTour.StartDate = tour.StartDate;
                existingTour.EndDate = tour.EndDate;
                existingTour.Days = tour.Days;
            }
            else
            {
                _context.Tours.Add(tour);
            }

            await _context.SaveChangesAsync();
            return Ok(tour);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTour(string id)
        {
            var tour = await _context.Tours.Include(t => t.Days).FirstOrDefaultAsync(t => t.Id == id);
            if (tour == null) return NotFound();

            _context.TourDates.RemoveRange(tour.Days);
            _context.Tours.Remove(tour);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
