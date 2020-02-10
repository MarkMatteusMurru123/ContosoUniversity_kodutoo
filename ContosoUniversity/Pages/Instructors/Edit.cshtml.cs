using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniveristy.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Instructors
{
    public class EditModel : InstructorCoursesPageModel
    {
        private readonly ContosoUniveristy.Data.SchoolContext _context;

        public EditModel(ContosoUniveristy.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty] public Instructor Instructor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Instructor = await _context.Instructors.Include(i => i.OfficeAssignment)
                .Include(i => i.CourseAssignments).ThenInclude(i => i.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Instructor == null)
            {
                return NotFound();
            }

            PopulateAssignedCourseData(_context, Instructor); //Calls PopulateAssignedCourseData in OnGetAsync to provide information for the checkboxes using the AssignedCourseData view model class.
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCourses)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructorToUpdate = await _context.Instructors
                .Include(i => i.OfficeAssignment).Include(i => i.CourseAssignments).ThenInclude(i => i.Course)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (instructorToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Instructor>( //Gets the current Instructor entity from the database using eager loading for the OfficeAssignment, CourseAssignment, and CourseAssignment.Course navigation properties.
                                                         //Updates the retrieved Instructor entity with values from the model binder.TryUpdateModel prevents overposting.
                instructorToUpdate,
                "Instructor",
                i => i.FirstMidName, i => i.LastName,
                i => i.HireDate, i => i.OfficeAssignment))
            {
                if (String.IsNullOrWhiteSpace( //If the office location is blank, sets Instructor.OfficeAssignment to null. When Instructor.OfficeAssignment is null, the related row in the OfficeAssignment table is deleted.
                    instructorToUpdate.OfficeAssignment?.Location))
                {
                    instructorToUpdate.OfficeAssignment = null;
                }

                UpdateInstructorCourses(_context, selectedCourses, instructorToUpdate); //Calls UpdateInstructorCourses in OnPostAsync to apply information from the checkboxes to the Instructor entity being edited.
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateInstructorCourses(_context, selectedCourses, instructorToUpdate); //Calls PopulateAssignedCourseData and UpdateInstructorCourses in OnPostAsync if TryUpdateModel fails. These method calls restore the assigned course data entered on the page when it is redisplayed with an error message.
            PopulateAssignedCourseData(_context, instructorToUpdate);
            return Page();

        }
    }
}
