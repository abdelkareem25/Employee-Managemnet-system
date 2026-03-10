# mployee_Managemnet_API

A simple and clean **ASP.NET Core Web API** built to manage employees inside a company.
This project demonstrates backend development fundamentals including **API design, Entity Framework Core, LINQ queries, validation, and clean architecture practices**.

The goal of this project is to showcase practical backend development skills expected from a **Junior .NET Developer**.

---

# Project Overview

This API allows users to manage employees through a set of RESTful endpoints.

Main features include:

* Create employees
* Retrieve employee data
* Update employee information
* Delete employees
* Search employees using filters
* Structured error handling
* Clean code practices

---

# Technologies Used

* **.NET 8 Web API**
* **Entity Framework Core**
* **SQL Server / LocalDB**
* **LINQ**
* **REST API Principles**

Additional architecture patterns used:

* Repository Pattern
* DTO (Data Transfer Objects)
* AutoMapper
* FluentValidation
* Global Exception Handling Middleware

---

# Project Structure

The project follows a clean and modular structure:

```
EmployeeManagement
│
├── API
│   ├── Controllers
│   ├── Middleware
│
├── Core
│   ├── Entities
│   ├── DTOs
│   ├── Interfaces
│
├── Repository
│   ├── Data
│   ├── Repositories
│
└── Program.cs
```

This separation helps keep the code **maintainable, testable, and scalable**.

---

# Employee Entity

The Employee model contains the following properties:

| Property   | Type     |
| ---------- | -------- |
| Id         | int      |
| FullName   | string   |
| Email      | string   |
| Phone      | string   |
| Department | string   |
| Salary     | decimal  |
| HireDate   | DateTime |

---

# API Endpoints

### Get All Employees

```
GET /api/employees
```

Returns a list of all employees.

---

### Get Employee By Id

```
GET /api/employees/{id}
```

Returns a single employee by Id.

---

### Create Employee

```
POST /api/employees
```

Creates a new employee.

---

### Update Employee

```
PUT /api/employees/{id}
```

Updates employee information.

---

### Delete Employee

```
DELETE /api/employees/{id}
```

Removes an employee from the system.

---

# Search Endpoint

Employees can be filtered using query parameters.

Example:

```
GET /api/employees/search?department=IT&minSalary=3000
```

Filters employees by department and minimum salary using LINQ queries.

---

# Error Handling

The API uses **global exception handling middleware** to return consistent JSON responses when errors occur.

Example response:

```json
{
  "statusCode": 500,
  "message": "An unexpected error occurred"
}
```

---

# Running the Project

### 1 Clone the repository

```
git clone https://github.com/yourusername/EmployeeManagementAPI.git
```

### 2 Open the solution in Visual Studio

### 3 Apply migrations

```
update-database
```

### 4 Run the project

The API will run using **Swagger UI** for testing endpoints.

---

# Testing the API

You can test the API using:

* Swagger
* Postman

---

# What I Learned From This Project

* Building RESTful APIs with .NET
* Working with Entity Framework Core
* Implementing Repository Pattern
* Using DTOs and AutoMapper
* Applying validation using FluentValidation
* Structuring backend projects with clean architecture principles

---

# Author

Backend Developer focused on **.NET Web API development**.
