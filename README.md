# Congestion Tax Calculator API

## Overview

The **Congestion Tax Calculator API** is a robust .NET application designed to calculate congestion tax fees for vehicles entering and exiting the Gothenburg area. Utilizing the principles of microservices and CQRS (Command Query Responsibility Segregation), this application provides an efficient, scalable, and maintainable solution for tax calculation.

### Key Features

- **Dynamic Tax Calculation**: Calculates fees based on predefined rules and rates for different time slots.
- **Single Charge Rule**: Implements a rule to ensure that vehicles passing multiple tolling points within 60 minutes are charged only once, with the highest fee applied.
- **Holiday Awareness**: Automatically excludes weekends, public holidays, and the month of July from tax calculations.
- **Configurable Tax Rules**: Allows easy updates to tax rules and rates, making it adaptable for other cities and regulations.
- **Data Storage**: Uses SQL Server for reliable data management and persistence.
- **Extensible Architecture**: Designed with a modular approach for easy extension and integration of new features.

## Architecture

The application is organized into two main sections:

1. **Framework (Core)**: Contains shared libraries, utilities, and base classes used across different services. This framework is designed to streamline development by providing reusable components.

2. **SRC (Source)**: The core application logic resides here, which uses the framework components. This section handles HTTP requests, orchestrates business logic, and interacts with the database.

### Technologies Used

- **.NET 6.0+**: The primary framework for building the API.
- **Entity Framework Core**: For data access and ORM (Object-Relational Mapping).
- **SQL Server**: Database management system for storing tax rules and transaction records.
- **CQRS**: Design pattern to separate read and write operations for better scalability.
- **Dependency Injection**: Promotes loose coupling and enhances testability.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or higher)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (local or remote)
- [Visual Studio](https://visualstudio.microsoft.com/) or any preferred IDE

### Installation Steps

1. **Clone the Repository**:
   ```bash
   git clone <repository-url>
   cd TaxCalculator_ASPCore_BackEnd

2. **Configure Database:**
- Create a new SQL Server database for the application.
- Open appsettings.json and update the connection string:
  
  ```bash
   "ConnectionStrings": {
        "DefaultConnection": "Server=your_server;Database=your_database;User Id=your_user;Password=your_password;"
        }
  
3. **Set Defualt Project In PackageManageConsole:**
 - In the management console , set the defualt project to the SRC/Infrastructure/Data/MSSQL/MSSQL.Commands Layer.

4. **Apply Migrations: Run the following command to apply any pending migrations and create the database schema:**
   ```bash
     dotnet ef migration add init.
     dotnet ef database update.

 4. **Run the Application: Start the API with:**
    ```bash
    dotnet run

### Acknowledgments
- Special thanks to the developers and programmers of Fintra for giving me this inspiration. and cause the development of this program.
- Acknowledgment of contributors who help maintain and improve the program.
