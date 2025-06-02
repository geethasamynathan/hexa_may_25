# SQL Server Real-World Transaction Examples

## 1. 🏦 Bank Transfer Transaction (Single Table)

```sql
CREATE TABLE BankAccounts (
    AccountID INT PRIMARY KEY,
    AccountHolder NVARCHAR(100),
    Balance DECIMAL(18, 2)
);

INSERT INTO BankAccounts (AccountID, AccountHolder, Balance) VALUES
(1, 'Alice', 1000.00),
(2, 'Bob', 500.00);

BEGIN TRANSACTION;
BEGIN TRY
    UPDATE BankAccounts SET Balance = Balance - 200 WHERE AccountID = 1;
    -- THROW 50000, 'Simulated error', 1; -- Uncomment to simulate error
    UPDATE BankAccounts SET Balance = Balance + 200 WHERE AccountID = 2;
    COMMIT TRANSACTION;
    PRINT 'Transaction committed successfully';
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    PRINT 'Transaction rolled back due to an error';
    PRINT ERROR_MESSAGE();
END CATCH;
```

---

## 2. 🛒 E-commerce Order Transaction (Multi-Table)

```sql
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Stock INT
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    ProductID INT,
    Quantity INT,
    OrderDate DATETIME,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

INSERT INTO Products (ProductID, ProductName, Stock) VALUES
(1, 'Laptop', 10),
(2, 'Mouse', 100);

DECLARE @ProductID INT = 1;
DECLARE @OrderQty INT = 2;

BEGIN TRANSACTION;
BEGIN TRY
    IF (SELECT Stock FROM Products WHERE ProductID = @ProductID) < @OrderQty
        THROW 50001, 'Not enough stock available.', 1;

    INSERT INTO Orders (ProductID, Quantity, OrderDate)
    VALUES (@ProductID, @OrderQty, GETDATE());

    UPDATE Products SET Stock = Stock - @OrderQty WHERE ProductID = @ProductID;

    COMMIT TRANSACTION;
    PRINT 'Order placed successfully!';
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    PRINT 'Order failed. Transaction rolled back.';
    PRINT ERROR_MESSAGE();
END CATCH;
```

---

## 3. 🔁 Nested Transaction Example

```sql
BEGIN TRANSACTION OuterTran;
SAVE TRANSACTION SavePoint1;

UPDATE Products SET Stock = Stock - 1 WHERE ProductID = 1;

BEGIN TRANSACTION InnerTran;
UPDATE Products SET Stock = Stock - 1 WHERE ProductID = 2;
COMMIT TRANSACTION InnerTran;

COMMIT TRANSACTION OuterTran;
```

---

## 4. 🔐 Transaction Isolation Levels (READ COMMITTED example)

```sql
-- Session 1
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
BEGIN TRANSACTION;
SELECT * FROM Products WHERE ProductID = 1;
WAITFOR DELAY '00:00:10';
COMMIT;
```

```sql
-- Session 2
UPDATE Products SET Stock = Stock + 1 WHERE ProductID = 1;
```

---

## 5. ⚠️ Deadlock Simulation

```sql
-- Session A
BEGIN TRANSACTION;
UPDATE Products SET Stock = Stock - 1 WHERE ProductID = 1;
WAITFOR DELAY '00:00:05';
UPDATE Products SET Stock = Stock - 1 WHERE ProductID = 2;
COMMIT;
```

```sql
-- Session B
BEGIN TRANSACTION;
UPDATE Products SET Stock = Stock - 1 WHERE ProductID = 2;
WAITFOR DELAY '00:00:05';
UPDATE Products SET Stock = Stock - 1 WHERE ProductID = 1;
COMMIT;
```

> 💡 Avoid deadlocks by accessing rows in the same order and keeping transactions short.
