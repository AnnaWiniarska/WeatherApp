using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Weather.Models;
namespace Weather.Data
{
    public class SaveContext : PageModel
    {
        private readonly ApplicationDbContext _context;
        public SaveContext(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public City WeatherModel { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.cities.Add(WeatherModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
