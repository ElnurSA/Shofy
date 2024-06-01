using System;
using Microsoft.EntityFrameworkCore;
using ShofyProject.Models;

namespace ShofyProject.Data
{
	public class AppDbContext : DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Sliders> Sliders { get; set; }
	}
}

