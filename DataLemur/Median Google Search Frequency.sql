/*
Google's marketing team is making a Superbowl commercial and needs a simple statistic to put on their TV ad: the median number of searches a person made last year.

However, at Google scale, querying the 2 trillion searches is too costly. Luckily, you have access to the summary table which tells you the number of searches made last year and how many Google users fall into that bucket.

Write a query to report the median of searches made by a user. Round the median to one decimal point.

search_frequency Table:
Column Name	Type
searches	integer
num_users	integer
search_frequency Example Input:
searches	num_users
1	2
2	2
3	3
4	1
Example Output:
median
2.5
By expanding the search_frequency table, we get [1, 1, 2, 2, 3, 3, 3, 4] which has a median of 2.5 searches per user.
*/
SELECT 
round(((
select MAX(TA.searches)
FROM
(
SELECT  searches
FROM search_frequency 
cross join generate_series(1, num_users)
order by searches ASC
limit (select sum(num_users) from search_frequency) /2
)TA
)
+
(
select min(TA.searches)
FROM
(
SELECT  searches
FROM search_frequency 
cross join generate_series(1, num_users)
order by searches DESC
limit (select sum(num_users) from search_frequency) /2
)TA
))/2.0, 1)


/*select MIN(TA.searches), (4+3)/2.0
FROM
(
SELECT  searches
FROM search_frequency 
cross join generate_series(1, num_users)
order by searches DESC
limit (select sum(num_users) from search_frequency) /2
)TA*/

/*SELECT  searches
FROM search_frequency 
cross join generate_series(1, num_users)
order by searches DESC
limit (select sum(num_users) from search_frequency) /2*/