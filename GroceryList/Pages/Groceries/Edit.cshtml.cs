using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroceryList.Data;
using GroceryList.Pages.Models;

namespace GroceryList.Pages.Groceries
{
    public class EditModel : PageModel
    {
        private readonly GroceryList.Data.GroceryListContext _context;

        public EditModel(GroceryList.Data.GroceryListContext context)
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

            var grocery =  await _context.Grocery.FirstOrDefaultAsync(m => m.ID == id);
            if (grocery == null)
            {
                return NotFound();
            }
            Grocery = grocery;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Grocery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroceryExists(Grocery.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../Index");
        }

        private bool GroceryExists(int id)
        {
          return (_context.Grocery?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
