using FireDepartmentManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FireDepartmentManager.Pages.Stats
{
    public class IndexModel : PageModel
    {
        private readonly FireDepartmentManager.Data.FireDepartmentManagerContext _context;

        public IndexModel(FireDepartmentManager.Data.FireDepartmentManagerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            int numActions = _context.Action.Count();
            int numActionFire = _context.Action.Count(a => a.TypeOfAction == TypeOfAction.Fire);
            int numActionLocalDanger = _context.Action.Count(a => a.TypeOfAction == TypeOfAction.LocalDanger);
            int numActionFake = _context.Action.Count(a => a.TypeOfAction == TypeOfAction.Fake);
            ViewData["NumActions"] = numActions;
            ViewData["numActionFire"] = numActionFire;
            ViewData["numActionLocalDanger"] = numActionLocalDanger;
            ViewData["numActionFake"] = numActionFake;

            int numVehicles = _context.Vehicle.Count();
            ViewData["NumVehicles"] = numVehicles;

            int numFirefighters = _context.FireFighter.Count();
            int numFirefightersFa = _context.FireFighter.Where(f => f.FirstAID == true).Count();
            int numFirefightersDriver = _context.FireFighter.Where(f => f.Driver == true).Count();
            int numFirefightersCommander = _context.FireFighter.Where(f => f.Commander == true).Count();
            ViewData["NumFirefighters"] = numFirefighters;
            ViewData["numFirefightersFa"] = numFirefightersFa;
            ViewData["numFirefightersDriver"] = numFirefightersDriver;
            ViewData["numFirefightersCommander"] = numFirefightersCommander;

            return Page();
        }
    }
}
