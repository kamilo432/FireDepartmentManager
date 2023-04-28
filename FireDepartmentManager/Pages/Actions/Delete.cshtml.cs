using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FireDepartmentManager.Data;
using FireDepartmentManager.Models;
using Action = FireDepartmentManager.Models.Action;

namespace FireDepartmentManager.Pages.Actions
{
    public class DeleteModel : PageModel
    {
        private readonly FireDepartmentManager.Data.FireDepartmentManagerContext _context;

        public DeleteModel(FireDepartmentManager.Data.FireDepartmentManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Action Action { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Action == null)
            {
                return NotFound();
            }

            var action = await _context.Action.FirstOrDefaultAsync(m => m.Id == id);

            if (action == null)
            {
                return NotFound();
            }
            else 
            {
                Action = action;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Action == null)
            {
                return NotFound();
            }
            var action = await _context.Action.FindAsync(id);

            if (action != null)
            {
                Action = action;
                _context.Action.Remove(Action);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
