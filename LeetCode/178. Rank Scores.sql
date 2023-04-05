/*Write an SQL query to rank the scores. The ranking should be calculated according to the following rules:

The scores should be ranked from the highest to the lowest.
If there is a tie between two scores, both should have the same ranking.
After a tie, the next ranking number should be the next consecutive integer value. In other words, there should be no holes between ranks.
Return the result table ordered by score in descending order.

The query result format is in the following example.*/

CREATE TABLE Scores
(
	id int ,
	score    FLOAT
)

INSERT INTO Scores VALUES(1 ,3.50)
INSERT INTO Scores VALUES(2 ,3.65)
INSERT INTO Scores VALUES(3 ,4.00)
INSERT INTO Scores VALUES(4 ,3.85)
INSERT INTO Scores VALUES(5 ,4.00)
INSERT INTO Scores VALUES(6 ,3.65)


SELECT score, DENSE_RANK() over(order by score desc) as rank 
FROM Scores
ORDER BY score desc
