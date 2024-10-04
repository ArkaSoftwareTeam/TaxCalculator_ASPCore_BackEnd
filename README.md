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
   cd congestion-tax-calculator
