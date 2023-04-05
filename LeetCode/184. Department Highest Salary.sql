/*
Write an SQL query to find employees who have the highest salary in each of the departments.

Return the result table in any order.
*/

CREATE TABLE Employee
(
	id          int     ,
	name        varchar(100) ,
	salary      int     ,
	departmentId    int     
)

CREATE TABLE Department
(
	id int  ,
	name varchar(100)
)

INSERT INTO Employee VALUES(1 , 'Joe  ', 70000,1)
INSERT INTO Employee VALUES(2 , 'Jim  ', 90000,1)
INSERT INTO Employee VALUES(3 , 'Henry', 80000,2)
INSERT INTO Employee VALUES(4 , 'Sam  ', 60000,2)
INSERT INTO Employee VALUES(5 , 'Max  ', 90000,1)

INSERT INTO Department VALUES(1 ,'IT   ' )
INSERT INTO Department VALUES(2 ,'Sales' )

select * from Employee
select * from Department

select D.name as Department, E.name as Employee, E.salary
from Employee E
join Department D
on E.departmentId = D.id
join
(
select departmentId, max(salary) max_salary
from Employee
group by departmentId
) TA
on D.id = TA.departmentId
where E.salary = max_salary