
# 🎓 SQL Server Stored Procedure with OUTPUT Parameters – Employee Table Scenarios

## 🧾 Employee Table Columns (Assumed)
- `id` (INT)
- `name` (VARCHAR)
- `gender` (VARCHAR)
- `location` (VARCHAR)
- `doj` (DATE)
- `salary` (DECIMAL)

---

## ✅ Scenario 1: Get Employee Salary by Name Using OUTPUT Parameter

### 🔧 Step 1: Create the Stored Procedure

```sql
CREATE PROCEDURE usp_GetSalaryByName
    @EmpName NVARCHAR(100),
    @EmpSalary DECIMAL(10,2) OUTPUT
AS
BEGIN
    SELECT @EmpSalary = salary
    FROM Employee
    WHERE name = @EmpName
END
```

---

### ▶️ Step 2: Execute the Procedure

```sql
DECLARE @Salary DECIMAL(10,2)
EXEC usp_GetSalaryByName @EmpName = 'Nithya sri', @EmpSalary = @Salary OUTPUT
SELECT @Salary AS Salary
```

🔍 **Expected Output:**
```
Salary
-------
39000.00
```

---

## 🎯 Scenario 2: Count Total Employees by Location Using OUTPUT

### 🔧 Step 1: Create the Stored Procedure

```sql
CREATE PROCEDURE usp_CountEmployeesByLocation
    @Location NVARCHAR(50),
    @TotalEmployees INT OUTPUT
AS
BEGIN
    SELECT @TotalEmployees = COUNT(*)
    FROM Employee
    WHERE location = @Location
END
```

---

### ▶️ Step 2: Execute the Procedure

```sql
DECLARE @Count INT
EXEC usp_CountEmployeesByLocation @Location = 'chennai', @TotalEmployees = @Count OUTPUT
SELECT @Count AS TotalEmployees
```

🔍 **Expected Output:**
```
TotalEmployees
---------------
3
```

---

## 📝 Notes:
- Always use the `OUTPUT` keyword both in the procedure definition and while executing.
- OUTPUT parameters are useful when you want to return multiple values or when working with return values in application code.
