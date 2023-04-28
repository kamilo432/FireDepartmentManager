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
    public class IndexModel : PageModel
    {
        private readonly FireDepartmentManager.Data.FireDepartmentManagerContext _context;

        public IndexModel(FireDepartmentManager.Data.FireDepartmentManagerContext context)
        {
            _context = context;
        }

        public IList<FireFighter> FireFighter { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.FireFighter != null)
            {
                FireFighter = await _context.FireFighter.ToListAsync();
            }
        }
    }
}
