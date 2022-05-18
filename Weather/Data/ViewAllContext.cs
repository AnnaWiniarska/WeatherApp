using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Models;

namespace Weather.Data
{
    public class ViewAllContext : PageModel
    {
        private readonly ApplicationDbContext _context;
        public ViewAllContext(ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<City> WeatherModel { get; set; }
        public async Task OnGetAsync()
        {
            WeatherModel = _context.cities.ToList();
        }
    }
}
