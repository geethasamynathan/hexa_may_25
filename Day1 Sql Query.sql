create database Hexa_May_25
use Hexa_May_25

create table Employee
(
id int identity(101,1),
name varchar(20),
gender varchar(10),
location varchar(50),
doj date,
salary money
)

insert into Employee
values ('Hariharan','Male','chennai','1-6-2025',35000),
 ('Alhan','Male','Hyderabad','6-6-2025',36000)
,('Arun','Male','Bangalore','10-6-2025',37000)
, ('Geethica','Female','chennai','1-6-2025',38000)
, ('Nithya sri','Female','Hyderabad','10-6-2025',39000)


select * from Employee


-- Example for Stored procedure without param
CREATE PROCEDURE usp_GetAllEmployees
AS
BEGIN
SELECT * FROM  Employee
END

EXECUTE usp_GetAllEmployees
EXEC usp_GetAllEmployees
usp_GetAllEmployees


--alter procedure
ALTER PROC usp_GetAllEmployees
AS
BEGIN
SELECT id,name,gender,location FROM Employee
END



drop proc usp_GetAllEmployees


--stored procedure with input(or) in parameter

CREATE PROC  Usp_GetEmployeeById
(@empid as int)
AS
BEGIN 
SELECT ID,NAME,GENDER,LOCATION FROM EMPLOYEE WHERE ID=@empid
END

Usp_GetEmployeeById 102

CREATE PROC usp_GetEmployeebyGenderLocation
(@gender as varchar(10),
@location as varchar(50)
)
AS
BEGIN
SELECT * FROM Employee WHERE gender=@gender AND LOCATION=@location
END

EXEC usp_GetEmployeebyGenderLocation 'Male','Chennai'


-- named parameter
EXEC usp_GetEmployeebyGenderLocation @gender='Male',@location='Chennai'
EXEC usp_GetEmployeebyGenderLocation @location='Chennai',@gender='Female'

--stored procedure with default values
ALTER PROC usp_GetEmployeebyGenderLocation
(@gender as varchar(10)='Male',
@location as varchar(50)
)
AS
BEGIN
SELECT * FROM Employee WHERE gender=@gender AND LOCATION=@location
END

EXEC usp_GetEmployeebyGenderLocation @location='Chennai'
EXEC usp_GetEmployeebyGenderLocation @gender='Female',@location='Chennai'


CREATE PROC Usp_AddNewEmployee(
@name varchar(20),@gender  varchar(10),@location varchar(50)
)
AS
BEGIN
INSERT INTO EMPLOYEE (NAME,GENDER,LOCATION) VALUES (@NAME,@GENDER,@LOCATION)
END

EXEC Usp_AddNewEmployee @gender='Male' ,@name='Allen',@location='bangalore'

select * from Employee

---stored procedure with in,ot paramater
CREATE PROC Usp_GetEmployeeSalaryById(@ID INT,
@salary money OUTPUT)
AS
BEGIN
select @salary=salary from employee where id=@id
END

declare @salary money
exec Usp_GetEmployeeSalaryById 106, @salary out
select @salary

DECLARE @ename varchar(40) --variable declaration
--set @ename='Peter'-- assigning the valu for variable
select @ename=name from employee where id=101
print @ename -- printing variable value




CREATE PROCEDURE usp_CountEmployeesByLocation
    @Location NVARCHAR(50),
    @TotalEmployees INT OUTPUT
AS
BEGIN
    SELECT @TotalEmployees = COUNT(*)
    FROM Employee
    WHERE location = @Location
END

select * from Employee

DECLARE @Count INT
EXEC usp_CountEmployeesByLocation @Location = 'Ahamadabad', @TotalEmployees = @Count OUTPUT
IF @count>0
SELECT @Count AS TotalEmployees
ELSE
print 'No Employee found in Given Locations'


--Scaler function 

CREATE FUNCTION CalculateBonus(@salary decimal)
Returns Decimal(10,2)
as
begin
return @salary*0.10
end

drop function dbo.CalculateBonus
SELECT id, name ,gender,location, salary,dbo.CalculateBonus(salary) as BONUS
FROM Employee

--Inline Table Valued Function
CREATE FUNCTION dbo.GetEmployeeDetailsByLocation(@location varchar(50))
RETURNS TABLE
AS
RETURN SELECT id,name,gender,location From Employee where location=@location


select * From dbo.GetEmployeeDetailsByLocation('Bangalore')


--Multi-statement table valued function
CREATE FUNCTION HighSalaryEmployee(@avgsalary decimal)
RETURNS @HighEarners TABLE(
id int,
name varchar(20),
salary decimal(10,2)
)
AS
BEGIN
insert into @HighEarners 
select id,name,salary from Employee where salary>@avgsalary
return
END


select * from dbo.HighSalaryEmployee(36000)
