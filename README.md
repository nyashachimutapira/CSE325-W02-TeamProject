# WWD Team Bishop - Task Tracker

A beautiful, functional Task Tracker application built with .NET 8 Blazor, Entity Framework Core, and Identity Authentication.

## Features
- **User Authentication**: Register, login, and secure your personal tasks safely.
- **Task Management**: Perform full CRUD (Create, Read, Update, Delete) operations on tasks.
- **Beautiful UI**: Modern glassmorphism aesthetic with a dynamic animated background.
- **Responsive Design**: Designed to look great on desktop, tablet, and mobile.

## Getting Started

### Prerequisites
- .NET 8 SDK installed on your machine.
- A basic SQLite viewer (optional) for viewing the database file directly.

### Running the Application Locally
1. Clone the repository and navigate to the `TaskTrackerApp` directory.
2. Run the Entity Framework database migrations to initialize the SQLite database (this is built-in the start-up sequence but can be explicitly run):
   ```bash
   dotnet ef database update
   ```
3. Run the application:
   ```bash
   dotnet run
   ```
4. Open your browser and navigate to `http://localhost:5000` (or the port specified in the console output).

### Using the App
1. **Register**: Click "Register" in the top navigation bar to create a new account. Since email confirmations are off by default in development, you can log in immediately after.
2. **Access Tasks**: Click on "Tasks" in the navigation menu.
3. **Create a Task**: Click "+ New Task", fill out the title, optional description, and due date.
4. **Manage Tasks**: Toggle a task status by clicking the checkmark, edit it using the pencil icon, or delete it using the X icon. Tasks color-coordinate based on their state to help you easily parse your work list!

## Technologies
- .NET 8
- Blazor Web App (InteractiveServer)
- EF Core (SQLite)
- ASP.NET Core Identity
- Bootstrap 5 & Custom CSS
