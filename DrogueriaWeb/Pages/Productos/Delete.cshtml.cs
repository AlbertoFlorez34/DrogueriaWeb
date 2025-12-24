using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DrogueriaWeb.Data;
using DrogueriaWeb.Models;

namespace DrogueriaWeb.Pages.Productos
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}
