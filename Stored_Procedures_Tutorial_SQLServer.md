
# 📘 Stored Procedures in MS SQL Server

## 🔹 What is a Stored Procedure?

A **Stored Procedure** is a precompiled collection of one or more SQL statements stored under a name and processed as a unit. You can think of it like a function in programming, but for SQL operations.

```sql
CREATE PROCEDURE ProcedureName
AS
BEGIN
    -- SQL statements go here
END
```

## 🔹 Why Use Stored Procedures?

### ✅ Benefits:

| Feature                     | Description |
|----------------------------|-------------|
| 🔄 **Reusability**         | Write once, use many times. |
| 🚀 **Performance**         | Stored procedures are precompiled, which reduces execution time. |
| 🔒 **Security**            | Users can be granted permission to execute a procedure without access to the underlying tables. |
| 🧩 **Modularity**          | Encapsulate logic in procedures for cleaner code. |
| 🧠 **Maintainability**     | Logic changes only need to be made in one place. |
| 📊 **Business Logic Layer**| Acts as an abstraction for database operations. |

## 🔹 Types of Stored Procedures in SQL Server

| Type                          | Description |
|-------------------------------|-------------|
| ✅ **User-Defined**          | Custom procedures created by developers. |
| ⚙️ **System Stored Procedures** | Provided by SQL Server for admin tasks (e.g., `sp_help`, `sp_who`). |
| 📦 **Extended Stored Procedures** | Call external programs written in C. (Deprecated in newer versions) |
| 🪝 **CLR Stored Procedures** | .NET managed code executed as stored procedures using SQL CLR integration. |
| 🔁 **Temporary Stored Procedures** | Created with `#` or `##`, scoped to a session or global respectively. |

## 🔹 Syntax: Creating a Stored Procedure

```sql
CREATE PROCEDURE usp_GetEmployeeByID
    @EmpID INT
AS
BEGIN
    SELECT * FROM Employees WHERE EmployeeID = @EmpID
END
```

✅ Use `EXEC` or `EXECUTE` to call:

```sql
EXEC usp_GetEmployeeByID @EmpID = 5
```

## 🔹 Altering a Procedure

```sql
ALTER PROCEDURE usp_GetEmployeeByID
    @EmpID INT
AS
BEGIN
    SELECT Name, Department FROM Employees WHERE EmployeeID = @EmpID
END
```

## 🔹 Dropping a Procedure

```sql
DROP PROCEDURE usp_GetEmployeeByID
```

## 🔹 Input and Output Parameters

```sql
CREATE PROCEDURE usp_AddTwoNumbers
    @Num1 INT,
    @Num2 INT,
    @Result INT OUTPUT
AS
BEGIN
    SET @Result = @Num1 + @Num2
END
```

Usage:

```sql
DECLARE @Output INT
EXEC usp_AddTwoNumbers 10, 20, @Output OUTPUT
SELECT @Output AS Result
```

## 🔹 Procedure with Error Handling

```sql
CREATE PROCEDURE usp_SafeDivide
    @A INT,
    @B INT,
    @Result FLOAT OUTPUT
AS
BEGIN
    BEGIN TRY
        IF @B = 0
            THROW 50001, 'Division by zero.', 1;
        SET @Result = @A / @B
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS ErrorMsg
    END CATCH
END
```

## 🔹 Real-World Use Case

**Procedure: Add a new employee record**

```sql
CREATE PROCEDURE usp_AddEmployee
    @Name NVARCHAR(100),
    @Dept NVARCHAR(50),
    @Salary DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Employees (Name, Department, Salary)
    VALUES (@Name, @Dept, @Salary)
END
```

Call:

```sql
EXEC usp_AddEmployee 'Rahul', 'IT', 65000
```

## 🔹 Best Practices

- Prefix procedure names with `usp_` to denote user procedures.
- Always use `SCHEMANAME.ProcedureName` format (e.g., `dbo.usp_AddEmployee`).
- Include error handling using `TRY...CATCH`.
- Avoid complex logic; keep procedures focused.
