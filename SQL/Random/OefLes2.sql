drop table if exists Project.ProjectMedewerker
drop table if exists Project.Project
drop table if exists Project.Medewerker
drop table if exists Project.Afdeling

create table Project.Afdeling(
	id int primary key NOT NULL,
	naam varchar(45) NOT NULL
)

create table Project.Project(
	id int primary key NOT NULL,
	naam varchar(45) NOT NULL,
	afdelingID int foreign key references Project.Afdeling(id) NOT NULL
)

create table Project.Medewerker(
	id int primary key NOT NULL,
	voornaam varchar(45) NOT NULL,
	achternaam varchar(45) NOT NULL
)

create table Project.ProjectMedewerker(
	id int primary key NOT NULL,
	taak varchar(45),
	urenGewerkt int default 0,
	projectID int foreign key Project.Project(id) NOT NULL on delete cascade,
	medewerkerID int foreign key Project.Medewerker(id) NOT NULL on delete cascade
	)

