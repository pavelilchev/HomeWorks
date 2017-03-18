select v.Name, count(*) from Villains v
join VillainsMinions vm on vm.VillainId = v.Id
group by v.Name
having count(*) > 3