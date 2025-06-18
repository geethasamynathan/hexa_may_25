
# ✅ SonarQube with ASP.NET Core Web API

## 🔷 What is SonarQube?

**SonarQube** is an open-source platform used for **continuous inspection of code quality**. It performs **automatic reviews** with static code analysis to detect:

- Bugs
- Code smells
- Vulnerabilities
- Security hotspots
- Duplications
- Coverage by unit tests

Supports multiple languages like **C#, Java, Python, JavaScript, TypeScript**, etc.

---

## 🔷 Why Use SonarQube?

| Reason | Benefit |
|--------|---------|
| 🔍 Detect Code Issues Early | Identify bugs, code smells, and security flaws during development |
| ✅ Improve Code Quality | Enforce coding standards and best practices |
| 🔐 Enhance Security | Detect potential vulnerabilities and security hotspots |
| 🔁 Integrate with CI/CD | Seamlessly integrates with Azure DevOps, Jenkins, GitHub Actions |
| 📊 Track Progress | Dashboards and reports to monitor code quality over time |

---

## 🔷 Steps to Set Up SonarQube for ASP.NET Core Web API

### 🔧 1. Install SonarQube Server (Optional for Local Testing)

- Download from: [https://www.sonarsource.com/products/sonarqube/downloads/](https://www.sonarsource.com/products/sonarqube/downloads/)
- Run:
  - On Windows: `StartSonar.bat`
  - On Linux: `./sonar.sh start`
- Dashboard URL: `http://localhost:9000`
- Default Login: `admin / admin`

---

### 🧪 2. Install SonarScanner for .NET

```bash
dotnet tool install --global dotnet-sonarscanner
```

---

### 📁 3. Prepare Your ASP.NET Core Web API Project

- Ensure your solution builds (`.sln`)
- Add test projects (`.csproj`)
- Enable code coverage using `coverlet` or `reportgenerator`

---

### ⚙️ 4. Configure SonarQube Project

- Login to SonarQube Dashboard
- Create New Project
- Get `Project Key` and `Authentication Token`

---

### 🚀 5. Run SonarScanner Commands

```bash
# Begin analysis
dotnet sonarscanner begin /k:"MyWebAPI" /d:sonar.login="your-token" /d:sonar.host.url="http://localhost:9000"

# Build the solution
dotnet build

# Optional: Run tests with coverage
dotnet test --collect:"XPlat Code Coverage"

# End analysis
dotnet sonarscanner end /d:sonar.login="your-token"
```

---

### 📈 6. View Results on Dashboard

- Visit: `http://localhost:9000`
- Select your project
- Review: Bugs, Code Smells, Coverage, Vulnerabilities

---

## ✅ Optional Enhancements

| Task | Tool |
|------|------|
| Add to CI/CD | Azure DevOps / GitHub Actions |
| Code coverage reports | Coverlet, ReportGenerator |
| Security analysis | SonarQube SAST |
| Quality gates | Enforce policies (e.g., 80% coverage) |

---

## 🧪 Tools Summary

| Tool | Purpose |
|------|---------|
| **SonarQube** | Code quality dashboard |
| **SonarScanner** | Analyze and send results |
| **dotnet test** | Run unit tests |
| **coverlet** | Code coverage for .NET |
| **ReportGenerator** | Convert raw coverage to HTML reports |
