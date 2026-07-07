# Library Management System API

The Library Management System is a  **RESTful Web API** built with **ASP.NET Core (.NET 8)** and Entity Framework Core that allows users to manage books, members, and loans in a library system.
The API supports full **CRUD operations**, uses **Entity Framework Core with SQLite** for data persistence, and is secured with **JWT Authentication and Role-Based Authorization**.

This application follows backend development with modren .NET technologies, Clean Architecture principles, SOLID design principles, Repository Pattern, Dependency Injection, and Domain-Driven Design concepts to ensure maintainability, scalability, and testability.

---

# Tech Stack

**Backend**

* C#
* ASP.NET Core Web API (.NET 8)
* Entity Framework Core
* SQLite (In-Memory Database)

**Security**

* JWT Bearer Authentication
* BCrypt password hashing

**Testing & Tools**

* Swagger (with JWT Bearer support)
* .NET CLI
* In-memory database (unit tests)

**Architecture**

* Clean Architecture
* SOLID Principles
* Repository Pattern (Implemented but never used)
* Service Layer Pattern
* Dependency Injection
* Domain-Driven Design (DDD)

---

# Features

**User Authentication & Authorization**
* Register and login with email and password
* JWT Bearer tokens protect all API endpoints
* Passwords hashed with BCrypt

**Books**
* Full CRUD — create, retrieve, update, and delete books
* Input validation using Data Annotations

**Members**
* Full CRUD — create, retrieve, update, and delete library members
* Email uniqueness validation
* Layered architecture — Controller → Service → Database

**Loans**
* Borrow a book — enforces availability and membership rules
* Return a book — updates availability automatically
* Maximum 3 active loans per member
* Full loan history per member

**General**
* Swagger UI with JWT Bearer support

**Error Handling**
* Structured error handling via `ServiceResult<T>`

---

# Project Structure

```
LibraryManagement.API
│
├── Controllers
|       AuthController.cs
|       BooksController.cs
|       LoansController.cs
|       MembersController.cs
|       WeatherForecastController.cs
│
├── Data
|       LibraryDbContext.cs
│
├── DTO
|   +---Auth
|   |       AuthResponse.cs
|   |       LoginRequest.cs
|   |       RegisterRequest.cs
|   |
|   +---Books
|   |       BookResponse.cs
|   |       CreateBookRequest.cs
|   |       UpdateBookRequest.cs
|   |
|   +---Loans
|   |       CreateLoanRequest.cs
|   |       LoanResponse.cs
|   |
|   \---Members
|           CreateMemberRequest.cs
|           MemberResponse.cs
|           UpdateMemberRequest.cs
+---Migrations
|       20260706122243_InitialCreate.cs
|       20260706122243_InitialCreate.Designer.cs
|       LibraryDbContextModelSnapshot.cs
│
+---Models
|       Book.cs
|       Loan.cs
|       LoanStatus.cs
|       Member.cs
|       Patron.cs
|       User.cs
│
├── Services
        AuthService.cs
        BookService.cs
        IAuthService.cs
        IBookService.cs
        ILoanService.cs
        IMemberService.cs
        JwtService.cs
        LoanService.cs
        MemberService.cs
        ServiceResult.cs
│
├── Program.cs
└── appsettings.json
```

---

# API Endpoints

### Authentication

| Method | Endpoint              | Description              | Auth required |
| ------ | --------------------- | ------------------------ | ------------- |
| POST   | `/api/auth/register`  | Register a new user      | No            |
| POST   | `/api/auth/login`     | Login and receive a JWT  | No            |

> All other endpoints require a valid JWT Bearer token.

### Books

| Method | Endpoint          | Description       |
| ------ | ----------------- | ----------------- |
| GET    | `/api/books`      | Get all books     |
| GET    | `/api/books/{id}` | Get book by ID    |
| POST   | `/api/books`      | Create new book |
| PUT    | `/api/books/{id}` | Update book     |
| DELETE | `/api/books/{id}` | Delete book     |

### Members

| Method | Endpoint            | Description         |
| ------ | ------------------- | ------------------- |
| GET    | `/api/members`      | Get all members     |
| GET    | `/api/members/{id}` | Get member by ID    |
| POST   | `/api/members`      | Create new member |
| PUT    | `/api/members/{id}` | Update member     |
| DELETE | `/api/members/{id}` | Delete member     |

### Loans

| Method | Endpoint                      | Description                  |
| ------ | ----------------------------- | ---------------------------- |
| GET    | `/api/loans`                  | Get all loans                |
| GET    | `/api/loans/member/{memberId}`| Get loans by member          |
| POST   | `/api/loans/borrow`           | Borrow book                |
| PUT    | `/api/loans/return/{loanId}`  | Return book                |

# Example Payloads

### Register
```json
{
  "email": "superadmin@test.com",
  "password": "SuperAdmin123",
  "role": "Admin"
}
```

### Login
```json
{
  "email": "superadmin@test.com",
  "password": "SuperAdmin123"
}
```

### Create Book
```json
{
  "title": "Malaysia Tourism",
  "author": "KPN",
  "isbn": "KPN100",
  "publicationYear": 2020,
  "category": "Magazine",
  "totalCopies": 120,
  "availableCopies": 80
}
```

### Create Member
```json
{
  "firstName": "Noor",
  "lastName": "Aminah",
  "email": "aminah@test.com",
  "phone": "0105199000"
}
```

### Borrow a Book
```json
{
  "bookId": 2,
  "memberId": 2
}
```

---

# Running the Project

### 1. Clone the repository

```bash
git clone https://github.com/sassiddhik86/LMS-LibraryManagement.API.git
```

### 2. Navigate to the proejct

```bash
cd LMS-LibraryManagement.API/LibraryManagement.API
```

### 3. Restore dependencies

```bash
dotnet restore
```

### 4. Apply database migrations (Make sure Migrations folder must have DB generated files)

```bash
dotnet ef database update or use Package Manager Console (update-database)
```

### 5. Run the API

```bash
dotnet run
```

---

# Swagger API Documentation

After running the project, open Swagger in your browser:

```
http://localhost:xxxx/swagger
```

Swagger allows to interactively test all API endpoints.

To test protected endpoints in Swagger:
1. Call `POST /api/auth/register` to create a user
2. Call `POST /api/auth/login` to get a token
3. Click the **Authorize** button and enter your token
4. All subsequent requests will include the Bearer token

---
