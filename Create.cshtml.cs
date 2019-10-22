using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CandyCaneLane1._1.Data;

namespace CandyCaneLane1._1.Pages.Candy
{
    public class CreateModel : PageModel
    {
        private readonly CandyCaneLane1._1.Data.ApplicationDbContext _context;

        public CreateModel(CandyCaneLane1._1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["OrderID"] = new SelectList(_context.Set<Orders>(), "OderID", "OderID");
        ViewData["StoreID"] = new SelectList(_context.Stores, "StoreID", "StoreID");
            return Page();
        }

        [BindProperty]
        public Candies Candies { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Candies.Add(Candies);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}