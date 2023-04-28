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
using Action = FireDepartmentManager.Models.Action;

namespace FireDepartmentManager.Pages.Actions
{
    public class EditModel : PageModel
    {
        private readonly FireDepartmentManager.Data.FireDepartmentManagerContext _context;

        public EditModel(FireDepartmentManager.Data.FireDepartmentManagerContext context)
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

            var action =  await _context.Action.FirstOrDefaultAsync(m => m.Id == id);
            if (action == null)
            {
                return NotFound();
            }
            Action = action;
            ViewData["FireFighters"] = _context.FireFighter.ToList();
            ViewData["Vehicles"] = _context.Vehicle.ToList();
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

            _context.Attach(Action).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActionExists(Action.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var selectedRescuers = Request.Form["Action.Rescuers"];
            if (selectedRescuers.Count > 0)
            {
                foreach (var rescuer in selectedRescuers)
                {
                    var rescuersString = string.Join(", ", selectedRescuers);
                    Action.Rescuers = rescuersString;
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        private bool ActionExists(int id)
        {
          return (_context.Action?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
