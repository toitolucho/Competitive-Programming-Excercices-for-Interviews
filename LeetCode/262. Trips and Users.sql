CREATE TABLE Trips
(
	id         INT, 
	client_id  INT, 
	driver_id  INT, 
	city_id    INT, 
	status     VARCHAR(100), 
	request_at DATE  
)
CREATE TABLE Users
(
	users_id   int ,
	banned     VARCHAR(100),
	role       VARCHAR(100)
)

INSERT INTO Trips VALUES(1 , 1 , 10, 1  , 'completed          ','2013-10-01')
INSERT INTO Trips VALUES(2 , 2 , 11, 1  , 'cancelled_by_driver','2013-10-01')
INSERT INTO Trips VALUES(3 , 3 , 12, 6  , 'completed          ','2013-10-01')
INSERT INTO Trips VALUES(4 , 4 , 13, 6  , 'cancelled_by_client','2013-10-01')
INSERT INTO Trips VALUES(5 , 1 , 10, 1  , 'completed          ','2013-10-02')
INSERT INTO Trips VALUES(6 , 2 , 11, 6  , 'completed          ','2013-10-02')
INSERT INTO Trips VALUES(7 , 3 , 12, 6  , 'completed          ','2013-10-02')
INSERT INTO Trips VALUES(8 , 2 , 12, 12 , 'completed          ','2013-10-03')
INSERT INTO Trips VALUES(9 , 3 , 10, 12 , 'completed          ','2013-10-03')
INSERT INTO Trips VALUES(10, 4 , 13, 12 , 'cancelled_by_driver','2013-10-03')
INSERT INTO Trips VALUES(1 , 1 ,10 , 1  , 'cancelled_by_client','2013-10-04')

INSERT INTO Users VALUES(1  ,'No ','client')
INSERT INTO Users VALUES(2  ,'Yes','client')
INSERT INTO Users VALUES(3  ,'No ','client')
INSERT INTO Users VALUES(4  ,'No ','client')
INSERT INTO Users VALUES(10 ,'No ','driver')
INSERT INTO Users VALUES(11 ,'No ','driver')
INSERT INTO Users VALUES(12 ,'No ','driver')
INSERT INTO Users VALUES(13 ,'No ','driver')


/*The cancellation rate is computed by dividing the number of canceled (by client or driver) requests with unbanned users by the total number of requests with unbanned users on that day.

Write a SQL query to find the cancellation rate of requests with unbanned users (both client and driver must not be banned) each day between "2013-10-01" and "2013-10-03". Round Cancellation Rate to two decimal points.

Return the result table in any order.

Output: 
+------------+-------------------+
| Day        | Cancellation Rate |
+------------+-------------------+
| 2013-10-01 | 0.33              |
| 2013-10-02 | 0.00              |
| 2013-10-03 | 0.50              |
+------------+-------------------+
Explanation: 
On 2013-10-01:
  - There were 4 requests in total, 2 of which were canceled.
  - However, the request with Id=2 was made by a banned client (User_Id=2), so it is ignored in the calculation.
  - Hence there are 3 unbanned requests in total, 1 of which was canceled.
  - The Cancellation Rate is (1 / 3) = 0.33
On 2013-10-02:
  - There were 3 requests in total, 0 of which were canceled.
  - The request with Id=6 was made by a banned client, so it is ignored.
  - Hence there are 2 unbanned requests in total, 0 of which were canceled.
  - The Cancellation Rate is (0 / 2) = 0.00
On 2013-10-03:
  - There were 3 requests in total, 1 of which was canceled.
  - The request with Id=8 was made by a banned client, so it is ignored.
  - Hence there are 2 unbanned request in total, 1 of which were canceled.
  - The Cancellation Rate is (1 / 2) = 0.50

*/
SELECT TA.request_at AS Day, CAST(ROUND( (TA.Quantity-TA.CompletedCount)/(Quantity*1.0),2) AS DECIMAL(10,2)) AS  [Cancellation Rate]
FROM
(
	SELECT 	T.request_at, 
			--if you want be more efficient, try to make the calculations in this part, instead of creating a subquery, considering that this part will be taked in the memory as a temporary table.
			SUM(CASE WHEN RTRIM(T.status) = 'completed' THEN 1 ELSE 0 END) CompletedCount, COUNT(status) Quantity
	FROM Trips T
	JOIN Users U1
	on T.client_id = U1.users_id
	join Users U2
	ON T.driver_id = U2.users_id
	--Must be sure that even user or driver not be banned
	WHERE (U1.banned <> 'Yes' AND U2.banned <> 'Yes')
	--take care that there are restriction in the date, it must be between these values
	AND T.request_at between '2013-10-01' and '2013-10-03'
	GROUP BY T.request_at
)TA


