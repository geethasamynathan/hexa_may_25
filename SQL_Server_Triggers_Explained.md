# 🔥 SQL Server Triggers – Complete Guide with Real-World Examples

## ❓ What is a Trigger?

A **Trigger** is a special stored procedure that automatically executes in response to certain events on a table or view.

---

## 🧠 Why Do We Use Triggers?

- Enforce business rules
- Automate logging/auditing
- Prevent unwanted changes
- Maintain historical records
- Cascade or override behavior

---

## ⏱️ When to Use Triggers?

Use triggers when:
- You want to auto-log changes
- You need to enforce constraints not possible with CHECK
- You want to stop DML/DDL based on conditions
- You want to perform actions *after* or *instead of* certain DML events

---

## 🔄 Types of Triggers

| Type                     | Description |
|--------------------------|-------------|
| **AFTER Trigger**        | Executes after INSERT/UPDATE/DELETE |
| **INSTEAD OF Trigger**   | Executes instead of the DML operation |
| **DDL Trigger**          | Executes on schema events (CREATE, DROP, ALTER) |

---

## ✅ Real-World Examples

### 🧾 Setup: Employee Table

```sql
CREATE TABLE Employee (
    EmpID INT PRIMARY KEY,
    Name VARCHAR(100),
    Salary DECIMAL(10,2),
    Department VARCHAR(50)
)

INSERT INTO Employee VALUES
(1, 'Alice', 50000, 'HR'),
(2, 'Bob', 60000, 'IT')
```

---

### 1️⃣ AFTER INSERT Trigger – Track New Hires

```sql
CREATE TABLE EmployeeLog (
    EmpID INT,
    Name VARCHAR(100),
    ActionTime DATETIME,
    ActionType VARCHAR(50)
)

CREATE TRIGGER trg_AfterInsert_Employee
ON Employee
AFTER INSERT
AS
BEGIN
    INSERT INTO EmployeeLog (EmpID, Name, ActionTime, ActionType)
    SELECT EmpID, Name, GETDATE(), 'Inserted'
    FROM INSERTED
END
```

💡 **Use Case:** Log new employee additions automatically.

---

### 2️⃣ AFTER UPDATE Trigger – Log Salary Changes

```sql
CREATE TABLE SalaryAudit (
    EmpID INT,
    OldSalary DECIMAL(10,2),
    NewSalary DECIMAL(10,2),
    ChangedAt DATETIME
)

CREATE TRIGGER trg_AfterUpdate_Salary
ON Employee
AFTER UPDATE
AS
BEGIN
    INSERT INTO SalaryAudit (EmpID, OldSalary, NewSalary, ChangedAt)
    SELECT d.EmpID, d.Salary, i.Salary, GETDATE()
    FROM DELETED d
    JOIN INSERTED i ON d.EmpID = i.EmpID
    WHERE d.Salary <> i.Salary
END
```

💡 **Use Case:** Track changes in employee salary history.

---

### 3️⃣ INSTEAD OF DELETE Trigger – Soft Delete

```sql
CREATE TABLE EmployeeArchive (
    EmpID INT,
    Name VARCHAR(100),
    Salary DECIMAL(10,2),
    Department VARCHAR(50),
    ArchivedAt DATETIME
)

CREATE TRIGGER trg_InsteadOfDelete_Employee
ON Employee
INSTEAD OF DELETE
AS
BEGIN
    INSERT INTO EmployeeArchive
    SELECT EmpID, Name, Salary, Department, GETDATE()
    FROM DELETED

    DELETE FROM Employee WHERE EmpID IN (SELECT EmpID FROM DELETED)
END
```

💡 **Use Case:** Preserve deleted employee records.

---

### 4️⃣ DDL Trigger – Prevent Table Drop

```sql
CREATE TRIGGER trg_PreventDropTable
ON DATABASE
FOR DROP_TABLE
AS
BEGIN
    PRINT 'Dropping tables is not allowed!'
    ROLLBACK;
END
```

💡 **Use Case:** Prevent accidental schema deletion in production.

---

## 📌 Summary Table

| Trigger Type     | Fires On                | Typical Use Case                             |
|------------------|-------------------------|----------------------------------------------|
| AFTER INSERT     | After a row is inserted | Logging, validation                          |
| AFTER UPDATE     | After update happens    | Change tracking, audits                      |
| INSTEAD OF DELETE| Before delete happens   | Soft deletes, validation                     |
| DDL Trigger      | On schema changes       | Prevent dropping objects, audit schema ops   |