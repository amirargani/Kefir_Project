# 📚 Kefir Project – Intelligent FAQ Matching System

[![License](https://img.shields.io/badge/License-Apache_2.0-D22128?style=for-the-badge&logo=apache)](LICENSE.txt)
[![Language](https://img.shields.io/badge/Language-C%23-239120.svg?style=for-the-badge&logo=csharp)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Platform](https://img.shields.io/badge/Platform-Windows-0078D6.svg?style=for-the-badge&logo=windows)](https://www.microsoft.com/en-us/windows)
[![Framework](https://img.shields.io/badge/.NET_Framework-4.8-512BD4.svg?style=for-the-badge&logo=.net&logoColor=white)](https://versionsof.net/framework/)
[![AngularJS](https://img.shields.io/badge/AngularJS-1.5.8-E23237?style=for-the-badge&logo=angularjs&logoColor=white)](https://angularjs.org/)
[![Bootstrap](https://img.shields.io/badge/Bootstrap-v3.0.0-563d7c?style=for-the-badge&logo=bootstrap)](https://getbootstrap.com/)
[![Database](https://img.shields.io/badge/Database-SQL_Server-005A9C?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)](https://www.microsoft.com/en-us/sql-server)
> An intelligent FAQ web application that automatically matches user questions to existing FAQs using machine learning techniques. Developed as part of a Bachelor's thesis project.

---

## 📋 Table of Contents

- [Overview](#-overview)
- [Features](#-features)
- [Technologies](#-technologies)
- [Architecture](#-architecture)
- [Getting Started](#-getting-started)
- [Usage](#-usage)
- [API Documentation](#-api-documentation)
- [Project Structure](#-project-structure)
- [Matching Algorithm](#-matching-algorithm)
- [User Roles](#-user-roles)
- [Contributing](#-contributing)

---

## 🎯 Overview

The **Kefir Project** is an intelligent FAQ system that automatically responds to user questions by matching them against a database of existing FAQs. The system uses advanced text similarity algorithms to find the most relevant answers, reducing the need for manual intervention while continuously learning from new questions.

### Key Objectives

- **Automated Response**: Instantly match user questions to existing FAQs
- **Intelligent Matching**: Use TF-IDF vectorization and cosine similarity for semantic matching
- **Continuous Learning**: Store unmatched questions for administrator review and system improvement
- **User-Friendly Interface**: Provide an intuitive web interface for both users and administrators

---

## ✨ Features

### For Users
- ✅ Submit questions through a clean web interface
- ✅ Receive instant answers from the FAQ database
- ✅ View all frequently asked questions
- ✅ Browse categorized FAQ content

### For Administrators
- ✅ Manage FAQ entries (Create, Read, Update, Delete)
- ✅ Review unanswered questions
- ✅ Add answers to new questions
- ✅ Monitor system usage and statistics
- ✅ User management and access control

### Technical Features
- 🤖 **Machine Learning Integration**: TF-IDF text vectorization
- 🎯 **Cosine Similarity**: Semantic question matching (80% threshold)
- 📊 **RESTful API**: Well-structured Web API endpoints
- 🔐 **Role-Based Access**: Separate user and admin interfaces
- 💾 **Entity Framework**: Code-first database approach
- 📱 **Responsive Design**: Mobile-friendly interface

---

## 🔧 Technologies

### Backend
- **Framework**: ASP.NET MVC 5.2.3
- **Language**: C# (.NET Framework 4.8)
- **Web API**: ASP.NET Web API 5.2.3
- **ORM**: Entity Framework 6.1.3
- **Database**: SQL Server
- **ML Library**: ML.NET (for TF-IDF and cosine similarity)

### Frontend
- **HTML5** & **CSS3**
- **JavaScript** (Vanilla JS & jQuery)
- **AngularJS**: v1.5.8 (For dynamic admin panel)
- **Bootstrap**: Responsive UI framework
- **Font Awesome**: Icon library

### Additional Libraries
- **Newtonsoft.Json**: JSON serialization
- **DataTables**: Advanced table features
- **CKEditor**: Rich text editing
- **Alertify.js**: Beautiful notifications

---

## 🏗 Architecture

The application follows the **ASP.NET MVC** pattern with a clear separation of concerns:

```
┌─────────────────┐
│   Web Client    │
│  (HTML/CSS/JS)  │
└────────┬────────┘
         │
         ▼
┌─────────────────┐
│  MVC Controllers│
│   (Routing)     │
└────────┬────────┘
         │
         ▼
┌─────────────────┐
│  Web API Layer  │
│  (RESTful API)  │
└────────┬────────┘
         │
         ▼
┌─────────────────┐
│  Business Logic │
│  (ML Matching)  │
└────────┬────────┘
         │
         ▼
┌─────────────────┐
│ Entity Framework│
│  (Data Access)  │
└────────┬────────┘
         │
         ▼
┌─────────────────┐
│   SQL Server    │
│   (Database)    │
└─────────────────┘
```

---

## 🚀 Getting Started

### Prerequisites

- **Windows OS** (Windows 10 or later recommended)
- **Visual Studio 2015** or later
- **SQL Server 2012** or later (Express edition is sufficient)
- **.NET Framework 4.8**
- **IIS Express** (included with Visual Studio)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/Kefir_Project.git
   cd Kefir_Project
   ```

2. **Open the solution**
   - Open `KefirProject.sln` in Visual Studio

3. **Restore NuGet packages**
   ```bash
   # In Visual Studio Package Manager Console
   Update-Package -reinstall
   ```

4. **Configure the database**
   - Update the connection string in `Web.config`:
   ```xml
   <connectionStrings>
     <add name="DefaultConnection" 
          connectionString="Data Source=YOUR_SERVER;Initial Catalog=KefirDB;Integrated Security=True" 
          providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```

5. **Run database migrations**
   ```bash
   # In Package Manager Console
   Update-Database
   ```

6. **Build and run**
   - Press `F5` in Visual Studio or
   - Right-click the project → Debug → Start New Instance

7. **Access the application**
   - Default URL: `http://localhost:1760/`
   - Admin panel: `http://localhost:1760/Admin`

---

## 💡 Usage

### Submitting a Question (User)

1. Navigate to the main page
2. Enter your question in the input field
3. Click "Submit" or press Enter
4. The system will:
   - Search for similar questions in the database
   - Return the best matching answer (if similarity ≥ 80%)
   - Store your question for admin review (if no match found)

### Managing FAQs (Administrator)

1. Log in to the admin panel at `/Admin`
2. Navigate to **Manage FAQ**
3. Available actions:
   - **Add New FAQ**: Create question-answer pairs
   - **Edit FAQ**: Modify existing entries
   - **Delete FAQ**: Remove outdated entries
   - **Review Questions**: Answer user-submitted questions

---

## 📡 API Documentation

### Base URL
```
http://localhost:1760/api
```

### Endpoints

#### 1. Submit a Question
```http
POST /api/FAQ/SendQuestion
Content-Type: application/json

{
  "QuestionText": "How does kefir fermentation work?"
}
```

**Response (Match Found)**
```json
{
  "success": true,
  "answer": "Kefir fermentation is a process where...",
  "similarity": 0.85,
  "questionId": 42
}
```

**Response (No Match)**
```json
{
  "success": false,
  "message": "No matching answer found. Your question has been saved for review.",
  "questionId": 123
}
```

#### 2. Get All FAQs
```http
GET /api/FAQ/GetAll
```

**Response**
```json
[
  {
    "id": 1,
    "question": "What is kefir?",
    "answer": "Kefir is a fermented milk drink...",
    "createdDate": "2025-01-15T10:30:00"
  }
]
```

#### 3. Get FAQ by ID
```http
GET /api/FAQ/Get/{id}
```

#### 4. Create FAQ (Admin)
```http
POST /api/FAQ/Create
Content-Type: application/json
Authorization: Bearer {token}

{
  "question": "How long does kefir last?",
  "answer": "Properly stored kefir can last..."
}
```

#### 5. Update FAQ (Admin)
```http
PUT /api/FAQ/Update/{id}
```

#### 6. Delete FAQ (Admin)
```http
DELETE /api/FAQ/Delete/{id}
```

---

## 📁 Project Structure

```
Kefir_Project/
├── KefirWebsite/                 # Main web application
│   ├── Areas/
│   │   └── Admin/                # Admin panel area
│   │       ├── Controllers/      # Admin controllers
│   │       ├── Views/            # Admin views
│   │       └── Scripts/          # Admin-specific JS
│   ├── Controllers/
│   │   ├── Api/                  # Web API controllers
│   │   │   ├── FAQController.cs
│   │   │   ├── UsersController.cs
│   │   │   └── ...
│   │   └── HomeController.cs     # MVC controllers
│   ├── Views/
│   │   ├── Home/
│   │   │   ├── Index.cshtml
│   │   │   ├── Faq.cshtml
│   │   │   └── Question.cshtml
│   │   └── Shared/
│   ├── Scripts/                  # JavaScript files
│   ├── Content/                  # CSS and styles
│   ├── App_Start/
│   │   ├── RouteConfig.cs
│   │   └── WebApiConfig.cs
│   └── Web.config
├── KefirProjectLib/              # Business logic library
│   ├── Models/                   # Entity models
│   ├── DataAccess/               # EF DbContext
│   └── Services/                 # Business services
├── LICENSE.txt                   # Apache 2.0 License
├── README.md                     # This file
└── SendQuestion.md               # Cosine similarity documentation
```

---

## 🧠 Matching Algorithm

The system uses a sophisticated two-stage matching approach:

### Stage 1: Basic Word Overlap (Legacy)
- Splits questions into individual words
- Calculates percentage of matching words
- Threshold: **50% similarity**
- Fast but less accurate

### Stage 2: TF-IDF + Cosine Similarity (Current)

For detailed information, see [SendQuestion.md](SendQuestion.md)

#### Process Flow

1. **Input Validation**
   - Reject empty or whitespace-only questions
   - Sanitize input to prevent injection attacks

2. **Database Query**
   - Load all answered FAQs from the database
   - Filter out unanswered questions

3. **ML Context Initialization**
   - Create `MLContext` for machine learning operations
   - Prepare data for vectorization

4. **TF-IDF Vectorization**
   - Convert questions to numerical vectors
   - Apply Term Frequency-Inverse Document Frequency weighting
   - Captures semantic meaning beyond simple word matching

5. **Cosine Similarity Calculation**
   ```
   similarity = (A · B) / (||A|| × ||B||)
   ```
   - Compare user question vector with all FAQ vectors
   - Find the highest similarity score

6. **Decision Logic**
   - **Similarity ≥ 0.8**: Return matching answer
   - **Similarity < 0.8**: Save question for admin review

#### Example

**User Question**: "How do I make kefir at home?"

**FAQ Database**:
- Q1: "What is the process for making kefir?" (Similarity: 0.87) ✅
- Q2: "Where can I buy kefir grains?" (Similarity: 0.42)
- Q3: "How long does fermentation take?" (Similarity: 0.35)

**Result**: Return answer from Q1

---

## 🔐 User Roles

### User Role
- Submit questions
- View public FAQs
- Browse answered questions
- No authentication required for basic access

### Administrator Role
- All user permissions
- Create, edit, and delete FAQs
- Review unanswered questions
- Add answers to pending questions
- Manage user accounts
- Access admin dashboard
- View system statistics

---

## 🤝 Contributing

Contributions are welcome! Please follow these guidelines:

1. **Fork the repository**
2. **Create a feature branch**
   ```bash
   git checkout -b feature/YourFeature
   ```
3. **Commit your changes**
   ```bash
   git commit -m "Add: Your feature description"
   ```
4. **Push to the branch**
   ```bash
   git push origin feature/YourFeature
   ```
5. **Open a Pull Request**

### Coding Standards
- Follow C# naming conventions
- Add XML documentation to public methods
- Write unit tests for new features
- Ensure all tests pass before submitting PR

---

## 🙏 Acknowledgments

- Developed as part of a Bachelor's thesis project
- Built with ASP.NET MVC and Entity Framework
- Machine learning powered by ML.NET
- UI components from Bootstrap and Font Awesome

---

*Developed by Amir Argani*
