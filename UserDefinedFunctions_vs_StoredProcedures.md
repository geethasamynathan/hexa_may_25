
# 📘 User-Defined Functions (UDF) in SQL Server

## 🔹 What is a User-Defined Function?

A **User-Defined Function (UDF)** is a database object that accepts parameters, performs an action (like a calculation), and **returns a value** or a **table**. UDFs can be reused in SQL queries just like system functions (e.g., `GETDATE()`).

---

## 🔹 When to Use UDFs?

Use UDFs when:
- You want to **return a single value or a table** from a calculation or logic.
- You need to use **logic in SELECT or WHERE clauses**.
- You want reusable logic that's **read-only** (no inserts/updates).

---

## 🔍 Types of UDFs in SQL Server

| Type                         | Description |
|------------------------------|-------------|
| ✅ **Scalar Function**       | Returns a single value (e.g., int, varchar) |
| 📋 **Inline Table-Valued**   | Returns a table as a result of a single `SELECT` |
| 🛠 **Multi-statement Table-Valued** | Returns a table built using multiple statements |

---

## 🔄 Differences: Stored Procedure vs User-Defined Function

| Feature                         | Stored Procedure              | User-Defined Function           |
|----------------------------------|-------------------------------|---------------------------------|
| 🔁 Returns                       | 0 or more values (via OUTPUT) | 1 value or 1 table              |
| 🧱 Use in Queries                | Cannot be used in SELECT      | Can be used in SELECT, WHERE    |
| 🔧 Side Effects (INSERT/UPDATE) | Allowed                       | Not allowed (read-only)         |
| 🔁 Output Parameters             | Supported                     | Not supported                   |
| 🔄 Transactions                 | Can start/commit/rollback     | Cannot manage transactions      |
| 🧩 Composition                  | Cannot be embedded in SQL     | Can be embedded in SQL queries  |
| ⚠ Error Handling                | Supports TRY...CATCH          | Limited error handling          |

---

## 📂 Example: Employee Table Use Case

### 🧾 Table: Employee

| id  | name       | gender | location  | doj        | salary   |
|-----|------------|--------|-----------|------------|----------|
| 101 | Akshara    | Female | chennai   | 2025-01-06 | 35000.00 |
| 102 | Hariharan  | Male   | chennai   | 2025-01-06 | 35000.00 |
| 103 | Alhan      | Male   | Hyderabad | 2025-06-06 | 36000.00 |
| 106 | Nithya sri | Female | Hyderabad | 2025-10-06 | 39000.00 |

---

### ✅ Scalar UDF Example: Calculate Bonus (10%)

```sql
CREATE FUNCTION dbo.fn_CalculateBonus (@Salary DECIMAL(10,2))
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN @Salary * 0.10
END
```

#### Usage:

```sql
SELECT name, salary, dbo.fn_CalculateBonus(salary) AS Bonus
FROM Employee
```

---

### 📋 Inline Table-Valued Function: Get Employees by Location

```sql
CREATE FUNCTION dbo.fn_GetEmployeesByLocation (@Loc NVARCHAR(100))
RETURNS TABLE
AS
RETURN (
    SELECT * FROM Employee WHERE location = @Loc
)
```

#### Usage:

```sql
SELECT * FROM dbo.fn_GetEmployeesByLocation('chennai')
```

---

### 🛠 Multi-statement Table-Valued Function: Employees with High Salary

```sql
CREATE FUNCTION dbo.fn_HighSalaryEmployees (@MinSalary DECIMAL(10,2))
RETURNS @HighEarners TABLE (
    id INT,
    name NVARCHAR(100),
    salary DECIMAL(10,2)
)
AS
BEGIN
    INSERT INTO @HighEarners
    SELECT id, name, salary FROM Employee
    WHERE salary > @MinSalary
    RETURN
END
```

#### Usage:

```sql
SELECT * FROM dbo.fn_HighSalaryEmployees(36000)
```

---

## 📝 Summary

- Use **Stored Procedures** for **complex workflows, transactions, inserts/updates**, or **logic reuse** outside of queries.
- Use **UDFs** for **inline, reusable logic** that can be used in **SELECTs, WHEREs, JOINs**, etc.
- UDFs are **read-only** and best for **calculations or filters**.
