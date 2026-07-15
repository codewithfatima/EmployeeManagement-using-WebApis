## Getting started

### Prerequisites

- .NET 8 SDK
- SQL Server (LocalDB or full instance)

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

## Project structure Setup
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


1. Clone the repository
```bash
   git clone https://github.com/codewithfatima/StudentManagment.git
```
2. Update the connection string in `appsettings.json`
3. Run migrations
```bash
   dotnet ef database update
```
4. Run the project
```bash
   dotnet run
```
5. Open Swagger at `https://localhost:PORT/swagger`

## API endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/Students` | Get all students |
| GET | `/api/Students/{id}` | Get student by id |
| GET | `/api/Students/paged` | Get paginated students |
| GET | `/api/Students/search` | Search and filter students |
| POST | `/api/Students` | Create a student |
| PUT | `/api/Students/{id}` | Update a student |
| DELETE | `/api/Students/{id}` | Delete a student |
| POST | `/api/Students/{id}/upload-picture` | Upload profile picture |
| GET | `/api/Book` | Get all books |
| POST | `/api/Book` | Create a book |
| DELETE | `/api/Book/{id}` | Delete a book |
| POST | `/api/Auth/register` | Register a new user |
| POST | `/api/Auth/login` | Log in and receive a JWT token |

## Author

Built by [Fatima](https://github.com/codewithfatima) as a learning and portfolio project.
