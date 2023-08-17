using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GroceryList.Data
{
    public class GroceryListContext : DbContext
    {
        public GroceryListContext (DbContextOptions<GroceryListContext> options)
            : base(options)
        {
        }

        public DbSet<Pages.Models.Grocery> Grocery { get; set; } = default!;
    }
}
