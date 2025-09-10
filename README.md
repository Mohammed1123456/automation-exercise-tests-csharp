AutomationAssessment - Selenium C# (NUnit)

Prerequisites
- .NET SDK 9.0+
- Google Chrome installed

Project Structure
- `AutomationAssessment.sln` – solution
- `tests/AutomationExercise.Tests` – NUnit test project
  - `Drivers/DriverFactory.cs` – WebDriver factory (Selenium Manager)
  - `Support/TestSettings.cs` – base URL, headless flag
  - `Pages/HomePage.cs`, `Pages/SignupLoginPage.cs` – POM classes
  - `Tests/*` – NUnit tests

How to run
- Headless (CI-friendly):
```bash
cd /Users/mohamedmedhat/IdeaProjects/AutomationAssessment
HEADLESS=1 dotnet test -v minimal
```
- Headed (for debugging):
```bash
cd /Users/mohamedmedhat/IdeaProjects/AutomationAssessment
dotnet test -v minimal
```

Notes
- Uses Selenium Manager to auto-resolve ChromeDriver to match your Chrome version.
- Tests implemented:
  - Homepage visibility assertion
  - Signup flow creates a new account using generated data

