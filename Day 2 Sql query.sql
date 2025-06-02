CREATE TABLE tblEmployee
(
  Id int Primary Key,
  Name nvarchar(30),
  Salary int,
  Gender nvarchar(10),
  DepartmentId int
)

select * from tblEmployee

--Insert data into tblEmployee table
Insert into tblEmployee
values (1,'Parivalavan', 5000, 'Male', 3),
 (2,'Alhan', 3400, 'Male', 2),
(3,'Vedhitha', 6000, 'Female', 1)


CREATE TABLE tblEmployeeAudit(
Id int primary key identity(11,1),
AuditData varchar(max) 
)

select * from tblEmployeeAudit


-- Trigger

CREATE TRIGGER tr_tblEmployee_insert
ON TblEmployee
FOR INSERT
AS
BEGIN
DECLARE @Id INT
SELECT @Id=id from INSERTED

INSERT INTO tblEmployeeAudit VALUES ('New Employee with Id= '+CAST(@id as varchar(5))+' is added at '+
cast(Getdate() as nvarchar(20)))
END


select * from tblEmployee
select * from tblEmployeeAudit
insert into tblEmployee values (4,'santo',4554,'Male',2)


CREATE TRIGGER TR_TBLeMPLOYEE_delete
ON TblEmployee
FOR DELETE
AS
BEGIN
DECLARE @Id INT
SELECT @Id=id from deleted

INSERT INTO tblEmployeeAudit VALUES (' Employee with the Id= '+cast(@Id as varchar(5)) +'Deleted at ' 
+cast(getdate() as varchar(20)))
END


select * from tblEmployee
select * from tblEmployeeAudit

delete from tblEmployee where id=4

