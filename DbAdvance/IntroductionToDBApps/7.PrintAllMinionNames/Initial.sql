create proc usp_GetOlder @id int
as 
update Minions
set Age += 1
where Id = @id