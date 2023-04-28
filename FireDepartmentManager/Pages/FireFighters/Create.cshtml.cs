using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FireDepartmentManager.Data;
using FireDepartmentManager.Models;

namespace FireDepartmentManager.Pages.FireFighters
{
    public class CreateModel : PageModel
    {
        private readonly FireDepartmentManager.Data.FireDepartmentManagerContext _context;

        public CreateModel(FireDepartmentManager.Data.FireDepartmentManagerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FireFighter FireFighter { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.FireFighter == null || FireFighter == null)
            {
                return Page();
            }

            _context.FireFighter.Add(FireFighter);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
