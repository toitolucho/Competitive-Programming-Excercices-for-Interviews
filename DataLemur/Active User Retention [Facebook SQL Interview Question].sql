/*
Assume you have the table below containing information on Facebook user actions. Write a query to obtain the active user retention in July 2022. Output the month (in numerical format 1, 2, 3) and the number of monthly active users (MAUs).

Hint: An active user is a user who has user action ("sign-in", "like", or "comment") in the current month and last month.

user_actions Table:
Column Name	Type
user_id	integer
event_id	integer
event_type	string ("sign-in, "like", "comment")
event_date	datetime
user_actionsExample Input:
user_id	event_id	event_type	event_date
445	7765	sign-in	05/31/2022 12:00:00
742	6458	sign-in	06/03/2022 12:00:00
445	3634	like	06/05/2022 12:00:00
742	1374	comment	06/05/2022 12:00:00
648	3124	like	06/18/2022 12:00:00
Example Output for June 2022:
month	monthly_active_users
6	1
Example
In June 2022, there was only one monthly active user (MAU), user_id 445.

Note: We are showing you output for June 2022 as the user_actions table only have event_dates in June 2022. You should work out the solution for July 2022.
*/

SELECT 7 AS mth, count(DISTINCT TA1.user_id) as monthly_active_users
FROM
(
SELECT user_id
FROM user_actions
where EXTRACT(month FROM event_date) = 7
and event_type in ('sign-in', 'like','comment')
)TA1
JOIN
(
SELECT user_id
FROM user_actions
where EXTRACT(month FROM event_date) = 6
and event_type in ('sign-in', 'like','comment')
)TA2
ON TA1.user_id = TA2.user_id 
--GROUP BY ta1.user_id