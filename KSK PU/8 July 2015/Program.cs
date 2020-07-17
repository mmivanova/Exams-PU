using System;
using System.Collections.Generic;

namespace _8_July_2015
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;

            do
            {
                Console.Write("Enter the number of deals: ");
                number = int.Parse(Console.ReadLine());
            } while (number < 0 || number > 5000);

            List<Deal> deals = new List<Deal>();

            Input(number, deals);


        }

        private static void Input(int number, List<Deal> deals)
        {
            for (int i = 0; i < number; i++)
            {
                string dateInput;
                int code;
                int quantity;
                int quality;
                string name;

                Console.Write("Date: ");
                dateInput = Console.ReadLine();
                int year = int.Parse(dateInput.Substring(0, 4));
                int month = int.Parse(dateInput.Substring(4, 2));
                int day = int.Parse(dateInput.Substring(6, 2));
                int hour = int.Parse(dateInput.Substring(8, 2));
                int minutes = int.Parse(dateInput.Substring(10, 2));
                DateTime date = new DateTime(year, month, day, hour, minutes, 00);

                Console.Write("Code: ");
                code = int.Parse(Console.ReadLine());

                Console.Write("Quantity: ");
                quantity = int.Parse(Console.ReadLine());

                Console.Write("Quality: ");
                quality = int.Parse(Console.ReadLine());

                Console.Write("Name: ");
                name = Console.ReadLine();

                Deal deal = new Deal(date, code, quantity, quality, name);
                deals.Add(deal);
            }
        }

        private static void Output(List<Deal> deals)
        {
            foreach (var deal in deals)
            {
                Console.WriteLine(deal);
            }
        }

        public static List<Deal> SortByQuality(List<Deal> deals)
        {
            Deal temp;

            for (int i = 0; i < deals.Count; i++)
            {
                for (int j = 0; j < deals.Count - 1 - i; j++)
                {
                    if (deals[j].Quality.CompareTo(deals[j+1].Quality) < 0 || (
                        deals[j].Quality.CompareTo(deals[j + 1].Quality) == 0 &&
                        deals[j].Quantity.CompareTo(deals[j + 1].Quantity) > 0))
                    {
                        temp = deals[j];
                        deals[j] = deals[j + 1];
                        deals[j + 1] = temp;

                    }
                }
            }
            return deals;
        }

        public static List<Deal> SortByQuantity(List<Deal> deals)
        {
            Deal temp;

            for (int i = 0; i < deals.Count; i++)
            {
                for (int j = 0; j < deals.Count - 1 - i; j++)
                {
                    if (deals[j].QuantityInKG.CompareTo(deals[j + 1].QuantityInKG) < 0)
                    {
                        temp = deals[j];
                        deals[j] = deals[j + 1];
                        deals[j + 1] = temp;

                    }
                }
            }
            return deals;
        }
    }
}
