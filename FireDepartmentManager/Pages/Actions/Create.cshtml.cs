using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FireDepartmentManager.Data;
using FireDepartmentManager.Models;
using Action = FireDepartmentManager.Models.Action;

namespace FireDepartmentManager.Pages.Actions
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
            ViewData["FireFighters"] = _context.FireFighter.ToList();
            ViewData["Vehicles"] = _context.Vehicle.ToList();

            return Page();
        }

        [BindProperty]
        public Action Action { get; set; } = default!;



        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Action == null || Action == null)
            {
                return Page();
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
            _context.Action.Add(Action);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
