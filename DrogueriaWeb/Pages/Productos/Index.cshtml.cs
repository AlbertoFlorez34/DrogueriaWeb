using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DrogueriaWeb.Data;
using DrogueriaWeb.Models;


namespace DrogueriaWeb.Pages.Productos;
public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public IList<Producto> Productos { get; set; } = new List<Producto>();

    public async Task OnGetAsync()
    {
        Productos = await _context.Productos.ToListAsync();
    }
}