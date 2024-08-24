/*PROJECT SOUVENIER*/

/* Verwijderen van schema en tabellen */

drop table if exists Souveniershop.Verkoop
drop table if exists Souveniershop.SouvenierPlaats
drop table if exists Souveniershop.VerkoperPlaats
drop table if exists Souveniershop.Verkoper
drop table if exists Souveniershop.Plaats
drop table if exists Souveniershop.Souvenier

drop schema if exists Souveniershop
go

/* Aanmaak van schema en tabellen */

create schema Souveniershop
go

create table Souveniershop.Souvenier
(
	id int IDENTITY (1,1),
	naam varchar(50) not null,
	beschrijving varchar(255),

	constraint PK_Souvenier primary key (id)
)

create table Souveniershop.Verkoper
(
	id int IDENTITY (1,1),
	voornaam varchar(50) not null,
	naam varchar(50) not null,

	constraint PK_Verkoper primary key (id)
)

create table Souveniershop.Plaats
(
	id int IDENTITY (1,1),
	naam varchar(50) not null,
	beschrijving varchar(255),

	constraint PK_Plaats primary key (id)
)

create table Souveniershop.VerkoperPlaats
(
	id int IDENTITY (1,1),
	verkoperID int not null,
	plaatsID int not null,
	datum date not null,

	constraint PK_VerkoperPlaats primary key (id),
	constraint FK_Verkoper foreign key (verkoperID)
		references Souveniershop.Verkoper(id),
	constraint FK_Plaats1 foreign key (plaatsID)
		references Souveniershop.Verkoper(id)
)

create table Souveniershop.SouvenierPlaats
(
	id int IDENTITY (1,1),
	souvenierID int not null,
	plaatsID int not null,
	prijs money not null,

	constraint PK_SouvenierPlaats primary key (id),
	constraint FK_Souvenier foreign key (souvenierID)
		references Souveniershop.Verkoper(id),
	constraint FK_Plaats2 foreign key (plaatsID)
		references Souveniershop.Verkoper(id)
)

create table Souveniershop.Verkoop
(
	id int IDENTITY (1,1),
	verkoperplaatsID int not null,
	souvenierplaatsID int not null,
	aantal int,

	constraint PK_Verkoop primary key (id),
	constraint FK_VerkoperPlaats foreign key (verkoperplaatsID)
		references Souveniershop.Verkoper(id),
	constraint FK_SouvenierPlaats foreign key (souvenierplaatsID)
		references Souveniershop.Verkoper(id)
)