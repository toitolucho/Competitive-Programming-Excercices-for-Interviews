/*
Write an SQL query to find the employees who earn more than their managers.

Return the result table in any order.
*/

drop table Employee
CREATE TABLE Employee
(
	id          int     ,
	name        varchar(100) ,
	salary      int     ,
	managerId   int     
)

insert into Employee values(1,'Joe   ', 70000 , 3   )
insert into Employee values(2,'Henry ', 80000 , 4   )
insert into Employee values(3,'Sam   ', 60000 , Null)
insert into Employee values(4,'Max   ', 90000 , Null)


select e1.name--, e1.salary, e2.name as Manager, e2.salary
from Employee E1
join Employee E2
on e1.managerId = e2.id
where e1.salary > e2.salary