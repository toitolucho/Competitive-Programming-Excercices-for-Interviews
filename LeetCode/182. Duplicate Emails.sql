/*
Write an SQL query to report all the duplicate emails. Note that it's guaranteed that the email field is not NULL.

Return the result table in any order.
*/


create table Person
(
	id int  ,
	email varchar(100)
)

insert into Person values(1,'a@b.com')
insert into Person values(2,'c@d.com')
insert into Person values(3,'a@b.com')

select email
from Person
group by email
having count(email) > 1