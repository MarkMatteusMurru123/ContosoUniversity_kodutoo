using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniveristy.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity
{
    public class DetailsModel : PageModel
    {
        private readonly ContosoUniveristy.Data.SchoolContext _context;

        public DetailsModel(ContosoUniveristy.Data.SchoolContext context)
        {
            _context = context;
        }

        public Student Students { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Students = await _context.Student.FirstOrDefaultAsync(m => m.ID == id);

            if (Students == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
