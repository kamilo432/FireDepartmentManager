using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FireDepartmentManager.Data;
using FireDepartmentManager.Models;

namespace FireDepartmentManager.Pages.FireFighters
{
    public class EditModel : PageModel
    {
        private readonly FireDepartmentManager.Data.FireDepartmentManagerContext _context;

        public EditModel(FireDepartmentManager.Data.FireDepartmentManagerContext context)
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

            var firefighter =  await _context.FireFighter.FirstOrDefaultAsync(m => m.Id == id);
            if (firefighter == null)
            {
                return NotFound();
            }
            FireFighter = firefighter;
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

            _context.Attach(FireFighter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FireFighterExists(FireFighter.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FireFighterExists(int id)
        {
          return (_context.FireFighter?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
