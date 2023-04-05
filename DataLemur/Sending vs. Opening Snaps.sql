/*
Assume you are given the tables below containing information on Snapchat users, their ages, and their time spent sending and opening snaps. Write a query to obtain a breakdown of the time spent sending vs. opening snaps (as a percentage of total time spent on these activities) for each age group.

Output the age bucket and percentage of sending and opening snaps. Round the percentage to 2 decimal places.

Notes:

You should calculate these percentages:
time sending / (time sending + time opening)
time opening / (time sending + time opening)
To avoid integer division in percentages, multiply by 100.0 and not 100.
activities Table:
Column Name	Type
activity_id	integer
user_id	integer
activity_type	string ('send', 'open', 'chat')
time_spent	float
activity_date	datetime
activities Example Input:
activity_id	user_id	activity_type	time_spent	activity_date
7274	123	open	4.50	06/22/2022 12:00:00
2425	123	send	3.50	06/22/2022 12:00:00
1413	456	send	5.67	06/23/2022 12:00:00
1414	789	chat	11.00	06/25/2022 12:00:00
2536	456	open	3.00	06/25/2022 12:00:00
age_breakdown Table:
Column Name	Type
user_id	integer
age_bucket	string ('21-25', '26-30', '31-25')
age_breakdown Example Input:
user_id	age_bucket
123	31-35
456	26-30
789	21-25
Example Output:
age_bucket	send_perc	open_perc
26-30	65.40	34.60
31-35	43.75	56.25
Explanation
For the age bucket 26-30, the time spent sending snaps was 5.67 and opening 3. The percent of time sending snaps was 5.67/(5.67+3)=65.4%, and the percent of time opening snaps was 3/(5.67+3)=34.6%.

The dataset you are querying against may have different input & output - this is just an example!

*/


SELECT  TA.age_bucket, 
        TRUNC(ROUND(send_time/(send_time+open_time)*100.0,2),2) AS send_perc,
        TRUNC(ROUND(open_time/(open_time+send_time)*100.0,2),2) AS open_perc
FROM
(
  SELECT AB.age_bucket,  
         sum(case when activity_type= 'open' then time_spent else 0 end ) as open_time,
         sum(case when activity_type= 'send' then time_spent else 0 end ) as send_time
  
  FROM activities A 
  JOIN age_breakdown AB
  on A.user_id = AB.user_id
  WHERE A.activity_type in ('open','send')
  GROUP BY age_bucket
)TA
--select * FROM activities