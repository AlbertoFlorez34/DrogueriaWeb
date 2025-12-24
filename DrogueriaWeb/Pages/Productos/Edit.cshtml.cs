using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DrogueriaWeb.Data;
using DrogueriaWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace DrogueriaWeb.Pages.Productos
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Producto Producto { get; set; } = new Producto();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Producto = await _context.Productos.FindAsync(id);

            if (Producto == null)
                return RedirectToPage("Index"); // si no existe, vuelve a la lista

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Attach(Producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
