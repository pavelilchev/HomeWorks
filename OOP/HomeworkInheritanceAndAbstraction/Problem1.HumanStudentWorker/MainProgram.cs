
using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem1.HumanStudentWorker
{
	class MainProgram
	{
		public static void Main(string[] args)
		{
			Student zero = new Student("Pavel", "Ilchev", "123456789");
			Student one = new Student("Plamena", "Kaludova", "223456789");
			Student two = new Student("Ivelin", "Ivanov", "023456789");
			Student tree = new Student("Natali", "Nikolova", "323456789");
			Student four = new Student("Nevena", "Todorova", "423456789");
			Student five = new Student("Vili", "Gospodinova", "523456789");
			Student six = new Student("Mimi", "Kovacheva", "623456789");
			Student seven = new Student("Aleks", "Yanakieva", "723456789");
			Student eight = new Student("Desi", "Zdravkova", "823456789");
			Student nein = new Student("Dimitar", "Zhechev", "923456789");
			
			List<Student> students = new List<Student>();
			students.Add(zero);
			students.Add(one);
			students.Add(two);
			students.Add(tree);
			students.Add(four);
			students.Add(five);
			students.Add(six);
			students.Add(seven);
			students.Add(eight);
			students.Add(nein);
			
			students.OrderBy(student => student.FacultyNumber)
					.ToList()
					.ForEach(st => Console.WriteLine(st));	
			Console.WriteLine();
			
			
			Worker zeroWorker = new Worker("Elena", "Smerikarova", 500m, 8m);
			Worker oneWorker = new Worker("Mila", "Nikolova", 600m, 8m);
			Worker twoWorker = new Worker("Rosi", "Tzolova", 700m, 8m);
			Worker treeWorker = new Worker("Hulia", "Rashkova", 800m, 8m);
			Worker fourWorker = new Worker("Tencho", "Gospodinov", 900m, 8m);
			Worker fiveWorker = new Worker("Petya", "Stoyanov", 450m, 8m);
			Worker sixWorker = new Worker("Neli", "Angelova", 370m, 8m);
			Worker sevenWorker = new Worker("Mariq", "Ivanova", 680m, 8m);
			Worker eightWorker = new Worker("Galq", "Voeva", 120m, 8m);
			Worker neinWorker = new Worker("Desi", "Mihailova", 880m, 8m);
			
			List<Worker> workers = new List<Worker>();
			workers.Add(zeroWorker);
			workers.Add(oneWorker);
			workers.Add(twoWorker);
			workers.Add(treeWorker);
			workers.Add(fourWorker);
			workers.Add(fiveWorker);
			workers.Add(sixWorker);
			workers.Add(sevenWorker);
			workers.Add(eightWorker);
			workers.Add(neinWorker);
			
			workers.OrderByDescending(x => x.MoneyPerHour()).ToList().ForEach(w => Console.WriteLine(w));	
			Console.WriteLine();
			
			List<Human> humans = new List<Human>();
			humans.AddRange(students);
			humans.AddRange(workers);
			
			humans.OrderBy(x => x.FirstName)
			   	  .ThenBy(x => x.LastName)
				  .ToList()
				  .ForEach(x => Console.WriteLine(x.FirstName + " " + x.LastName));
			
			Console.ReadKey();
		}		
	}
}