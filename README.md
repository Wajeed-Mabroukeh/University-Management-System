🎓 University Management System – ASP.NET Core Web API
<br>📌 Project Overview

The University Management System is a backend application built with ASP.NET Core Web API (.NET 6+) designed to manage course classes and student enrollment.
It is architected to serve multiple client applications, including:

-Web portals

-Mobile applications

-AI chatbot interfaces

The system follows a layered architecture with clear separation of concerns, making it scalable, testable, and easy to extend.

🏗 Architecture

This project uses a Layered Architecture approach:

-Controllers (API Layer)
-Services (Business Logic)
-DTOs (Data Transfer)
-Models (Domain Entities)
-Data (DbContext & Persistence)

Key Benefits

-Clean separation of responsibilities

-Business rules isolated from API layer

-Easily consumable by multiple client types

-Ready for future enhancements (JWT, roles, caching, etc.)

🛠 Tech Stack

-Framework: ASP.NET Core Web API (.NET 6+)

-Database: MySql 

-ORM: Entity Framework Core

-API Documentation: Swagger / OpenAPI

-Architecture Pattern: Layered Architecture

-Authentication: Basic / simulated (extendable)

✨ Features
👨‍💼 Admin Portal

Administrators can:

-Create course classes

-Define schedules, rooms, and capacity

-Prevent scheduling conflicts

-Validation Rules

-All fields are required

-Capacity must be greater than zero

-No two classes can share the same days & time

🎓 Student Portal

Students can:

-View open courses under their major

-Register for course classes

-Validation Rules

-Cannot register for a full class

-Cannot register for overlapping schedules

-Student data is loaded from the system database<br>
<br><br>
📁 Project Structure
<br>
UniversityManagementSystem<br>
│<br>
├── Controllers<br>
│   ├── AdminController.cs<br>
│   └── StudentController.cs<br>
│<br>
├── Data<br>
│   └── UniversityManagementContext.cs<br>
│<br>
├── Models<br><br>
│   ├── Course.cs<br>
│   ├── CourseClass.cs<br>
│   ├── Student.cs<br>
│   └── Enrollment.cs<br>
│<br>
├── DTOs<br>
│   ├── CourseClassDto.cs<br>
│   └── RegisterCourseDto.cs<br>
│<br>
├── Services<br>
│   ├── ICourseService.cs<br>
│   ├── CourseService.cs<br>
│   ├── IStudentService.cs<br>
│   └── StudentService.cs<br>
│<br>
├── Program.cs<br>
└── appsettings.json<br>
<br>
🚀 Getting Started<br>
1️⃣ Clone the Repository<br>
git clone https://github.com/Wajeed-Mabroukeh/University-Management-System.git<br>
cd universitymanagement<br>

2️⃣ Restore Dependencies<br>
dotnet restore<br>

3️⃣ Run Database Migrations<br>
dotnet ef database update<br>

4️⃣ Run the Application<br>
dotnet run<br>

5️⃣ Open Swagger<br>
https://localhost:{port}/swagger<br>

🔌 API Endpoints (Summary)<br>
Admin<br>

POST /api/admin/course-class<br>
Create a new course class<br>

Student<br>

GET /api/student/courses/{major}<br>
Get open courses by major<br>

POST /api/student/register<br>
Register student in a course class<br>

🧪 Validation & Business Rules<br>

Schedule conflict detection using time overlap logic<br>

Capacity enforcement before enrollment<br>

Clean exception handling with meaningful error messages<br>

🔮 Future Enhancements<br>

JWT Authentication & Authorization<br>

Role-based access control (Admin / Student)<br>

Unit & integration testing<br>

Frontend UI (React)<br>

AI chatbot integration endpoints<br>

Docker support<br>

👨‍💻 Author<br>

Wajeed Mabroukeh<br>
Backend Developer – ASP.NET Core<br>
