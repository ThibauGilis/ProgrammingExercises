select voornaam
from Tennis.Speler

select concat_ws('| ','Naam: ', naam, voornaam, 'Plaats: no white space"', plaats, '"') as 'Voledige naam + Woonplaats'
From Tennis.Speler

select concat(Rtrim(naam), space(2), voornaam)
from Tennis.Speler

select lower(naam), upper(voornaam)
from Tennis.Speler

select left(voornaam, 1) + '. ' + naam
from Tennis.Speler

select right(rtrim(voornaam), 2)
from Tennis.Speler

select substring(voornaam, 3, 3), voornaam --eerste element is '1' niet '0' zoals bij c#
from Tennis.Speler

select len(voornaam) as lengte, voornaam
from Tennis.Speler
order by len(voornaam)

select charindex('a', voornaam), voornaam
from Tennis.Speler

select charindex('a', voornaam, 3), voornaam
from Tennis.Speler

select replace(voornaam, 'a', 'e'), voornaam
from Tennis.Speler