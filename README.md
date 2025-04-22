# TmcTrainingParticipantScoringApp


> A modular, scalable .NET 8 backend for managing training evaluations, participant scores, evaluator workflows, and reporting via secure APIs.

---

## 📘 Project Overview

This backend system was built based on initial business requirements focused on training performance evaluation:

- Admins can manage topics, users, batches, and evaluation sessions
- Evaluators can submit scores collaboratively
- Students can view their results in dashboards
- Real-time updates and downloadable PDF scorecards
- Fully decoupled domain service architecture

> ❗This solution is purely API-driven.

---

## 🧱 Solution Structure

```
TmcTrainingParticipantScoringApp/
│
├── API/                        # REST API Host (.NET 8)
│   ├── Controllers             # All HTTP API Controllers
│   ├── Extensions              # Startup/DI configurations
│
├── Application/               # Domain Logic Layer
│   ├── AdminServices
│   ├── AuthServices
│   ├── EvaluatorServices
│
├── Domain/                    # Entities & Enums
│   ├── Models                 # EF Core models
│   ├── Enums                  # Roles Enum (Admin, Evaluator, Student)
│
├── Infrastructure/           # EF Core DbContext, configs
│   ├── DataContext
│   ├── ModelConfigs
│
├── SharedServices/           # Reusable utilities
├── StudentServices/          # Student-side view services
├── Helpers/                  # Constants, DTOs, ViewModels
```

---

## ✅ Key Features

### 🔐 Authentication & Identity
- ASP.NET Core Identity w/ JWT
- Enum-based role system: `Admin`, `Evaluator`, `Student`

### 🧑‍🏫 Admin Functionality
- User management & role filtering
- Topic CRUD operations
- Evaluation session setup
- Dashboard score grid with averages
- Batch/user score export (PDF)

### ✍️ Evaluator Functionality
- Submit scores by student & topic
- Final score calculated after all evaluators submit

### 🎓 Student Functionality
- View topic-by-topic scores
- See average & overall performance

### 📡 System Features
- Real-time updates via SignalR
- PDF generation using QuestPDF
- Historical score filtering by batch

---

## 🧠 Implemented Services

| Layer             | Interface                          | Description                              |
|------------------|-------------------------------------|------------------------------------------|
| Auth             | `IAuthService`                      | Register / Login                         |
| Admin            | `IUserService`, `ITopicService`     | Manage users, topics                     |
| Admin            | `IEvaluationSessionService`         | Setup sessions and assign students       |
| Admin            | `IScoreboardService`                | Dashboard view by topic                  |
| Admin            | `IReportService`                    | Generate historical data and PDFs        |
| Evaluator        | `IEvaluationService`                | Submit and aggregate scores              |
| Student          | `IStudentDashboardService`          | View topic performance                   |
| System           | `INotificationService`              | SignalR live push                        |
| System           | `IPdfExportService`                 | Generate and stream PDFs                 |


---

## 📦 Tech Stack

- **.NET 8**
- **Entity Framework Core**
- **ASP.NET Core Identity**
- **SignalR** – Real-time dashboard updates
- **QuestPDF** – Scorecard PDF generation
- **JWT Authentication**
- **Role-based Authorization**
- **Modular Service Architecture**

---

## 🧪 Testing (Pluggable)

> Tests are not included in this commit but the architecture is cleanly layered for test injection and mocking.

---

## 🚀 Getting Started

```bash
# Setup
dotnet ef migrations add InitSchema -p Infrastructure -s API
dotnet ef database update -p Infrastructure -s API

# Run API
dotnet run --project API
```

---

## 🤝 Contributing

This project is part of a broader training management system.  
Pull requests and new ideas are welcome for the future frontend integration or additional features.

---

## 📜 License

MIT © Victor-Ndulue 

---

