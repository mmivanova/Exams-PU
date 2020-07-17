using System;
using System.Collections.Generic;
using System.Linq;

namespace _3_July_2017
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;

            do
            {
                Console.Write("Enter the number of the new employees: ");
                number = int.Parse(Console.ReadLine());
            } while (number < 0 || number >= 50);

            List<Employee> newEmployees = new List<Employee>();
            Input(number, newEmployees);

            Console.WriteLine();
            List<Employee> sortByCountry = SortByCountry(newEmployees);
            Output(sortByCountry);

            Console.WriteLine();
            List<Employee> sortByPersonalID = SortByPersonalID(newEmployees);
            Output(sortByPersonalID);

            Console.WriteLine();
            GetEmails(newEmployees);
        }

        private static void Input(int number, List<Employee> employees)
        {
            for (int i = 0; i < number; i++)
            {
                string name;
                string personalID;
                string nameWithLatinLetters;
                string country;
                string postcode;
                string city;

                do
                {
                    Console.Write("Name: ");
                    name = Console.ReadLine();
                } while (name.Length < 0 || name.Length > 50);

                do
                {
                    Console.Write("Personal ID: ");
                    personalID = Console.ReadLine();
                } while (personalID.Length < 0 || personalID.Length > 15);

                do
                {
                    Console.Write("Name with Latin letters: ");
                    nameWithLatinLetters = Console.ReadLine();
                } while (nameWithLatinLetters.Length < 0 || nameWithLatinLetters.Length > 50);

                do
                {
                    Console.Write("Place of Residence (country, postcode, city): ");
                    string[] placeOfResidence = Console.ReadLine().Split(", ").ToArray();
                    country = placeOfResidence[0];
                    postcode = placeOfResidence[1];
                    city = placeOfResidence[2];
                } while ((country.Length < 0 || country.Length >= 30) ||
                         (postcode.Length < 0 || postcode.Length >= 30) ||
                         (city.Length < 0 || city.Length >= 30));

                Employee employee = new Employee(name, personalID, nameWithLatinLetters, country, postcode, city);
                employees.Add(employee);
            }
        }

        private static void Output(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }

        public static List<Employee> SortByCountry(List<Employee> employees)
        {
            Employee temp;

            for (int i = 0; i < employees.Count - 1; i++)
            {
                for (int j = 0; j < employees.Count - 1 - i; j++)
                {
                    if (employees[j].Country.CompareTo(employees[j + 1].Country) > 0 ||
                        (employees[j].Country.CompareTo(employees[j + 1].Country) == 0 &&
                        employees[j].Name.CompareTo(employees[j + 1].Name) > 0))
                    {
                        temp = employees[j];
                        employees[j] = employees[j + 1];
                        employees[j + 1] = temp;
                    }
                }
            }
            return employees;
        }

        public static List<Employee> SortByPersonalID(List<Employee> employees)
        {
            foreach (var employee in employees.Where(i => i.Name != null ||
                                                     i.PersonalID != null ||
                                                     i.NameInLatin != null ||
                                                     i.Country != null))
            {
                Employee temp;

                for (int i = 0; i < employees.Count - 1; i++)
                {
                    for (int j = 0; j < employees.Count - 1 - i; j++)
                    {
                        if (employees[j].PersonalID.CompareTo(employees[j + 1].PersonalID) > 0)
                        {
                            temp = employees[j];
                            employees[j] = employees[j + 1];
                            employees[j + 1] = temp;
                        }
                    }
                }
            }
            return employees;
        }

        public static void GetEmails(List<Employee> employees)
        {
            foreach (var employee in employees.Where(i => i.GenerateEmail() != null))
            {
                Console.WriteLine($"{employee.Name}, email: {employee.GenerateEmail()}");
            }
        }
    }
}
