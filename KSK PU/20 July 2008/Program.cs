using System;
using System.Collections.Generic;

namespace _20_July_2008
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            do
            {
                Console.Write("Enter the number of assortments: ");
                number = int.Parse(Console.ReadLine());
            } while (number < 5 || number > 500);

            List<Assortment> assortments = new List<Assortment>();

            Input(number, assortments);

            List<Assortment> sortedListByName = SortByName(assortments);
            Output(sortedListByName);

            List<Assortment> assortmentsOnASpecificDate = GetAssortmentsOnASpecificDate(assortments);
            Output(assortmentsOnASpecificDate);

            List<Assortment> desserts = SortByName(assortments);
            Output(desserts);
        }

        private static void Input(int number, List<Assortment> assortments)
        {
            for (int i = 0; i < number; i++)
            {
                string name;
                int quantity;
                double price;
                string code;

                do
                {
                    Console.Write("Name: ");
                    name = Console.ReadLine();
                } while (name.Length <= 0 || name.Length > 40);

                Console.Write("Quantity: ");
                quantity = int.Parse(Console.ReadLine());

                Console.Write("Price: ");
                price = double.Parse(Console.ReadLine());

                do
                {
                    Console.Write("Code: ");
                    code = Console.ReadLine();
                } while (code.Length <= 0 || code.Length > 10);

                Assortment assortment = new Assortment(name, quantity, price, code);
                assortments.Add(assortment);
            }
        }

        private static void Output(List<Assortment> assortments)
        {
            foreach (var assortment in assortments)
            {
                Console.WriteLine(assortment);
            }
        }

        public static List<Assortment> SortByName(List<Assortment> assortments)
        {
            Assortment temp;

            for (int i = 0; i < assortments.Count - 1; i++)
            {
                for (int j = 0; j < assortments.Count - 1 - i; j++)
                {
                    if (assortments[j].Name.CompareTo(assortments[j + 1].Name) > 0)
                    {
                        temp = assortments[j];
                        assortments[j] = assortments[j + 1];
                        assortments[j + 1] = temp;
                    }
                }
            }
            return assortments;
        }

        public static List<Assortment> SortByType(List<Assortment> assortments)
        {
            Assortment temp;

            for (int i = 0; i < assortments.Count - 1; i++)
            {
                for (int j = 0; j < assortments.Count - 1 - i; j++)
                {
                    if (assortments[j].GetType().CompareTo(assortments[j+1].GetType()) > 0 || (
                        assortments[j].GetType().CompareTo(assortments[j + 1].GetType()) == 0 &&
                        assortments[j].Price.CompareTo(assortments[j + 1].Price) > 0))
                    {
                        temp = assortments[j];
                        assortments[j] = assortments[j + 1];
                        assortments[j + 1] = temp;
                    }
                }
            }
            return assortments;
        }

        public static List<Assortment> GetAssortmentsOnASpecificDate(List<Assortment> assortments)
        {
            List<Assortment> assortmentsInAugust = new List<Assortment>();
            foreach (var assortment in assortments)
            {
                if (assortment.GetExpiryDate().Equals("20.08.08"))
                {
                    assortmentsInAugust.Add(assortment);
                }
            }
            return SortByType(assortmentsInAugust);
        }

        public static List<Assortment> GetDesserts(List<Assortment> assortments)
        {
            List<Assortment> desserts = new List<Assortment>();
            
            double averagePrice = GetAvergePrice(assortments);
            foreach (var assortment in assortments)
            {
                if (assortment.Price < averagePrice)
                {
                    desserts.Add(assortment);
                }
            }
            Console.WriteLine($"The average price of the desserts is {averagePrice:F2}");
            return desserts;
        }

        public static double GetAvergePrice(List<Assortment> assortments)
        {
            double totalPrice = 0;
            int count = 0;
            
            foreach (var assortment in assortments)
            {
                if (assortment.GetType().Equals("dessert"))
                {
                    totalPrice += assortment.Price;
                    count++;
                }
            }
            
            double averagePrice = totalPrice/count;
            return averagePrice;
        }
    }
}
