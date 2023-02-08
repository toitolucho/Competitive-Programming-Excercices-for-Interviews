
/*SQL Challenge
Your table: maintable_LJJIY

MySQL version: 8.0.23

In this MySQL challenge, your query should return the information for the employee with the third highest salary. Write a query that will find this employee and return that row, but then replace the DivisionID column with the corresponding DivisionName from the table cb_companydivisions. You should also replace the ManagerID column with the ManagerName if the ID exists in the table and is not NULL.

Your output should look like the following table.*/

SELECT TA.Id, Ta.Name, TB.DivisionName, TC.Name 'ManagerName', ta.Salary
FROM
(
SELECT ID, ROW_NUMBER( ) OVER (ORDER BY SALARY DESC) 'Position', DivisionId, Name, ManagerID, Salary
FROM maintable_LJJIY
) TA
INNER JOIN cb_companydivisions TB
ON TA.DivisionId = TB.ID
LEFT JOIN maintable_LJJIY TC
ON TA.ManagerId = TC.ID
where ta.Position = 3

