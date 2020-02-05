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
    public class IndexModel : PageModel
    {
        private readonly ContosoUniveristy.Data.SchoolContext _context;

        public IndexModel(ContosoUniveristy.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Student> Students { get;set; }

        public async Task OnGetAsync()
        {
            Students = await _context.Student.ToListAsync();
        }
    }
}
