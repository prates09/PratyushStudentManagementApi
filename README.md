# Pratyush Student Management API

This project is a simple **ASP.NET Core Web API** built for managing student information.  
It follows the **CQRS (Command Query Responsibility Segregation)** pattern and uses the **Mediator** pattern through MediatR.  
All data is stored **in memory**, making the API easy to run and test without any database setup.

---

## 🚀 Features

- Add new students  
- Update existing student details  
- Delete a student  
- Retrieve all students  
- Retrieve a single student by ID  
- Clean CQRS architecture with MediatR  
- In-memory data storage

---

## 🧩 Tech Stack

- **ASP.NET Core 8 Web API**
- **C#**
- **CQRS Pattern**
- **Mediator Pattern (MediatR)**
- **In-Memory Repository**

---

## 📁 Project Structure

```text
PratyushStudentManagementApi/
│
├── Controllers/
│   └── StudentsController.cs
│
├── Data/
│   ├── IStudentData.cs
│   └── InMemoryStudentData.cs
│
├── Handlers/
│   ├── Commands/
│   │   ├── AddStudentCommand.cs
│   │   ├── UpdateStudentCommand.cs
│   │   └── DeleteStudentCommand.cs
│   │
│   └── Queries/
│       ├── GetAllStudentsQuery.cs
│       └── GetStudentByIdQuery.cs
│
├── Models/
│   └── Student.cs
│
└── Program.cs

```
---

## 🧠 Architecture Overview

### ✔ CQRS Pattern
- **Commands** → Modify data (Add, Update, Delete)  
- **Queries** → Read-only operations (Get all, Get by ID)

This separation improves clarity and maintainability.

### ✔ Mediator Pattern
All requests go through **MediatR**, keeping controllers light and routing logic clean.

---

## 🔗 API Endpoints

### ➤ Get All Students  
`GET /api/Students`

### ➤ Get Student By ID  
`GET /api/Students/{studentId}`

### ➤ Add a Student  
`POST /api/Students`

### ➤ Update a Student  
`PUT /api/Students/{studentId}`

### ➤ Delete a Student  
`DELETE /api/Students/{studentId}`

---

## ▶ How to Run

1. Clone this repository  
2. Open `PratyushStudentManagementApi.sln` in Visual Studio  
3. Restore NuGet packages  
4. Run the API (F5)  
5. Use Swagger UI to test all endpoints  

---

## 📌 Notes

- The project uses **in-memory storage**, so data resets each time the application restarts.
- Each student has a **unique StudentId**, required for update and delete operations.
- Designed as a learning/demo project for CQRS and MediatR.

---

## ✨ Author

**Pratyush Singh**  
CQRS + Mediator Student Management API  
