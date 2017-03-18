insert into Towns (Name, Id)
values ('{0}',
(select isnull(max(Id),0) + 1 from Towns)
)