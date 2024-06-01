using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShofyProject.Data;
using ShofyProject.Models;
using ShofyProject.ViewModel;

namespace ShofyProject.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        List<Sliders> sliders = await _context.Sliders.ToListAsync();

        HomeVM model = new()
        {
            Sliders = sliders
        };
        return View(model);
    }
    
}

