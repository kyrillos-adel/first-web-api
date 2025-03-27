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
│   ├── DepartmentController.cs
│   └── StudentController.cs
├── Models/
├── DTOs/
│   ├── DepartmentDTO/
│   └── StudentDTO/
├── Context/
│   └── SDbContext.cs
├── Filters/
├── Repositories/
├── Services/
└── Validations/
```

## Configuration

Environment-specific settings can be found in:
- `appsettings.json`
- `appsettings.Development.json`