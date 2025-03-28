# First Web API Project

A .NET Web API project using ASP.NET Core.

## Prerequisites

- .NET 9.0 SDK
- Visual Studio Code or Visual Studio 2022
- Git

## Getting Started

### Clone the Repository

```bash
git clone https://github.com/YOUR-USERNAME/first-web-api.git
cd first-web-api
```

### Install Dependencies

```bash
dotnet restore
```

### Run the Application

#### Using .NET CLI
```bash
dotnet run
```

The API will be available at:
- HTTP: http://localhost:5247
- HTTPS: https://localhost:7276

#### Using Visual Studio Code
1. Open the project in VS Code
2. Press `F5` or use the Run and Debug menu
3. Select the ".NET Core Launch (web)" configuration

## Project Structure

```
first-web-api/
├── Controllers/
│   ├── AuthController.cs
│   ├── DepartmentController.cs
│   └── StudentController.cs
├── Models/
│   ├── ApplicationUser.cs
│   ├── Department.cs
│   ├── Student.cs
│   ├── JWT.cs
│   └── IType.cs
├── DTOs/
│   ├── AuthDTO/
│   │   └── AuthDTO.cs
│   ├── DepartmentDTO/
│   │   └── DepartmentDTOs.cs
│   └── StudentDTO/
│       └── StudentsDTOs.cs
├── Context/
│   └── SDbContext.cs
├── Data/
│   └── Migrations/
├── Filters/
│   ├── HeaderResultFilterAttribute.cs
│   └── ValidateLocationFilterAttribute.cs
├── Repositories/
│   ├── Repository.cs
│   ├── DepartmentRepository.cs
│   └── StudentRepository.cs
├── Services/
│   ├── AuthService.cs
│   ├── DepartmentService.cs
│   └── StudentService.cs
└── Validations/
    └── UniqueDeptName.cs
```

## Features

- JWT Authentication with Identity
- Role-based Authorization (Admin/Student)
- CRUD operations for Students and Departments
- Generic Repository Pattern
- Custom Filters and Validations
- DTOs for data transfer
- Entity Framework Core with SQL Server

## Authentication

The API uses JWT (JSON Web Tokens) for authentication with two roles:
- Admin: Full access (add, edit, delete)
- Student: Limited access (view details, edit own info)

Default admin credentials:
- Email: admin@admin.com
- Password: Admin123!

## Configuration

Environment-specific settings can be found in:
- `appsettings.json`
- `appsettings.Development.json`

Key configuration includes:
- Database connection string
- JWT settings (key, issuer, audience, duration)