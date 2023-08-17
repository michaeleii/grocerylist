using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroceryList.Data;
using GroceryList.Pages.Models;

namespace GroceryList.Pages.Groceries
{
    public class DeleteModel : PageModel
    {
        private readonly GroceryList.Data.GroceryListContext _context;

        public DeleteModel(GroceryList.Data.GroceryListContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Grocery Grocery { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Grocery == null)
            {
                return NotFound();
            }

            var grocery = await _context.Grocery.FirstOrDefaultAsync(m => m.ID == id);

            if (grocery == null)
            {
                return NotFound();
            }
            else 
            {
                Grocery = grocery;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Grocery == null)
            {
                return NotFound();
            }
            var grocery = await _context.Grocery.FindAsync(id);

            if (grocery != null)
            {
                Grocery = grocery;
                _context.Grocery.Remove(Grocery);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("../Index");
        }
    }
}
