/*

Assume there are three Spotify tables containing information about the artists, songs, and music charts. Write a query to determine the top 5 artists whose songs appear in the Top 10 of the global_song_rank table the highest number of times. From now on, we'll refer to this ranking number as "song appearances".

Output the top 5 artist names in ascending order along with their song appearances ranking (not the number of song appearances, but the rank of who has the most appearances). The order of the rank should take precedence.

For example, Ed Sheeran's songs appeared 5 times in Top 10 list of the global song rank table; this is the highest number of appearances, so he is ranked 1st. Bad Bunny's songs appeared in the list 4, so he comes in at a close 2nd.

Assumptions:

If two artists' songs have the same number of appearances, the artists should have the same rank.
The rank number should be continuous (1, 2, 2, 3, 4, 5) and not skipped (1, 2, 2, 4, 5).
artists Table:
Column Name	Type
artist_id	integer
artist_name	varchar
artists Example Input:
artist_id	artist_name
101	Ed Sheeran
120	Drake
songs Table:
Column Name	Type
song_id	integer
artist_id	integer
songs Example Input:
song_id	artist_id
45202	101
19960	120
global_song_rank Table:
Column Name	Type
day	integer (1-52)
song_id	integer
rank	integer (1-1,000,000)
global_song_rank Example Input:
day	song_id	rank
1	45202	5
3	45202	2
1	19960	3
9	19960	15
Example Output:
artist_name	artist_rank
Ed Sheeran	1
Drake	2
Explanation
Ed Sheeran's song appeared twice in the Top 10 list of global song rank while Drake's song is only listed once. Therefore, Ed is ranked #1 and Drake is ranked #2.

*/

SELECT TA2.artist_name, TA2.artist_rank
FROM
(
  SELECT TA.artist_name, DENSE_RANK() OVER( ORDER BY rank desc) artist_rank
  FROM
  (
    SELECT A.artist_name, count(*) as rank
    FROM global_song_rank GSR
    join songs S ON GSR.song_id = S.song_id
    join artists A
    on A.artist_id = S.artist_id
    where rank <11
    group by A.artist_name
    ORDER BY 2 DESC
  )TA
)TA2
WHERE TA2.artist_rank<6