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
            context.Database.EnsureCreated();
            if (context.Students.Any())
            {
                return;
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
                context.Student.Add(s);
            }
            context.SaveChanges();
            var courses = new Course[]
            {
                new Course {CourseID = 1702, Title = "Web Applications", Credits = 12},
                new Course {CourseID = 3002, Title = "Basics of Physical Movement", Credits = 3},
                new Course {CourseID = 0150, Title = "Economics", Credits = 6},
                new Course {CourseID = 1615, Title = "Data Processing", Credits = 6},
                new Course {CourseID = 1708, Title = "IT Operations", Credits = 6},
                new Course {CourseID = 0153, Title = "Accounting", Credits = 6},
                new Course {CourseID = 1618, Title = "Calculus", Credits = 6}

            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();
            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentID=1,CourseID=1702,Grade=Grade.A},
                new Enrollment{StudentID=1,CourseID=3002,Grade=Grade.A},
                new Enrollment{StudentID=1,CourseID=0150,Grade=Grade.B},
                new Enrollment{StudentID=2,CourseID=3002,Grade=Grade.B},
                new Enrollment{StudentID=2,CourseID=0150,Grade=Grade.A},
                new Enrollment{StudentID=2,CourseID=1615,Grade=Grade.C},
                new Enrollment{StudentID=3,CourseID=1050},
                new Enrollment{StudentID=4,CourseID=1050},
                new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
                new Enrollment{StudentID=5,CourseID=1708,Grade=Grade.C},
                new Enrollment{StudentID=6,CourseID=1045},
                new Enrollment{StudentID=7,CourseID=1702,Grade=Grade.F},
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }



    }
}

