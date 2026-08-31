# Student Performance Portal

A web-based academic management system built using ASP.NET Core Razor Pages and MySQL. The application provides a centralized platform for managing student information, courses, faculty, marks, and attendance, along with a dynamic dashboard for monitoring academic performance.

## Project Overview

The Student Performance Portal is designed to simplify academic information management by bringing multiple academic activities into a single web application.

The system allows administrators or academic staff to:

- Manage student records
- View courses and departments
- View faculty information
- Monitor examination marks
- Monitor student attendance
- Identify students with attendance below 75%
- View key academic statistics through a centralized dashboard

The application uses Entity Framework Core to communicate with a MySQL database, making the displayed information dynamic and persistent.

## Key Features

### 1. Student Management

The student management module supports complete CRUD operations:

- Add new students
- View all students
- Edit student information
- Delete student records
- Store student information in the database

### 2. Academic Dashboard

The dashboard provides a centralized overview of the academic system.

It dynamically displays:

- Total number of students
- Total faculty members
- Total courses
- Total departments
- Average examination performance
- Overall attendance percentage
- Number of students with attendance below 75%

The dashboard also provides quick navigation to the major modules.

### 3. Course Management

The Courses module displays available academic courses and their associated information.

### 4. Faculty Management

The Faculty module displays faculty members along with their departments and contact information.

### 5. Marks Management

The Marks module displays:

- Student name
- Course
- Marks obtained
- Maximum marks
- Percentage
- Examination type
- Examination date

The percentage is calculated dynamically from the stored marks.

### 6. Attendance Management

The Attendance module displays:

- Student name
- Course
- Attendance date
- Attendance status

Attendance status is clearly represented as Present or Absent.

### 7. At-Risk Student Identification

The dashboard calculates individual student attendance percentages and identifies students whose attendance falls below 75%.

This provides an early indicator for students who may require academic attention.

## Technology Stack

| Technology | Purpose |
|---|---|
| C# | Application programming language |
| ASP.NET Core | Web application framework |
| Razor Pages | UI and page-based application architecture |
| Entity Framework Core | ORM and database interaction |
| MySQL | Relational database |
| HTML | Page structure |
| CSS | Styling |
| Bootstrap | Responsive UI components |
| Visual Studio | Development environment |

## Architecture

The project follows the ASP.NET Core Razor Pages architecture.

### Pages

Contains the application's user interface and page handlers.

```text
Pages/
├── Attendance/
├── Courses/
├── Faculty/
├── Marks/
├── Students/
├── Shared/
├── Dashboard.cshtml
└── Index.cshtml
Models

Contains the application's entity classes representing database tables.

Models/
├── Student.cs
├── Course.cs
├── Faculty.cs
├── Department.cs
├── Mark.cs
└── Attendance.cs
Data

Contains the Entity Framework Core database context.

Data/
└── ApplicationDbContext.cs
Program.cs

Configures the ASP.NET Core application, services, middleware, routing, and Razor Pages.

Database Design

The application uses a relational MySQL database with entities representing:

Students
Departments
Courses
Faculty
Marks
Attendance
Enrollments

Entity Framework Core manages relationships between these entities and provides database access through ApplicationDbContext.

Dynamic Dashboard

The dashboard is database-driven rather than relying on hardcoded statistics.

For example, the application dynamically calculates:

Total Students
Total Faculty
Total Courses
Total Departments
Average Marks
Overall Attendance Percentage
At-Risk Students

This ensures that dashboard statistics automatically reflect changes made to the underlying database.

Student CRUD Operations

The student module implements the four fundamental CRUD operations:

Create  → Add a student
Read    → View students
Update  → Edit student information
Delete  → Remove a student

Changes are persisted to the MySQL database through Entity Framework Core.

Project Structure
StudentPerformancePortal/
│
├── Data/
│   └── ApplicationDbContext.cs
│
├── Models/
│   ├── Attendance.cs
│   ├── Course.cs
│   ├── Department.cs
│   ├── Enrollment.cs
│   ├── Faculty.cs
│   ├── Mark.cs
│   └── Student.cs
│
├── Pages/
│   ├── Attendance/
│   │   ├── Index.cshtml
│   │   └── Index.cshtml.cs
│   │
│   ├── Courses/
│   │   ├── Index.cshtml
│   │   └── Index.cshtml.cs
│   │
│   ├── Faculty/
│   │   ├── Index.cshtml
│   │   └── Index.cshtml.cs
│   │
│   ├── Marks/
│   │   ├── Index.cshtml
│   │   └── Index.cshtml.cs
│   │
│   ├── Students/
│   │   ├── Create.cshtml
│   │   ├── Create.cshtml.cs
│   │   ├── Delete.cshtml
│   │   ├── Delete.cshtml.cs
│   │   ├── Edit.cshtml
│   │   ├── Edit.cshtml.cs
│   │   ├── Index.cshtml
│   │   └── Index.cshtml.cs
│   │
│   ├── Shared/
│   │   ├── _Layout.cshtml
│   │   └── _ValidationScriptsPartial.cshtml
│   │
│   ├── Dashboard.cshtml
│   ├── Dashboard.cshtml.cs
│   ├── Index.cshtml
│   └── Index.cshtml.cs
│
├── wwwroot/
│   ├── css/
│   ├── js/
│   └── lib/
│
├── appsettings.json
├── Program.cs
├── StudentPerformancePortal.csproj
└── README.md
How to Run the Project
Prerequisites

Make sure the following are installed:

.NET SDK
Visual Studio
MySQL Server
MySQL Workbench
Setup
Clone the repository.
Open the .sln or .csproj file in Visual Studio.
Configure the MySQL connection string in:
appsettings.json
Restore NuGet packages.
Build the solution.
Apply Entity Framework Core migrations if required.
Run the application using Visual Studio.

The application will open in the browser.

Entity Framework Core

The project uses Entity Framework Core for database operations.

Typical migration commands include:

dotnet ef migrations add InitialCreate
dotnet ef database update

These commands create and update the database schema based on the application's entity models.

Validation and Testing

The application was tested for:

Successful project build
Database connectivity
Homepage loading
Dashboard statistics
Student creation
Student editing
Student deletion
Course listing
Faculty listing
Marks listing
Attendance listing
Dynamic database-driven statistics
Future Enhancements

The following features can be added in future versions:

User authentication and authorization
Role-based access for administrators, faculty, and students
Student login portal
Faculty login portal
Add/edit attendance functionality
Add/edit marks functionality
Search and filtering
Pagination
Academic performance charts
Student-wise performance reports
PDF report generation
Excel report export
Email notifications for low attendance
Advanced performance analytics
Learning Outcomes

This project provided practical experience in:

ASP.NET Core development
Razor Pages
C# programming
Entity Framework Core
MySQL database integration
CRUD operations
Relational database design
Database-driven web applications
Dynamic data rendering
Basic academic performance analytics
Responsive web interface development
Author

Developed as an academic project using ASP.NET Core, C#, Entity Framework Core, MySQL, HTML, CSS, and Bootstrap.