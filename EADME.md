### # Student Management API

A RESTful Web API built with ASP.NET Core for managing students, departments, and books, with JWT authentication.

## Features

- Full CRUD for Students, Departments, Books, and Authors
- One-to-many relationships (Student–Department, Book–Author) with Entity Framework Core
- Pagination, searching, and filtering
- Global exception handling middleware
- Structured logging
- File upload (student profile pictures)
- JWT authentication with ASP.NET Core Identity (Register, Login)
- Swagger API documentation with XML comments

## Tech stack

- **Backend:** ASP.NET Core Web API (.NET 8)
- **Database:** SQL Server, Entity Framework Core
- **Auth:** ASP.NET Core Identity, JWT Bearer tokens
- **Architecture:** Layered (Controller → Service → Repository)
- **Docs:** Swagger / Swashbuckle

## Project structure
StudentManagment/
├── Controllers/
├── Models/
├── DTOs/
├── Interfaces/
├── Repositories/
├── Service/
├── Middleware/
├── Data/
└── Migrations/
