using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _2_July_2018
{
    class Program
    {
        static void Main()
        {
            int numberOfItems = int.Parse(Console.ReadLine());
            while (numberOfItems < 0 || numberOfItems > 10_000)
            {
                Console.Write("Please enter a valid number: ");
                numberOfItems = int.Parse(Console.ReadLine());      
            }

            List<Item> listOfItems = new List<Item>();
            Input(numberOfItems, listOfItems);

            Console.WriteLine("------------------");
            Console.WriteLine("Sort by Position: ");
            List<Item> sortedListOfItems = SortByPosition(listOfItems);
            Output(sortedListOfItems);

            Console.WriteLine("------------------");
            Console.WriteLine("Sort by Date: ");
            List<Item> sortedListByDate = SortByDate(listOfItems);
            Output(sortedListByDate);

            Console.WriteLine("------------------");
            Console.WriteLine("Inquiry: ");
            List<Item> inquiry = Inquiry(listOfItems);
            Output(inquiry);
        }

        public static void Output(List<Item> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        public static void Input(int numberOfItems, List<Item> listOfItems)
        {
            for (int i = 0; i < numberOfItems; i++)
            {
                string[] input = Console.ReadLine().Split(", ").ToArray();

                Item item;
                string code;
                string name;
                double quantity;
                int suitability;
                char group;
                DateTime dateOfEntry = DateTime.ParseExact(input[5], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                string position;
                do
                {
                    code = input[0];
                } while (input[0].Length < 0 || input[0].Length > 4);
                do
                {
                    name = input[1];
                } while (input[1].Length < 0 || input[1].Length > 55);
                do
                {
                    quantity = double.Parse(input[2]);
                } while (double.Parse(input[2]) < 0);
                do
                {
                    suitability = int.Parse(input[3]);
                } while (int.Parse(input[3]) < 0);
                do
                {
                    group = char.Parse(input[4]);
                } while (char.Parse(input[4]) != 'E' && char.Parse(input[4]) != 'S');
                do
                {
                    position = input[6];
                } while (input[6].Length < 0 || input[6].Length > 10);

                if (group == 'E')
                {
                    int humidity;
                    do
                    {
                        humidity = int.Parse(input[7]);
                    } while (int.Parse(input[7]) < 0);
                    item = new Item(position, code, name, quantity, dateOfEntry, suitability, humidity);
                }
                else
                {
                    item = new Item(position, code, name, quantity, dateOfEntry, suitability);
                }
                listOfItems.Add(item);
            }
        }

        public static List<Item> SortByPosition(List<Item> listOfItems)
        {
            Item temp;
            for (int i = 0; i < listOfItems.Count - 1; i++)
            {
                for (int j = 0; j < listOfItems.Count - 1 - i; j++)
                {
                    if (listOfItems[j].Position.CompareTo(listOfItems[j + 1].Position) > 0)
                    {
                        temp = listOfItems[j];
                        listOfItems[j] = listOfItems[j + 1];
                        listOfItems[j + 1] = temp;
                    }
                }
            }
            return listOfItems;
        }

        public static List<Item> SortByDate(List<Item> listOfItems)
        {
            Item temp;
            for (int i = 0; i < listOfItems.Count - 1; i++)
            {
                for (int j = 0; j < listOfItems.Count - 1 - i; j++)
                {
                    if (listOfItems[j].DateOfEntry.CompareTo(listOfItems[j + 1].DateOfEntry) > 0 || 
                        (listOfItems[j].DateOfEntry.CompareTo(listOfItems[j + 1].DateOfEntry) == 0 &&
                        listOfItems[j].Suitability.CompareTo(listOfItems[j + 1].Suitability) < 0))
                    {
                        temp = listOfItems[j];
                        listOfItems[j] = listOfItems[j + 1];
                        listOfItems[j + 1] = temp;
                    }
                }
            }
            return listOfItems;
        }

        public static List<Item> Inquiry(List<Item> items)
        {
            Console.Write("Please, enter the code of the item:");
            string code = Console.ReadLine();
            List<Item> listByCode = new List<Item>();
            double sum = 0;
            int hum = int.MaxValue;
            bool IsSpecialFlag = false;
            foreach (var item in items.Where(i => i.Code == code))
            {
                listByCode.Add(item);
                sum += item.Quantity;
                if (item.Group == 'E')
                {
                    hum = Math.Min(item.Humidity, hum);
                    IsSpecialFlag = true;
                }
            }
            Console.WriteLine("Total quantity: " + sum);
            if (IsSpecialFlag)
            {
                Console.WriteLine("Item's humidity is: B%=" + hum);
            }
            return listByCode;
        }
    }
}
