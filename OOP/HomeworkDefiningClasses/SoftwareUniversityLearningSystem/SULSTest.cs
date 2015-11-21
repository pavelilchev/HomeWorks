using System.Collections.Generic;
using System.Linq;

namespace SoftwareUniversityLearningSystem
{
    public class SULSTest
    {
        static void Main(string[] args)
        {
            Student az = new OnlineStudent("Pavel", "Ilchev", 33, 555678, 6.00, "OOP");
            Student ross = new OnlineStudent("Rossen", "Filipov", 30, 435678, 5.80, "OOP");
            Student flik = new OnsiteStudent("Flick", "Flickev", 25, 123678, 5.90, "KPK", 10);
            Student ron = new OnsiteStudent("Rony", "Kouman", 35, 666678, 3.00, "Basic", 1);
            Student dropi = new DropoutStudent("Dropi", "Dropev", 35, 666678, 3.00, "slab uspeh");
            Student outi = new GraduateStudent("Outi", "Outev", 35, 666678, 3.00);

            List<Student> persons = new List<Student>();
            persons.Add(az);
            persons.Add(ross);
            persons.Add(flik);
            persons.Add(ron);
            persons.Add(dropi);
            persons.Add(outi);

            persons.Where(x => x is CurrentStudent).OrderBy(x => x.AverageGrade).ToList().ForEach(y => System.Console.WriteLine(y));
        }
    }
}
