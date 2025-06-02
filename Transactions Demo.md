


# Database Transaction Concepts with E-commerce Examples

## Database Structure

```sql
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    Name VARCHAR(100),
    Email VARCHAR(100),
    Balance DECIMAL(10,2)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    Name VARCHAR(100),
    Price DECIMAL(10,2),
    StockQuantity INT
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    OrderDate DATETIME,
    TotalAmount DECIMAL(10,2),
    Status VARCHAR(20)
);
```

## Initial Sample Data

**Customers Table:**
| CustomerID | Name        | Email           | Balance |
|------------|-------------|-----------------|---------|
| 1          | John Doe    | john@email.com  | 1000.00 |
| 2          | Jane Smith  | jane@email.com  | 1500.00 |
| 3          | Bob Wilson  | bob@email.com   |  800.00 |

**Products Table:**
| ProductID | Name       | Price  | StockQuantity |
|-----------|------------|--------|---------------|
| 1         | Laptop     | 999.99 | 10           |
| 2         | Smartphone | 499.99 | 20           |
| 3         | Tablet     | 299.99 | 15           |

## 1. COMMIT Example (Successful Order)

> **Scenario:** Customer John Doe purchases a laptop

```sql
BEGIN TRANSACTION;
    -- Check stock availability
    IF EXISTS (SELECT 1 FROM Products WHERE ProductID = 1 AND StockQuantity >= 1)
    BEGIN
        -- Update product stock
        UPDATE Products 
        SET StockQuantity = StockQuantity - 1 
        WHERE ProductID = 1;
        
        -- Update customer balance
        UPDATE Customers 
        SET Balance = Balance - 999.99 
        WHERE CustomerID = 1;
        
        -- Create order record
        INSERT INTO Orders (CustomerID, OrderDate, TotalAmount, Status)
        VALUES (1, GETDATE(), 999.99, 'Completed');
        
        COMMIT TRANSACTION;
    END
```

**Result After Successful Transaction:**
- Laptop stock reduced by 1 (9 remaining)
- John's balance decreased by $999.99 ($0.01 remaining)
- New order record created

## 2. ROLLBACK Example (Insufficient Funds)

> **Scenario:** Bob Wilson attempts to buy 5 tablets but has insufficient funds

```sql
BEGIN TRANSACTION;
    DECLARE @TotalCost DECIMAL(10,2) = 299.99 * 5;
    
    -- Check customer balance
    IF EXISTS (SELECT 1 FROM Customers 
              WHERE CustomerID = 3 AND Balance >= @TotalCost)
    BEGIN
        -- Process order
        UPDATE Products 
        SET StockQuantity = StockQuantity - 5 
        WHERE ProductID = 3;
        
        UPDATE Customers 
        SET Balance = Balance - @TotalCost 
        WHERE CustomerID = 3;
    END
    ELSE
    BEGIN
        ROLLBACK TRANSACTION;
        RAISERROR ('Insufficient funds', 16, 1);
    END
```

**Result:** Transaction rolled back, no changes made to database

## 3. DEADLOCK Example

> **Scenario:** Two concurrent transactions trying to update the same resources

```sql
-- Transaction 1
BEGIN TRANSACTION;
    UPDATE Products SET StockQuantity = StockQuantity - 1 
    WHERE ProductID = 1;  -- Locks Product 1
    
    -- Tries to update Product 2 (blocked by Transaction 2)
    UPDATE Products SET StockQuantity = StockQuantity - 1 
    WHERE ProductID = 2;

-- Transaction 2 (concurrent)
BEGIN TRANSACTION;
    UPDATE Products SET StockQuantity = StockQuantity - 1 
    WHERE ProductID = 2;  -- Locks Product 2
    
    -- Tries to update Product 1 (blocked by Transaction 1)
    UPDATE Products SET StockQuantity = StockQuantity - 1 
    WHERE ProductID = 1;
```

**Deadlock Resolution:**
- SQL Server detects the deadlock
- Chooses one transaction as deadlock victim (typically Transaction 2)
- Rolls back the victim transaction
- Allows the surviving transaction to complete

## Best Practices and Guidelines

1. **Transaction Scope:**
   - Keep transactions as short as possible
   - Include only necessary operations
   - Avoid user interaction during transactions

2. **Error Handling:**
   ```sql
   BEGIN TRY
       BEGIN TRANSACTION;
           -- Transaction logic here
       COMMIT TRANSACTION;
   END TRY
   BEGIN CATCH
       ROLLBACK TRANSACTION;
       -- Error handling logic
   END CATCH
   ```

3. **Deadlock Prevention:**
   - Access objects in the same order across all transactions
   - Keep transactions short
   - Use appropriate isolation levels
   - Consider using NOWAIT or READPAST hints where appropriate

4. **Performance Considerations:**
   - Use appropriate isolation levels
   - Avoid holding locks longer than necessary
   - Consider using optimistic concurrency for read-heavy operations

This example demonstrates how transactions maintain data consistency in a real-world e-commerce system, handling scenarios like order processing, inventory management, and concurrent access to shared resources.