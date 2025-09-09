# SnipeIT Demo Automation Test

A comprehensive test automation framework for the SnipeIT asset management demo application using .NET and Microsoft Playwright.

## Overview

This project demonstrates end-to-end automation testing of the SnipeIT demo application, specifically focusing on asset creation, validation, and history tracking workflows. The framework follows industry best practices including the Page Object Model (POM) pattern, separation of concerns, and maintainable test architecture.

## Test Scenario

The automation script performs the following comprehensive workflow:

1. **Authentication**: Login to the SnipeIT demo application
2. **Asset Creation**: Create a new Macbook Pro 13" asset with "Ready to Deploy" status and assigned to a random user
3. **Asset Discovery**: Search and locate the newly created asset in the assets list
4. **Detail Validation**: Navigate to the asset page and verify all creation details
5. **History Verification**: Validate asset history and assignment information

## Architecture & Design Patterns

### Page Object Model (POM)
The project implements a clean Page Object Model architecture:

```
├── Pages/
│   ├── LoginPage.cs           # Login functionality
│   ├── DashboardPage.cs       # Main dashboard interactions
│   ├── CreateAssetPage.cs     # Asset creation workflow
│   ├── AssetDashboard.cs      # Asset search and navigation
│   ├── AssetPage.cs           # Asset details and history validation
│   └── Sections/
│       └── Navbar.cs          # Reusable navigation component
├── Models/
│   └── Asset.cs               # Asset data model (implied)
└── Tests/
    └── UnitTest1.cs           # Main test execution
```

### Key Design Principles

- **Separation of Concerns**: Each page class handles only its specific UI interactions
- **Reusable Components**: Common elements like navigation are abstracted into section classes
- **Data Models**: Asset information is encapsulated in dedicated model classes
- **Wait Strategies**: Proper synchronization using Playwright's wait mechanisms
- **Error Handling**: Comprehensive validation and assertion strategies


## Prerequisites

- [.NET 6.0 or later](https://dotnet.microsoft.com/download)
- [Microsoft Playwright](https://playwright.dev/dotnet/)
- Visual Studio 2022 or Visual Studio Code
- Internet connection (for accessing the demo application)

## Installation & Setup

### 1. Clone the Repository
```bash
git clone <repository-url>
cd Global360Test
```

### 2. Restore Dependencies
```bash
dotnet restore
```

### 3. Install Playwright Browsers
```bash
# Install Playwright CLI globally
dotnet tool install --global Microsoft.Playwright.CLI

# Install required browsers
playwright install
```

### 4. Build the Project
```bash
dotnet build
```

## Running the Tests

### Command Line Execution
```bash
# Run all tests
dotnet test

# Run with detailed output
dotnet test --logger "console;verbosity=detailed"

# Run specific test
dotnet test --filter "Test1"
```

### IDE Execution
- **Visual Studio**: Use Test Explorer to run individual or all tests
- **VS Code**: Install the .NET Test Explorer extension

## Project Structure

### Core Components

- **`UnitTest1.cs`**: Main test orchestration and workflow execution
- **`LoginPage.cs`**: Handles authentication processes
- **`CreateAssetPage.cs`**: Manages complex asset creation workflow including dropdown selections
- **`AssetDashboard.cs`**: Provides search and navigation capabilities
- **`AssetPage.cs`**: Validates asset details and history information
- **`Navbar.cs`**: Reusable navigation component for dropdown interactions

### Models
- **Asset Model**: Encapsulates asset properties including tag, model, status, and assignment information

## Test Data & Configuration

### Default Test Configuration
- **Target Application**: https://demo.snipeitapp.com
- **Test Credentials**: admin / password
- **Asset Type**: Macbook Pro 13"
- **Default Status**: Ready to Deploy
- **User Assignment**: Random selection from available users

## Validation Strategy

The framework implements comprehensive validation at multiple levels:

### Asset Creation Validation
- Asset tag generation and capture
- Model selection verification
- Status assignment confirmation
- User assignment validation

### Asset Discovery Validation
- Search functionality verification
- Asset presence in listings
- Navigation accuracy

### Detail Page Validation
- Asset tag consistency
- Model information accuracy
- Status display correctness
- User assignment details


## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/enhancement`)
3. Commit your changes (`git commit -am 'Add new feature'`)
4. Push to the branch (`git push origin feature/enhancement`)
5. Create a Pull Request

## Best Practices Demonstrated

- **Clean Code**: Readable, maintainable code structure
- **SOLID Principles**: Single responsibility and dependency inversion
- **Test Organization**: Logical grouping and clear test flow
- **Resource Management**: Proper page and locator lifecycle management
- **Synchronization**: Appropriate wait strategies for reliable execution


## License

This project is created for demonstration purposes as part of a coding assessment.

---
