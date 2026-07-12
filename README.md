# Integrated University Information System (IUIS)

A comprehensive Windows Forms application built with C# (.NET Framework) that manages university administrative operations using JSON as the primary data storage.

## Features

### Core Modules
- **Student Management** - Complete CRUD operations for student records
- **Course Management** - Manage academic programs and courses
- **Subject Management** - Handle subject catalog and prerequisites
- **Enrollment** - Process student enrollments
- **Payments** - Tuition assessment and payment tracking
- **Library** - Book inventory and borrowing transactions
- **Employees** - Faculty and staff records
- **Attendance** - Employee attendance tracking
- **Counseling** - Student counseling sessions
- **Medical** - Health records and consultations
- **Violations** - Student disciplinary records
- **Clearances** - Student clearance management

### Technical Features
- ✅ Modern UI design with custom styling
- ✅ Drag-and-drop form designer support
- ✅ JSON-based data persistence using System.Text.Json
- ✅ Shared repository pattern for data consistency
- ✅ OOP principles: Encapsulation, Inheritance, Polymorphism, Abstraction
- ✅ Comprehensive input validation
- ✅ Exception handling
- ✅ Search, sort, and filter capabilities
- ✅ DataGridView controls for data display
- ✅ Secure login system with role-based access

## Project Structure

```
IUIS/
├── Models/           # Entity classes (Student, Course, etc.)
├── Utilities/        # JSON Repository and helper classes
├── Forms/            # Windows Forms for each module
│   ├── Login/        # Login form
│   ├── Dashboard/    # Main navigation dashboard
│   ├── Students/     # Student management form
│   ├── Courses/      # Course management form
│   └── ...           # Other module forms
├── Data/             # JSON data files (created at runtime)
└── Properties/       # Assembly info and resources
```

## Getting Started

### Prerequisites
- Visual Studio 2019 or later
- .NET Framework 4.7.2 or later

### Running the Application

1. Open `IUIS.slnx` in Visual Studio
2. Build the solution (Ctrl+Shift+B)
3. Run the application (F5)

### Default Login Credentials
- **Username:** admin
- **Password:** admin123

## Data Storage

All data is stored in JSON files located in the `Data` folder:
- students.json
- courses.json
- subjects.json
- enrollments.json
- payments.json
- books.json
- borrowings.json
- counseling.json
- violations.json
- medical_records.json
- employees.json
- attendance.json
- clearances.json
- users.json

## Design Principles

### Object-Oriented Programming
- **BaseEntity** - Abstract base class for all entities
- **JsonRepository<T>** - Generic repository implementing CRUD operations
- Specialized repositories for each entity type

### Modern UI
- Custom color schemes
- Flat-style buttons
- Clean typography using Segoe UI font
- Consistent spacing and layout

## Extending the Application

To add new modules:
1. Create entity class in `Models/Entities.cs`
2. Create repository class in `Utilities/JsonRepository.cs`
3. Add form in `Forms/[ModuleName]/` folder
4. Update project file to include new files
5. Add navigation button in Dashboard

## License

This project is for educational purposes.
