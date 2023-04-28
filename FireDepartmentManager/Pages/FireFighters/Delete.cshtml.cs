using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FireDepartmentManager.Data;
using FireDepartmentManager.Models;

namespace FireDepartmentManager.Pages.FireFighters
{
    public class DeleteModel : PageModel
    {
        private readonly FireDepartmentManager.Data.FireDepartmentManagerContext _context;

        public DeleteModel(FireDepartmentManager.Data.FireDepartmentManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
      public FireFighter FireFighter { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FireFighter == null)
            {
                return NotFound();
            }

            var firefighter = await _context.FireFighter.FirstOrDefaultAsync(m => m.Id == id);

            if (firefighter == null)
            {
                return NotFound();
            }
            else 
            {
                FireFighter = firefighter;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.FireFighter == null)
            {
                return NotFound();
            }
            var firefighter = await _context.FireFighter.FindAsync(id);

            if (firefighter != null)
            {
                FireFighter = firefighter;
                _context.FireFighter.Remove(FireFighter);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
