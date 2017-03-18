use MinionsDB

create table Towns(
Id int primary key,
Name varchar(20),
Country varchar(20),
)

create table Minions(
Id int primary key,
Name varchar(20),
Age int,
TownId int
)

create table Villains(
Id int primary key,
Name varchar(20),
Factor varchar(20)
)

create table VillainsMinions(
VillainId int,
MinionId int,
constraint PK_Villains_Minions primary key (VillainId,MinionId)
)

insert into Towns
values 
(1,'Varna', 'Bulgaria'),
(2,'London', 'England'),
(3,'NY', 'USA'),
(4,'Bourgas', 'Bulgaria'),
(5,'Moscow', 'Russia')


insert into Minions
values 
(1,'Liolio',2, 1),
(2,'Kolibaba',7, 2),
(3,'Liuh',4, 4),
(4,'Pustinqk',5, 2),
(5,'Trutlio', 12,3)

insert into Villains
values 
(1,'Zlostar','good'),
(2,'BloodSeeker','bad'),
(3,'ScarFace','evil'),
(4,'Crump','super evil'),
(5,'Toltun', 'super evil')

insert into VillainsMinions
values 
(1,1),
(2,2),
(3,3),
(4,4),
(5,5)