using System;
using System.Collections.Generic;
using System.Linq;

namespace _4_June_2015
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            do
            {
                Console.Write("Enter the number of the pets: ");
                number = int.Parse(Console.ReadLine());
            } while (number < 0 || number > 160);

            List<Pet> pets = new List<Pet>();
            Input(number, pets);

            List<Pet> sortedList = SortByType(pets);
            Output(sortedList);

            Inquiry(pets);
        }

        private static void Input(int number, List<Pet> pets)
        {
            for (int i = 0; i < number; i++)
            {
                string name;
                string type;
                int months;
                string owner;

                do
                {
                    Console.Write("Name: ");
                    name = Console.ReadLine();
                } while (name.Length <= 0 || name.Length > 30);

                do
                {
                    Console.Write("Type: ");
                    type = Console.ReadLine();
                } while (type.Length <= 0 || type.Length > 20);

                Console.Write("Months: ");
                months = int.Parse(Console.ReadLine());

                do
                {
                    Console.Write("Owner: ");
                    owner = Console.ReadLine();
                } while (owner.Length <= 0 || owner.Length > 40);

                Pet pet = new Pet(name, type, months, owner);
                pets.Add(pet);
            }
        }

        private static void Output(List<Pet> pets)
        {
            foreach (var pet in pets)
            {
                Console.WriteLine(pet);
            }
        }

        public static List<Pet> SortByType(List<Pet> pets)
        {
            Pet temp;

            for (int i = 0; i < pets.Count - 1; i++)
            {
                for (int j = 0; j < pets.Count - 1 - i; j++)
                {
                    if (pets[j].Type.CompareTo(pets[j + 1].Type) > 0 || (
                        pets[j].Type.CompareTo(pets[j + 1].Type) == 0 &&
                        pets[j].Months.CompareTo(pets[j + 1].Months) < 0))
                    {
                        temp = pets[j];
                        pets[j] = pets[j + 1];
                        pets[j + 1] = temp;
                    }
                }
            }
            return pets;
        }

        public static List<Pet> SortByName(List<Pet> pets)
        {
            Pet temp;

            for (int i = 0; i < pets.Count - 1; i++)
            {
                for (int j = 0; j < pets.Count - 1 - i; j++)
                {
                    if (pets[j].Name.CompareTo(pets[j + 1].Name) > 0)
                    {
                        temp = pets[j];
                        pets[j] = pets[j + 1];
                        pets[j + 1] = temp;
                    }
                }
            }
            return pets;
        }

        public static void Inquiry(List<Pet> pets)
        {
            Console.Write("Enter the last name of the owner: ");
            string owner = Console.ReadLine();

            List<Pet> newList = new List<Pet>();
            double age = 0;
            int count = 0;

            foreach (var pet in pets.Where(o => o.Owner.Contains(owner)))
            {
                newList.Add(pet);
                age += pet.Age;
                count++;
            }

            foreach (var pet in SortByName(newList))
            {
                Console.WriteLine($"{pet.Name} -> {pet.Type}");
            }
            Console.WriteLine("Average age: " + age/count);
        }
    }
}
