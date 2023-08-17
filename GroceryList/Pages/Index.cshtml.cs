using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroceryList.Data;
using GroceryList.Pages.Models;

namespace GroceryList.Pages
{
    public class IndexModel : PageModel
    {
        private readonly GroceryListContext _context;

        public IndexModel(GroceryListContext context)
        {
            _context = context;
        }

        public IList<Grocery> Grocery { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Grocery != null)
            {
                Grocery = await _context.Grocery.ToListAsync();
            }
        }
    }
}
