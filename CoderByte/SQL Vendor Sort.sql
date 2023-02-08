/*
SQL Challenge
Your table: maintable_264XW

MySQL version: 8.0.23

In this MySQL challenge, your query should return the vendor information along with the values from the table cb_vendorinformation. You should combine the values of the two tables based on the GroupID column. The final query should consolidate the rows to be grouped by FirstName, and a Count column should be added at the end that adds up the number of times that person shows up in the table. The output table should be sorted by the Count column in ascending order and then sorted by CompanyName in alphabetical order. Your output should look like the following table.

*/

SELECT A.GroupId, A.FirstName, A.LastName, A.Job, A.ExternalID, B.CompanyName, count(A.GroupId) 'Count'
FROM maintable_264XW A
left join cb_vendorinformation B
on A.GroupId = B.GroupId
group by FirstName
order by 7 asc, B.CompanyName
