/*
Write an SQL query to report all customers who never order anything.

Return the result table in any order.
*/

create table Customers
(
id         int,
name       varchar(100)
)

create table Orders
(
	id          int,
	customerId  int
)

INSERT INTO Customers VALUES (1,'Joe  ')
INSERT INTO Customers VALUES (2,'Henry')
INSERT INTO Customers VALUES (3,'Sam  ')
INSERT INTO Customers VALUES (4,'Max  ')

INSERT INTO Orders VALUES (1 ,  3)
INSERT INTO Orders VALUES (2 ,  1) 
SELECT * FROM Orders
SELECT * FROM Customers

select C.name as Customers
from Customers C
left join Orders O
on C.id = o.customerId
where o.id is null