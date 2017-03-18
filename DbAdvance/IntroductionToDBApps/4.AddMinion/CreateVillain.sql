insert into Villains (Id, Name,Factor)
values (
(select isnull(max(Id),0) + 1 from Villains),
'{0}',
'evil'
)