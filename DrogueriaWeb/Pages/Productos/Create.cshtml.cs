using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DrogueriaWeb.Data;
using DrogueriaWeb.Models;

namespace DrogueriaWeb.Pages.Productos
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Producto Producto { get; set; } = new Producto();

        public void OnGet()
        {
            // Nada especial, solo carga la página
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Productos.Add(Producto);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index"); // vuelve a listar productos
        }
    }
}