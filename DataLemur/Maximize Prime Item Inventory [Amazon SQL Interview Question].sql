/*
Amazon wants to maximize the number of items it can stock in a 500,000 square feet warehouse. It wants to stock as many prime items as possible, and afterwards use the remaining square footage to stock the most number of non-prime items.

Write a SQL query to find the number of prime and non-prime items that can be stored in the 500,000 square feet warehouse. Output the item type and number of items to be stocked.

inventory table:
Column Name	Type
item_id	integer
item_type	string
item_category	string
square_footage	decimal
inventory Example Input:
item_id	item_type	item_category	square_footage
1374	prime_eligible	mini refrigerator	68.00
4245	not_prime	standing lamp	26.40
2452	prime_eligible	television	85.00
3255	not_prime	side table	22.60
1672	prime_eligible	laptop	8.50
Example Output:
item_type	item_count
prime_eligible	9285
not_prime	6
The dataset you are querying against may have different input & output - this is just an example!

To prioritise storage of prime_eligible items:

The combination of the prime_eligible items has a total square footage of 161.50 sq ft (68.00 sq ft + 85.00 sq ft + 8.50 sq ft).

To prioritise the storage of the prime_eligible items, we find the number of times that we can stock the combination of the prime_eligible items which are 3,095 times, mathematically expressed as: 500,000 sq ft / 161.50 sq ft = 3,095 items

Then, we multiply 3,095 times with 3 items (because we're asked to output the number of items to stock), which gives us 9,285 items.

Stocking not_prime items with remaining storage space:

After stocking the prime_eligible items, we have a remaining 157.50 sq ft (500,000 sq ft - (3,095 times x 161.50 sq ft).

Then, we divide by the total square footage for the combination of 2 not_prime items which is mathematically expressed as 157.50 sq ft / (26.40 sq ft + 22.60 sq ft) = 3 times so the total number of not_prime items that we can stock is 6 items (3 times x (26.40 sq ft + 22.60 sq ft)).
*/


SELECT item_type, CASE WHEN item_type ='prime_eligible' THEN QUANTITY ELSE
      trunc((500000-trunc(500000/previus_sum)*previus_sum)/sum2)*count2  END as item_count
FROM
(
select  item_type, count(item_type) as count2, sum(square_footage) as sum2, 
        trunc(500000/sum(square_footage))*count(item_type) as QUANTITY,
        LAG(count(item_type) ) OVER(order by item_type DESC) as previus_count,
        LAG(sum(square_footage) ) OVER(order by item_type DESC) as previus_sum
from inventory 
GROUP BY  item_type
)TA