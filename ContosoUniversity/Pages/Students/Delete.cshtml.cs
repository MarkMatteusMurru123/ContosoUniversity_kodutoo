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
    public class DeleteModel : PageModel
    {
        private readonly ContosoUniveristy.Data.SchoolContext _context;

        public DeleteModel(ContosoUniveristy.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Students = await _context.Student.FindAsync(id);

            if (Students != null)
            {
                _context.Student.Remove(Students);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
