# Automation Exercise Test Framework

A comprehensive test automation framework built with C# .NET 9, Selenium WebDriver, NUnit, and RestSharp for testing the Automation Exercise website.

## 🚀 Features

- **Page Object Model (POM)** - Clean, maintainable test structure
- **Data-Driven Testing (DDT)** - CSV-based test data management
- **API Testing** - RESTful API testing with RestSharp
- **Cross-browser Support** - Chrome WebDriver with headless mode
- **Test Categorization** - Organized test suites (UI, API, Smoke, Regression)
- **HTML Reporting** - Beautiful test execution reports
- **CI/CD Ready** - GitHub Actions workflows included

## 📋 Prerequisites

- .NET 9.0 SDK
- Visual Studio Code or Visual Studio
- Chrome browser (for UI tests)

## 🛠️ Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/your-username/automation-exercise-tests-csharp.git
   cd automation-exercise-tests-csharp
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Build the solution**
   ```bash
   dotnet build
   ```

## 🧪 Running Tests

### Run All Tests
```bash
# Headless mode (recommended for CI/CD)
HEADLESS=1 dotnet test

# With browser visible
dotnet test
```

### Run Tests by Category
```bash
# UI Tests only
HEADLESS=1 dotnet test -- NUnit.Where="cat==ui"

# API Tests only
dotnet test -- NUnit.Where="cat==api"

# Smoke Tests only
HEADLESS=1 dotnet test -- NUnit.Where="cat==smoke"

# Regression Tests only
HEADLESS=1 dotnet test -- NUnit.Where="cat==regression"
```

### Generate HTML Reports
```bash
# Generate and open HTML report
HEADLESS=1 dotnet test --logger "html;LogFileName=TestResults.html" --results-directory ./TestResults && open ./TestResults/TestResults.html
```

## 📁 Project Structure

```
AutomationAssessment/
├── tests/
│   └── AutomationExercise.Tests/
│       ├── Api/                    # API client and utilities
│       ├── Drivers/                # WebDriver factory
│       ├── Pages/                  # Page Object Model classes
│       ├── Support/                # Test utilities and data factories
│       ├── TestData/               # CSV test data files
│       └── Tests/                  # Test classes
├── .github/
│   └── workflows/                  # GitHub Actions CI/CD pipelines
└── .vscode/                        # VS Code configuration
```

## 🎯 Test Categories

| Category | Description | Tests |
|----------|-------------|-------|
| **UI** | User Interface tests | Homepage, Signup, Login |
| **API** | API endpoint tests | Create Account API |
| **Smoke** | Critical path tests | Homepage verification |
| **Regression** | Full feature tests | Complete signup flow |

## 📊 Test Data

### CSV Data Files
- `TestData/login_data.csv` - Login test credentials
- `TestData/api_test_data.csv` - API test data

### Data Factory
- `TestDataFactory.CreateValidUser()` - Generate random user data
- `TestDataFactory.CreateUserWithCustomEmail()` - Custom email generation

## 🔧 Configuration

### Test Settings
- **Base URL**: https://automationexercise.com/
- **Headless Mode**: Configurable via `HEADLESS` environment variable
- **Browser**: Chrome (auto-managed by Selenium Manager)

### VS Code Tasks
- `test: headless + HTML report` - Run all tests and generate report
- `test: api only + HTML report` - Run API tests and generate report

## 🚀 CI/CD Pipeline

### GitHub Actions Workflows

1. **Test Automation Pipeline** (`test-automation.yml`)
   - Runs on push/PR to main/develop
   - Matrix strategy for different test categories
   - Generates test reports and artifacts

2. **CI/CD Pipeline** (`ci-cd.yml`)
   - Full build, test, and deployment
   - Code coverage reporting
   - Security scanning

3. **Nightly Tests** (`nightly-tests.yml`)
   - Scheduled daily execution
   - Full test suite with coverage
   - Extended artifact retention

### Pipeline Features
- ✅ **Parallel Execution** - Tests run in parallel by category
- ✅ **Artifact Storage** - Test results and reports saved
- ✅ **Test Reporting** - Integrated test result visualization
- ✅ **Code Coverage** - Coverage reports generated
- ✅ **Security Scanning** - Dependency vulnerability checks

## 📈 Test Reports

### HTML Reports
- Detailed test execution results
- Test timing and status
- Screenshots and logs (when available)

### Coverage Reports
- Code coverage metrics
- Line-by-line coverage analysis
- Coverage trends over time

## 🛡️ Best Practices

### Test Design
- **Page Object Model** - Encapsulates page elements and actions
- **Data-Driven Testing** - External data for test scenarios
- **Test Isolation** - Each test is independent
- **Proper Assertions** - Clear, meaningful test validations

### Code Quality
- **SOLID Principles** - Clean, maintainable code
- **Error Handling** - Graceful failure handling
- **Logging** - Comprehensive test execution logs
- **Documentation** - Clear code comments and README

## 🔍 Troubleshooting

### Common Issues

1. **ChromeDriver Version Mismatch**
   - Solution: Selenium Manager handles this automatically

2. **Test Data Issues**
   - Check CSV file format and encoding
   - Verify data factory methods

3. **CI/CD Failures**
   - Check GitHub Actions logs
   - Verify environment variables
   - Review test artifacts

### Debug Mode
```bash
# Run with detailed logging
dotnet test -v detailed

# Run specific test
dotnet test --filter "TestName=HomePage_Should_Load_Successfully"
```

## 📝 Contributing

1. Fork the repository
2. Create a feature branch
3. Add tests for new functionality
4. Ensure all tests pass
5. Submit a pull request

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 🤝 Support

For questions or issues:
- Create an issue in the GitHub repository
- Check the troubleshooting section
- Review the test execution logs

---
