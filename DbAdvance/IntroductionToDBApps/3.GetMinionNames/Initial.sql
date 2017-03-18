select v.Name, m.Name,m.Age from Minions m
join VillainsMinions vm on vm.MinionId = m.Id
join Villains v on v.Id = vm.VillainId
where vm.VillainId = {0}