alter trigger tr_tblEmployee_ForUpdate
on tblEmployee
for Update
as
Begin
      -- Declare variables to hold old and updated data
      Declare @Id int
      Declare @OldName nvarchar(20), @NewName nvarchar(20)
      Declare @OldSalary int, @NewSalary int
      Declare @OldGender nvarchar(20), @NewGender nvarchar(20)
      Declare @OldDeptId int, @NewDeptId int
     
      -- Variable to build the audit string
      Declare @AuditString nvarchar(1000)
      
      -- Load the updated records into temporary table
      Select *
      into #TempTable
      from inserted
     
      -- Loop thru the records in temp table
      While(Exists(Select Id from #TempTable))
      Begin
            --Initialize the audit string to empty string
            Set @AuditString = ''
           
            -- Select first row data from temp table
            Select Top 1 @Id = Id, @NewName = Name, 
            @NewGender = Gender, @NewSalary = Salary,
            @NewDeptId = DepartmentId
            from #TempTable
           
            -- Select the corresponding row from deleted table
            Select @OldName = Name, @OldGender = Gender, 
            @OldSalary = Salary, @OldDeptId = DepartmentId
            from deleted where Id = @Id
   
     -- Build the audit string dynamically           
            Set @AuditString = 'Employee with Id = ' + Cast(@Id as nvarchar(4)) + ' changed'
            if(@OldName <> @NewName)
                  Set @AuditString = @AuditString + ' NAME from ' + @OldName + ' to ' + @NewName
                 
            if(@OldGender <> @NewGender)
                  Set @AuditString = @AuditString + ' GENDER from ' + @OldGender + ' to ' + @NewGender
                 
            if(@OldSalary <> @NewSalary)
                  Set @AuditString = @AuditString + ' SALARY from ' + Cast(@OldSalary as nvarchar(10))+ ' to ' + Cast(@NewSalary as nvarchar(10))
                  
     if(@OldDeptId <> @NewDeptId)
                  Set @AuditString = @AuditString + ' DepartmentId from ' + Cast(@OldDeptId as nvarchar(10))+ ' to ' + Cast(@NewDeptId as nvarchar(10))
           
            insert into tblEmployeeAudit values(@AuditString)
            
            -- Delete the row from temp table, so we can move to the next row
            Delete from #TempTable where Id = @Id
      End
End

select * from tblEmployee
select * from tblEmployeeAudit

update tblEmployee set Name='Peter',Gender='Male',salary=4500 where id=1


--instead of Trigger

CREATE TRIGGER trg_PreventDropEmployee
ON DATABASE
FOR DROP_TABLE
AS
BEGIN
    DECLARE @eventData XML = EVENTDATA();
    IF @eventData.value('(/EVENT_INSTANCE/ObjectName)[1]', 'NVARCHAR(128)') = 'Employee'
    BEGIN
        PRINT 'Dropping the Employee table is not allowed!';
        ROLLBACK;
    END
END;

drop table Employee


select * from Employee

/*
Assignment -1
Create an AFTER INSERT trigger that updates the inventory count in the `products` 
table whenever a new sale is recorded in the `sales` table.

**Instructions:**
1. Create an AFTER INSERT trigger named `update_inventory_after_sale`.
2. The trigger should decrease the `stock_quantity` in the `products` table based on the `quantity` sold in the `sales` table.

**Answer:**

*/


select * from production.stocks
select * from production.products

CREATE TRIGGER update_inventory_after_sale
ON sales.order_items
AFTER INSERT
AS
BEGIN
    -- Update stock based on order_items inserted
    UPDATE s
    SET s.quantity = s.quantity - i.quantity
    FROM production.stocks s
    JOIN sales.orders o ON s.store_id = o.store_id
    JOIN inserted i ON o.order_id = i.order_id AND s.product_id = i.product_id
END


-- Before sale
SELECT * FROM production.stocks WHERE product_id = 1 AND store_id = 1

-- Insert a new order
INSERT INTO sales.orders ( customer_id, order_status, order_date, required_date, store_id, staff_id)
VALUES ( 1, 1, GETDATE(), GETDATE(), 1, 1)

select * from sales.orders where order_date=getdate()
INSERT INTO sales.order_items (order_id, item_id, product_id, quantity, list_price, discount)
VALUES (1617, 1, 1, 2, 500, 0)

-- After sale
SELECT * FROM production.stocks WHERE product_id = 1 AND store_id = 1



/* Transaction */

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


BEGIN TRANSACTION;

IF(EXISTS(SELECT 1 FROM Products WHERE ProductID=1 AND StockQuantity>=1))
BEGIN
--UPDATE THE PRODUCT STOCK
UPDATE Products SET StockQuantity=StockQuantity-1
WHERE ProductID=1

--UPDATE CUSTOMERS BALANCE
UPDATE Customers SET Balance=Balance-299
WHERE CustomerID=1

insert into Orders (orderId,CustomerID,OrderDate,TotalAmount,Status) values
(101,1,GETDATE(),299,'Completed')

COMMIT TRANSACTION

END


select * from Customers

select * from Products

Select * from orders

--rollBack Transaction
BEGIN TRAN
DECLARE @Totalcost decimal(10,2)=299*5

-- check the customer balance
if(Exists(select 1 from Customers where CustomerID=3 and Balance >= @Totalcost))
BEGIN
 
update Products set StockQuantity=StockQuantity-5
where ProductID=1

update Customers set Balance=Balance-@Totalcost
where CustomerID=3
COMMIT TRANSACTION
END
ELSE
BEGIN
ROLLBACK TRANSACTION;
PRINT('Insufficient Balance');
END

/*
Assignment 1: Commit After Updating Stock
Task:
Write a transaction to:

Reduce the quantity of a product (product_id = 101) by 2 in the stocks table (for store_id = 1).

Commit the transaction only if the quantity does not go negative.
*/
BEGIN TRAN;

DECLARE @productId INT = 101;
DECLARE @storeId INT = 1;
DECLARE @quantityToReduce INT = 2;
DECLARE @currentStock INT;

SELECT @currentStock = quantity
FROM production.stocks
WHERE product_id = @productId AND store_id = @storeId;

IF @currentStock >= @quantityToReduce
BEGIN
    UPDATE production.stocks
    SET quantity = quantity - @quantityToReduce
    WHERE product_id = @productId AND store_id = @storeId;

    COMMIT TRAN;
    PRINT 'Stock updated and transaction committed.';
END
ELSE
BEGIN
    ROLLBACK TRAN;
    PRINT 'Insufficient stock. Transaction rolled back.';
END
