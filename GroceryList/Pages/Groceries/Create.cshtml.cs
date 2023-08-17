using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GroceryList.Data;
using GroceryList.Pages.Models;

namespace GroceryList.Pages.Groceries
{
    public class CreateModel : PageModel
    {
        private readonly GroceryList.Data.GroceryListContext _context;

        public CreateModel(GroceryList.Data.GroceryListContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Grocery Grocery { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Grocery == null || Grocery == null)
            {
                return Page();
            }

            _context.Grocery.Add(Grocery);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }
    }
}
