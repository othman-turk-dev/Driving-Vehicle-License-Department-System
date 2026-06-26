# DVLD – Driving Vehicle License Department System
A desktop-based Driving License Management System built using **C# (.NET Framework)** and **SQL Server**, designed to simulate a real-world licensing authority workflow from applications to licensing, testing, and enforcement.

## Overview
DVLD is a fully database-driven system that manages the complete lifecycle of driving licenses, including applications, tests, issuance, renewals, replacements, international licenses, and license detention operations. The project focuses on **strong business logic, database design, and rule enforcement**, rather than UI complexity.

## Core Modules
### People & Users Management
- Centralized `People` table as the base entity
- Users linked to people (system employees)
- Role-based access control using bitwise permissions
- Full auditing via `CreatedByUserID`

---

### Driving License Applications
- Manage all application types:
  - New Local Driving License
  - Renew License
  - Replace Lost/Damaged License
  - International License
  - Release Detained License
  - Retake Test Applications
- Validation rules for each application type

---

### Testing System
- Three sequential test stages:
  - Vision Test
  - Theory Test
  - Street Test
- Appointment scheduling and management
- Pass/Fail result tracking
- retake flow on failure
- Test fees per stage

---

### Licensing System
- License issuance after successful tests
- Driver creation and tracking
- License status management (Active / Expired)
- Full license history per person

---

### License Operations
- Renew driving licenses
- Replace lost or damaged licenses
- Detain / release licenses
- Issue international licenses based on valid local licenses

---

### Administrative Views
- View all applications with filtering (by date)
- View daily test schedules and results
- System monitoring dashboards

---

### Business Rules
- No duplicate active applications for the same license class
- Age validation based on license category
- License must be Active to renew or replace
- International license requires valid local license
- Sequential test flow (Vision → Theory → Street)
- Detained licenses cannot be used until released

## Technologies Used
- C#
- .NET Framework (WinForms)
- SQL Server
- ADO.NET
- Stored Procedures
- 3-Tier Architecture
- Role-Based Security (Bitwise Permissions)

## Architecture
The system follows a **3-Tier Architecture**:
- Presentation Layer: Windows Forms UI
- Business Logic Layer (BLL): Rules & validations
- Data Access Layer (DAL): Database communication

## Purpose
This project was developed to practice designing and implementing a **real-world government-style licensing system**, focusing on:
- Complex database relationships
- Business rule enforcement
- Workflow-based systems
- Scalable layered architecture
