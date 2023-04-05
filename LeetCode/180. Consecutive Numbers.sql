/*Write an SQL query to find all numbers that appear at least three times consecutively.

Return the result table in any order.*/

CREATE TABLE Logs
(
	id int ,
	num varchar(100)

)

INSERT INTO Logs VALUES(0 ,1)
INSERT INTO Logs VALUES(1 ,1)
INSERT INTO Logs VALUES(2 ,1)
INSERT INTO Logs VALUES(3 ,1)
INSERT INTO Logs VALUES(4 ,2)
INSERT INTO Logs VALUES(5 ,1)
INSERT INTO Logs VALUES(6 ,2)
INSERT INTO Logs VALUES(7 ,2)
INSERT INTO Logs VALUES(8 ,2)
--delete from logs where id = 8
--select *, lag(num,1) over (order by id)--, ROW_NUMBER() OVER(partition by num order by num)
--from Logs
--order by id



SELECT distinct num ConsecutiveNums
FROM
(	SELECT	id, num,
			lag(num) over (order by id) as antes,
			lead(num) over (order by id) as despues
	FROM logs
) TA
WHERE num=antes and antes =despues