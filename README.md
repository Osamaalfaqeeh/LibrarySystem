# 📚 Library Management System

A modern, clean-architecture-based Library Management System built with ASP.NET Core MVC.  
This project demonstrates SOLID principles, proper layering, and real-world software architecture using Entity Framework Core, Razor Views, and Identity.

---

## 🔧 Tech Stack

- **.NET 9** (ASP.NET Core MVC)
- **Entity Framework Core**
- **Razor Views**
- **Clean Architecture**
- **AutoMapper**
- **ASP.NET Identity** (Admin users only)
- **SQL Server** (EF Core Code-First)

---

## 🧠 Architecture Overview

The project follows **Clean Architecture** with proper separation of concerns:

📁 LibrarySystem.Domain
📁 LibrarySystem.Application
📁 LibrarySystem.Infrastructure
📁 LibrarySystem.Web


### ✔ Layers:

- **Domain**: Core business entities (`Book`, `Author`, `Member`, etc.)
- **Application**: DTOs, Interfaces, and Service Contracts
- **Infrastructure**: EF Core DbContext, Repositories, and Service Implementations
- **Web (Presentation)**: MVC Controllers, Razor Views, ViewModels, Authentication

---

## 📁 Core Features

### 👤 Admin User Management
- ASP.NET Identity-based login
- Admin-only access
- Add, activate, deactivate users
- Assigns "Member" role

### 👥 Member Management (Borrowers)
- Track members as domain entities (not Identity users)
- Create, update, view member profiles

### 📚 Book Management
- Create, edit, delete, list books
- Associate books with genres and authors
- Track availability (borrowed or not)

### ✍️ Author & Genre Management
- Manage authors (split names, normalized)
- Create and manage genres

### 🔁 Borrowing System
- Borrow a book (marked as unavailable)
- Return a book (availability restored)
- Track borrowing history

---

## ✅ Best Practices Applied

- Clean Architecture Structure
- SOLID Principles
- Dependency Injection Everywhere
- Repository Pattern for Data Access
- AutoMapper for DTO-Entity Mapping
- Fluent EF Core Configuration (no annotations)
- Client & Server-side Validation with Data Annotations
- Secure Admin Authentication

---

## ▶️ Getting Started

### 1. Clone the repo
```bash
git clone https://github.com/yourusername/LibrarySystem.git
cd LibrarySystem
```

### 2. Setup the Database
```bash
cd LibrarySystem.Web
dotnet ef database update
```
Make sure your connection string is set in appsettings.json.

### 3. Run the Project
```bash
dotnet run --project LibrarySystem.Web
```
Login credentials will be seeded, or you can manually create an Admin via the database.

📌 Notes

- Only Admins log into the system.
- Members (borrowers) are not Identity users — tracked separately as real-world users.

