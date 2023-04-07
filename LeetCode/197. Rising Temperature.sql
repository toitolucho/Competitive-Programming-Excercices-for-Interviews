/*
Write an SQL query to find all dates' Id with higher temperatures compared to its previous dates (yesterday).

Return the result table in any order.

The query result format is in the following example.
*/

CREATE TABLE Weather
(
	id          int ,
	recordDate  date,
	temperature int 
)

INSERT INTO Weather VALUES(1 ,'2015-01-01',10)
INSERT INTO Weather VALUES(2 ,'2015-01-02',25)
INSERT INTO Weather VALUES(3 ,'2015-01-03',20)
INSERT INTO Weather VALUES(4 ,'2015-01-04',30)
/*
Input: 
Weather table:
+----+------------+-------------+
| id | recordDate | temperature |
+----+------------+-------------+
| 1  | 2015-01-01 | 10          |
| 2  | 2015-01-02 | 25          |
| 3  | 2015-01-03 | 20          |
| 4  | 2015-01-04 | 30          |
+----+------------+-------------+
Output: 
+----+
| id |
+----+
| 2  |
| 4  |
+----+
Explanation: 
In 2015-01-02, the temperature was higher than the previous day (10 -> 25).
In 2015-01-04, the temperature was higher than the previous day (20 -> 30).
*/
--SELECT w1.id, w2.id, w1.recordDate, w2.recordDate, w1.temperature, w2.temperature 
--FROM Weather W1, Weather W2
--where W1.recordDate >= w2.recordDate
SELECT TA.ID
FROM
(
	select *, LAG(recordDate)  over(order by recordDate) DateAfter,LAG(temperature) over(order by recordDate) TemperatureAfter
	from Weather	
)TA
--where DATEDIFF(DAY, recordDate, DateAfter)=1
where temperature>TemperatureAfter
and DATEDIFF(DAY, DateAfter, recordDate) = 1
ORDER BY TA.recordDate
