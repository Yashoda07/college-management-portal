using StudentPerformancePortal.Models;

namespace StudentPerformancePortal.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Departments
            if (!context.Departments.Any())
            {
                context.Departments.AddRange(
                    new Department { DepartmentName = "Computer Science" },
                    new Department { DepartmentName = "Information Technology" },
                    new Department { DepartmentName = "Business Administration" },
                    new Department { DepartmentName = "Data Science" }
                );

                context.SaveChanges();
            }

            // Faculty
            if (!context.Faculty.Any())
            {
                var departments = context.Departments.ToList();

                context.Faculty.AddRange(
                    new Faculty
                    {
                        FacultyName = "Dr. Rahul Sharma",
                        Email = "rahul.sharma@college.com",
                        DepartmentId = departments[0].DepartmentId
                    },
                    new Faculty
                    {
                        FacultyName = "Dr. Priya Mehta",
                        Email = "priya.mehta@college.com",
                        DepartmentId = departments[1].DepartmentId
                    },
                    new Faculty
                    {
                        FacultyName = "Prof. Amit Patel",
                        Email = "amit.patel@college.com",
                        DepartmentId = departments[2].DepartmentId
                    },
                    new Faculty
                    {
                        FacultyName = "Dr. Neha Kapoor",
                        Email = "neha.kapoor@college.com",
                        DepartmentId = departments[3].DepartmentId
                    }
                );

                context.SaveChanges();
            }

            // Courses
            if (!context.Courses.Any())
            {
                var departments = context.Departments.ToList();
                var faculty = context.Faculty.ToList();

                context.Courses.AddRange(
                    new Course
                    {
                        CourseCode = "CS101",
                        CourseName = "Programming Fundamentals",
                        Credits = 4,
                        DepartmentId = departments[0].DepartmentId,
                        FacultyId = faculty[0].FacultyId
                    },
                    new Course
                    {
                        CourseCode = "IT201",
                        CourseName = "Database Management Systems",
                        Credits = 4,
                        DepartmentId = departments[1].DepartmentId,
                        FacultyId = faculty[1].FacultyId
                    },
                    new Course
                    {
                        CourseCode = "BA301",
                        CourseName = "Business Analytics",
                        Credits = 3,
                        DepartmentId = departments[2].DepartmentId,
                        FacultyId = faculty[2].FacultyId
                    },
                    new Course
                    {
                        CourseCode = "DS401",
                        CourseName = "Data Analytics",
                        Credits = 4,
                        DepartmentId = departments[3].DepartmentId,
                        FacultyId = faculty[3].FacultyId
                    }
                );

                context.SaveChanges();
            }

            // Students
            if (!context.Students.Any())
            {
                var departments = context.Departments.ToList();

                context.Students.AddRange(
                    new Student
                    {
                        StudentNumber = "STU001",
                        FirstName = "Aarav",
                        LastName = "Shah",
                        Email = "aarav.shah@college.com",
                        Phone = "9876543210",
                        DateOfBirth = new DateTime(2005, 4, 12),
                        Gender = "Male",
                        DepartmentId = departments[0].DepartmentId,
                        AdmissionYear = 2023
                    },
                    new Student
                    {
                        StudentNumber = "STU002",
                        FirstName = "Ananya",
                        LastName = "Patel",
                        Email = "ananya.patel@college.com",
                        Phone = "9876543211",
                        DateOfBirth = new DateTime(2005, 7, 20),
                        Gender = "Female",
                        DepartmentId = departments[1].DepartmentId,
                        AdmissionYear = 2023
                    },
                    new Student
                    {
                        StudentNumber = "STU003",
                        FirstName = "Rohan",
                        LastName = "Mehta",
                        Email = "rohan.mehta@college.com",
                        Phone = "9876543212",
                        DateOfBirth = new DateTime(2004, 11, 5),
                        Gender = "Male",
                        DepartmentId = departments[2].DepartmentId,
                        AdmissionYear = 2022
                    },
                    new Student
                    {
                        StudentNumber = "STU004",
                        FirstName = "Isha",
                        LastName = "Sharma",
                        Email = "isha.sharma@college.com",
                        Phone = "9876543213",
                        DateOfBirth = new DateTime(2005, 2, 18),
                        Gender = "Female",
                        DepartmentId = departments[3].DepartmentId,
                        AdmissionYear = 2023
                    },
                    new Student
                    {
                        StudentNumber = "STU005",
                        FirstName = "Kabir",
                        LastName = "Joshi",
                        Email = "kabir.joshi@college.com",
                        Phone = "9876543214",
                        DateOfBirth = new DateTime(2004, 9, 30),
                        Gender = "Male",
                        DepartmentId = departments[0].DepartmentId,
                        AdmissionYear = 2022
                    }
                );

                context.SaveChanges();
            }

            // Enrollments
            if (!context.Enrollments.Any())
            {
                var students = context.Students.ToList();
                var courses = context.Courses.ToList();

                foreach (var student in students)
                {
                    foreach (var course in courses)
                    {
                        context.Enrollments.Add(new Enrollment
                        {
                            StudentId = student.StudentId,
                            CourseId = course.CourseId,
                            EnrollmentDate = DateTime.Now.AddMonths(-6),
                            AcademicYear = "2025-26",
                            Semester = 5
                        });
                    }
                }

                context.SaveChanges();
            }

            // Marks
            if (!context.Marks.Any())
            {
                var students = context.Students.ToList();
                var courses = context.Courses.ToList();

                var random = new Random(10);

                foreach (var student in students)
                {
                    foreach (var course in courses)
                    {
                        context.Marks.Add(new Mark
                        {
                            StudentId = student.StudentId,
                            CourseId = course.CourseId,
                            MarksObtained = random.Next(45, 96),
                            MaximumMarks = 100,
                            ExamType = "End Semester",
                            ExamDate = DateTime.Now.AddMonths(-1)
                        });
                    }
                }

                context.SaveChanges();
            }

            // Attendance
            if (!context.Attendance.Any())
            {
                var students = context.Students.ToList();
                var courses = context.Courses.ToList();

                var random = new Random(20);

                foreach (var student in students)
                {
                    foreach (var course in courses)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            context.Attendance.Add(new Attendance
                            {
                                StudentId = student.StudentId,
                                CourseId = course.CourseId,
                                AttendanceDate = DateTime.Now.AddDays(-i),
                                Status = random.Next(1, 101) <= 85
                                    ? "Present"
                                    : "Absent"
                            });
                        }
                    }
                }

                context.SaveChanges();
            }
        }
    }
}