

--L3 Oef1
select id
from Tennis.Speler
where lidSinds between 2000 and 2003

--L3 Oef2
select id
from  Tennis.Boete
where bedrag between 50 and 100

--L3 Oef3
select id
from  Tennis.Boete
where bedrag NOT between 50 and 100

--L3 Oef4
select id
from Tennis.Speler
where plaats NOT IN ('Den Haag','Voortburg')

--L3 Oef5
select id, naam
from Tennis.Speler
where naam LIKE '%en%'

--L3 Oef6
select naam, id
from Tennis.Speler
where naam LIKE '%a_'
order by naam

--L3 Oef7
select id, naam, voornaam
from Tennis.Speler
where naam LIKE '_e%e_'

--L3 Oef8
select id, bedrag,
	case  
	when bedrag > 80 then 'hoog'
	when bedrag > 41 then 'middelmatig'
	else 'laag'
	end as categorie
from Tennis.Boete
	
--L3 Oef9
select id,
	case
	when divisie = 'ere' then 'eredivisie'
	when divisie = 'tweede' then 'tweede divisie'
	end as divisie
from Tennis.Team

--L3 Oef10
select distinct spelerId
from Tennis.Boete
where bedrag is NOT null

--L3 Oef11
select distinct lidSinds
from Tennis.Speler
where lidSinds >= 2000

--L3 Oef12
select distinct spelerId
from Tennis.Bestuurslid
where functie = 'Penningmeester'