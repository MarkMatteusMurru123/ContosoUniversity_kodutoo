using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniveristy.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Data
{
    public class DbInitializer
    { 
        
        public static void Initialize(SchoolContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student
                {
                    FirstMidName = "Mark Matteus", LastName = "Murru", EnrollmentDate = DateTime.Parse("2019-08.20")
                },
                new Student
                {
                    FirstMidName = "Madli", LastName = "Kaevats", EnrollmentDate = DateTime.Parse("2019-08.20")
                },
                new Student {FirstMidName = "Hugo", LastName = "Valk", EnrollmentDate = DateTime.Parse("2019-08.20")},
                new Student
                {
                    FirstMidName = "Johann", LastName = "Kuldmäe", EnrollmentDate = DateTime.Parse("2017-08.20")
                },
                new Student {FirstMidName = "Elise", LastName = "Lomp", EnrollmentDate = DateTime.Parse("2019-08.20")},
                new Student {FirstMidName = "Toru", LastName = "Jüri", EnrollmentDate = DateTime.Parse("2012-04.12")},
                new Student {FirstMidName = "Sammal", LastName = "Habe", EnrollmentDate = DateTime.Parse("2013-03.14")},
                new Student {FirstMidName = "Nipi", LastName = "Tiri", EnrollmentDate = DateTime.Parse("2010-02.18")}

            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();
            var instructors = new Instructor[]
            {
                new Instructor { FirstMidName = "Kim",     LastName = "Abercrombie",
                    HireDate = DateTime.Parse("1995-03-11") },
                new Instructor { FirstMidName = "Fadi",    LastName = "Fakhouri",
                    HireDate = DateTime.Parse("2002-07-06") },
                new Instructor { FirstMidName = "Roger",   LastName = "Harui",
                    HireDate = DateTime.Parse("1998-07-01") },
                new Instructor { FirstMidName = "Candace", LastName = "Kapoor",
                    HireDate = DateTime.Parse("2001-01-15") },
                new Instructor { FirstMidName = "Roger",   LastName = "Zheng",
                    HireDate = DateTime.Parse("2004-02-12") }
            };

            foreach (Instructor i in instructors)
            {
                context.Instructors.Add(i);
            }
            context.SaveChanges();
            var departments = new Department[]
            {
                new Department { Name = "Information Technology",     Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Abercrombie").ID },
                new Department { Name = "Mathematics", Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Fakhouri").ID },
                new Department { Name = "Engineering", Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Harui").ID },
                new Department { Name = "Economics",   Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Kapoor").ID }
            };

            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();
            var courses = new Course[]
            {
                new Course {CourseID = 1702, Title = "Web Applications", Credits = 12, DepartmentID = departments.Single( s => s.Name == "Information Technology").DepartmentID},
                new Course {CourseID = 0150, Title = "Economics", Credits = 6,DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID},
                new Course {CourseID = 1615, Title = "Data Processing", Credits = 6,DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID},
                new Course {CourseID = 1708, Title = "IT Operations", Credits = 6,DepartmentID = departments.Single( s => s.Name == "Information Technology").DepartmentID},
                new Course {CourseID = 0153, Title = "Accounting", Credits = 6,DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID},
                new Course {CourseID = 1618, Title = "Calculus", Credits = 6,DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID}

            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();
            var officeAssignments = new OfficeAssignment[]
            {
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Fakhouri").ID,
                    Location = "Smith 17" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Harui").ID,
                    Location = "Gowan 27" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Kapoor").ID,
                    Location = "Thompson 304" },
            };

            foreach (OfficeAssignment o in officeAssignments)
            {
                context.OfficeAssignments.Add(o);
            }
            context.SaveChanges();
            var courseInstructors = new CourseAssignment[]
           {
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Web Applications" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Kapoor").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Web Applications" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Harui").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Zheng").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Economics" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Zheng").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Fakhouri").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "IT Operations" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Harui").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Data Processing" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Abercrombie").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Economics" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Abercrombie").ID
                    },
           };

            foreach (CourseAssignment ci in courseInstructors)
            {
                context.CourseAssignments.Add(ci);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Valk").ID,
                    CourseID = courses.Single(c => c.Title == "Economics" ).CourseID,
                    Grade = Grade.A
                },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Lomp").ID,
                    CourseID = courses.Single(c => c.Title == "Web Applications" ).CourseID,
                    Grade = Grade.C
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Kuldmäe").ID,
                    CourseID = courses.Single(c => c.Title == "Web Applications" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Kaevats").ID,
                    CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Kaevats").ID,
                    CourseID = courses.Single(c => c.Title == "Data Processing" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Murru").ID,
                    CourseID = courses.Single(c => c.Title == "IT Operations" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Tiri").ID,
                    CourseID = courses.Single(c => c.Title == "IT Operations" ).CourseID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Habe").ID,
                    CourseID = courses.Single(c => c.Title == "Economics").CourseID,
                    Grade = Grade.B
                    },
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Habe").ID,
                    CourseID = courses.Single(c => c.Title == "Data Processing").CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Valk").ID,
                    CourseID = courses.Single(c => c.Title == "Web Applications").CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Murru").ID,
                    CourseID = courses.Single(c => c.Title == "Web Applications").CourseID,
                    Grade = Grade.B
                    }
 };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                        s.Student.ID == e.StudentID &&
                        s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }




    }
}

