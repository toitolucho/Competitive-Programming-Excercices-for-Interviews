
/*A company's executives are interested in seeing who earns the most money in each of the company's departments. A high earner in a department is an employee who has a salary in the top three unique salaries for that department.

Write an SQL query to find the employees who are high earners in each of the departments.

Return the result table in any order.

The query result format is in the following example.*/

CREATE TABLE Employee
(
	id          int     ,
	name        varchar(100) ,
	salary      int     ,
	departmentId    int     
)
DELETE FROM Employee


CREATE TABLE Department
(
	id int  ,
	name varchar(100)
)
DELETE FROM Department

INSERT INTO Employee VALUES(1,'Joe  ', 85000 ,1)
INSERT INTO Employee VALUES(2,'Henry', 80000 ,2)
INSERT INTO Employee VALUES(3,'Sam  ', 60000 ,2)
INSERT INTO Employee VALUES(4,'Max  ', 90000 ,1)
INSERT INTO Employee VALUES(5,'Janet', 69000 ,1)
INSERT INTO Employee VALUES(6,'Randy', 85000 ,1)
INSERT INTO Employee VALUES(7,'Will ', 70000 ,1)

INSERT INTO Department VALUES(1 ,'IT   ' )
INSERT INTO Department VALUES(2 ,'Sales' )


select D.name as Department, E.name as Employee, E.salary--, E.departmentId
from Employee E
join Department D
on E.departmentId = D.id
join
(
	SELECT departmentId, salary, ROW_NUMBER() OVER (PARTITION BY departmentId ORDER BY salary DESC) Position
	FROM Employee
	GROUP BY departmentId, salary
)TA
ON TA.departmentId = E.departmentId
AND E.salary = TA.salary
AND TA.Position<4
ORDER BY D.name, E.salary DESC