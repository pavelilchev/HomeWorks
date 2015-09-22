using System;

class PrintCompanyInformation
{
    static void Main()
    {
        Console.WriteLine("Enter company name:");
        string companyName = Console.ReadLine();
        Console.WriteLine("Enter company adress:");
        string companyAdress = Console.ReadLine();
        Console.WriteLine("Enter company phone:");
        string companyPhone = Console.ReadLine();
        Console.WriteLine("Enter company fax:");
        string companyFax = Console.ReadLine();
        Console.WriteLine("Enter company web site:");
        string companyWeb = Console.ReadLine();
        Console.WriteLine("Enter manager first name:");
        string managerFirstName = Console.ReadLine();
        Console.WriteLine("Enter manager last name:");
        string managerLastName = Console.ReadLine();
        Console.WriteLine("Enter manager age:");
        string age = Console.ReadLine();
        Console.WriteLine("Enter manager phone:");
        string pfone = Console.ReadLine();
        Console.WriteLine("Company name:  {0}\nCompany adress: {1}\nCompany phone: {2}\nCompany Fax{3}\nCompany web{4}\nManager : {5} {6} (age; {7}, tel: {8})", companyName, companyAdress, companyPhone, companyFax, companyWeb, managerFirstName, managerLastName, age, pfone);
    }
}

