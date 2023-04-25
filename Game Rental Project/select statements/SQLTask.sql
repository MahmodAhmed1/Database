/*(A) most interesting game that had maximum number of renters*/
select y.name_of_game as [most rented] 
from (select game.Name as name_of_game , count(rent.ID_game) as num_of_games 
from game left outer join rent 
on game.ID_game = rent.ID_game 
group by game.Name) y 
where y.num_of_games=(select max(y.num_of_games) 
from (select game.Name as name_of_game , count(rent.ID_game) as num_of_games 
from game left outer join rent  
on game.ID_game = rent.ID_game 
group by game.Name) y);

/*(B) the games that hadn't any renters last month*/
select y.name_of_game as [not rented] 
from (select game.Name as name_of_game , count(rent.ID_game) as num_of_games
from game left outer join rent 
on game.ID_game = rent.ID_game AND rent.rent_date >= '2022-4-27'
group by game.Name) y
where y.num_of_games=0;

/*(C) the renter(client) with the maximum renting last month*/
select top 1 Client.name ,COUNT(rent.Client_ID) as num_of_client
from Client left outer join rent
on Client.Client_ID = rent.Client_ID AND rent.rent_date >= '2022-4-27'
group by Client.name
order by num_of_client desc

/*(D) the vendor with the maximum renting out last month*/
select vendor.name
from vendor 
where vendor.vendor_ID  in (select y.vendor_ID
from (select vendor.vendor_ID ,COUNT(rent.vendor_ID) as max_num
from rent,vendor
where rent.vendor_ID = vendor.vendor_ID
group by vendor.vendor_ID) y
where y.max_num = (select  max(y.num_of_rent) as vendor_ID
from (select rent.vendor_ID, COUNT(rent.vendor_ID) as num_of_rent
from rent
group by rent.vendor_ID) y));

/*(E) vendor whose games hadn't any renting last month*/
select y.name as vendor
from(select vendor.name,count(rent.vendor_ID) as count
from vendor left outer join rent 
on vendor.vendor_ID = rent.vendor_ID AND rent.rent_date >= '2022-4-27'
group by vendor.name) y
where y.count = 0;

/*(F) vendor hadn't add any game last year*/
SELECT vendor.name
FROM vendor
WHERE NOT EXISTS
(SELECT *
   FROM  game
   WHERE game.add_date >= '2021-5-27' AND game.vendor_ID=vendor.vendor_ID);
















