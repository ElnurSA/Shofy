using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShofyProject.Data;
using ShofyProject.Models;
using ShofyProject.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShofyProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;

        public SliderController(AppDbContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            List<Sliders> sliders = await _context.Sliders.ToListAsync();
            
            return View(sliders);
        }
        

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            Sliders sliders = await _context.Sliders.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (sliders is null) return NotFound();

            

            return View(sliders);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Sliders slide = await _context.Sliders.Where(m => m.Id == id).FirstOrDefaultAsync();

            if(slide is null)
            {
                return NotFound();
            }

            _context.Sliders.Remove(slide);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(Sliders slide)
        {
            await _context.Sliders.AddAsync(slide);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }

}

