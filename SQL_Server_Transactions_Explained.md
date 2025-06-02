# 🔄 SQL Server Transactions – Explanation & Real-World Examples

## 💬 What is a Transaction?

A **Transaction** is a sequence of operations performed as a single logical unit of work. It must be either **entirely completed or aborted**. This ensures data integrity in multi-step processes.

---

## ✅ Why Are Transactions Important?

Transactions provide the foundation for reliable systems through **ACID properties**:

- **Atomicity** – All steps succeed or none do.
- **Consistency** – Database moves from one valid state to another.
- **Isolation** – Transactions don't interfere with each other.
- **Durability** – Once committed, changes are permanent.

---

## 🔍 Real-World Implementations

### 🏦 Example 1: Bank Fund Transfer

#### Scenario:
Transfer ₹500 from Account A to Account B.

#### SQL Code:
```sql
BEGIN TRANSACTION

UPDATE Accounts
SET Balance = Balance - 500
WHERE AccountID = 'A'

UPDATE Accounts
SET Balance = Balance + 500
WHERE AccountID = 'B'

COMMIT
-- On failure, use ROLLBACK
```

#### Explanation:
If either update fails, rollback will ensure the transaction doesn’t cause incorrect balance changes.

---

### 🛒 Example 2: E-Commerce Order Placement

#### Scenario:
Place an order which involves:
- Adding the order to Orders table
- Adding items to Order_Items table
- Deducting from inventory

#### SQL Code:
```sql
BEGIN TRY
    BEGIN TRANSACTION

    INSERT INTO Orders (OrderID, CustomerID, OrderDate)
    VALUES (101, 10, GETDATE())

    INSERT INTO Order_Items (OrderID, ProductID, Quantity)
    VALUES (101, 2001, 2)

    UPDATE Stocks
    SET Quantity = Quantity - 2
    WHERE ProductID = 2001

    COMMIT
END TRY
BEGIN CATCH
    ROLLBACK
    PRINT 'Transaction failed: ' + ERROR_MESSAGE()
END CATCH
```

#### Explanation:
If inserting into Order_Items fails, the entire transaction is rolled back, avoiding partial data entry.

---

### 🧾 Example 3: Salary Payment System

#### Scenario:
Monthly payroll involves bonus updates and audit trail insertions.

#### SQL Code:
```sql
BEGIN TRAN

UPDATE Employees
SET Salary = Salary + (Salary * 0.10)

INSERT INTO Payroll_History (EmpID, Amount, PayDate)
SELECT EmpID, Salary, GETDATE() FROM Employees

COMMIT
-- Use ROLLBACK in case of errors
```

#### Explanation:
Ensures no employee is paid bonus unless all related records are properly inserted.

---

## 📌 Summary Table

| Feature        | Description                                  |
|----------------|----------------------------------------------|
| Atomicity      | Ensures full success or complete failure     |
| Consistency    | Maintains integrity before and after actions |
| Isolation      | Avoids interference across transactions      |
| Durability     | Committed changes are saved permanently      |

---

**Use transactions** when performing multiple related actions where consistency, rollback, and integrity are essential.