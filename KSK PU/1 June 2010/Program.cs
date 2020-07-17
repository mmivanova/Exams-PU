using System;
using System.Collections.Generic;

namespace _1_June_2010
{
    class Program
    {
        static void Main()
        {
            int number = ValidateInputNumber();

            List<Vehicle> vehicles = new List<Vehicle>();

            Input(number, vehicles);

            List<Vehicle> sortedListByBrand = SortByBrand(vehicles);
            Output(sortedListByBrand);

            List<Vehicle> bMWOrAudi = BMWOrAudi(vehicles);
            Output(bMWOrAudi);

            Inquiry();
        }

        public static int ValidateInputNumber()
        {
            int number;
            do
            {
                Console.Write("Enter the number of vehicles: ");
                number = int.Parse(Console.ReadLine());
            } while (number <= 0 || number > 200);
            return number;
        }

        private static void Input(int number, List<Vehicle> vehicles)
        {
            for (int i = 0; i < number; i++)
            {
                string brand;
                string colour;
                double price;
                string code;

                do
                {
                    Console.Write("Brand: ");
                    brand = Console.ReadLine();
                } while (brand.Length <= 0 || brand.Length > 40);

                do
                {
                    Console.Write("Colour: ");
                    colour = Console.ReadLine();
                } while (colour.Length <= 0 || colour.Length > 20);

                Console.Write("Daily rent price: ");
                price = double.Parse(Console.ReadLine());

                Console.WriteLine("ID Number: ");
                code = Console.ReadLine();

                Vehicle vehicle = new Vehicle(brand, colour, price, code);
                vehicles.Add(vehicle);
            }
        }

        private static void Output(List<Vehicle> vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }

        public static List<Vehicle> SortByBrand(List<Vehicle> vehicles)
        {
            Vehicle temp;

            for (int i = 0; i < vehicles.Count - 1; i++)
            {
                for (int j = 0; j < vehicles.Count - 1 - i; j++)
                {
                    if (vehicles[j].Brand.CompareTo(vehicles[j+1].Brand) > 0)
                    {
                        temp = vehicles[j];
                        vehicles[j] = vehicles[j+1];
                        vehicles[j + 1] = temp;
                    }
                }
            }
            return vehicles;
        }

        public static List<Vehicle> SortByType(List<Vehicle> vehicles)
        {
            Vehicle temp;

            for (int i = 0; i < vehicles.Count - 1; i++)
            {
                for (int j = 0; j < vehicles.Count-1-i; j++)
                {
                    if (vehicles[j].GetType().CompareTo(vehicles[j+1].GetType()) > 0 || (
                        vehicles[j].GetType().CompareTo(vehicles[j + 1].GetType()) == 0 &&
                        vehicles[j].GetDate().CompareTo(vehicles[j + 1].GetDate()) < 0))
                    {
                        temp = vehicles[j];
                        vehicles[j] = vehicles[j + 1];
                        vehicles[j + 1] = temp;
                    }
                }
            }
            return vehicles;
        }

        public static List<Vehicle> BMWOrAudi(List<Vehicle> vehicles)
        {
            List<Vehicle> bMWOrAudi = new List<Vehicle>();

            foreach (var vehicle in vehicles)
            {
                if ((vehicle.Brand.Contains("BMW") || vehicle.Brand.Contains("Audi")) &&
                    vehicle.GetDate() != "14.08.08")
                {
                    bMWOrAudi.Add(vehicle);
                }
            }
            return SortByType(bMWOrAudi);
        }

        public static void Inquiry()
        {
            int firstNumber = ValidateInputNumber();
            List<Vehicle> firstRentingCompany = new List<Vehicle>();
            Input(firstNumber, firstRentingCompany);
            List<Vehicle> sortedListByBrand = SortByBrand(firstRentingCompany);
            Output(sortedListByBrand);
            List<Vehicle> bMWOrAudi = BMWOrAudi(firstRentingCompany);
            Output(bMWOrAudi);

            int secondNumber = ValidateInputNumber();
            List<Vehicle> secondRentingCompany = new List<Vehicle>();
            Input(secondNumber, firstRentingCompany);
            List<Vehicle> secondSortedListByBrand = SortByBrand(secondRentingCompany);
            Output(secondSortedListByBrand);
            List<Vehicle> secondBMWOrAudi = BMWOrAudi(firstRentingCompany);
            Output(secondBMWOrAudi);

            int thirdNumber = ValidateInputNumber();
            List<Vehicle> thirdRentingCompany = new List<Vehicle>();
            Input(thirdNumber, firstRentingCompany);
            List<Vehicle> thirdSortedListByBrand = SortByBrand(thirdRentingCompany);
            Output(thirdSortedListByBrand);
            List<Vehicle> thirdBMWOrAudi = BMWOrAudi(thirdRentingCompany);
            Output(thirdBMWOrAudi);

            double firstAveragePrice = GetAveragePrice(firstRentingCompany);
            double secondAveragePrice = GetAveragePrice(secondRentingCompany);
            double thirdAveragePrice = GetAveragePrice(thirdRentingCompany);

            GetLowestPrice(firstAveragePrice, secondAveragePrice, thirdAveragePrice);
        }

        public static double GetAveragePrice(List<Vehicle> rentingCompany)
        {
            double averagePrice = 0;
            foreach (var vehicle in rentingCompany)
            {
                double totalPrice = 0;
                int count = 0;
                if (vehicle.GetType().Equals("jeep"))
                {
                    totalPrice += vehicle.DailyPrice;
                    count++;
                }
                averagePrice = totalPrice / count;
            }
            return averagePrice;
        }

        public static void GetLowestPrice(double firstPrice, double secondPrice, double thirdPrice)
        {
            double lowestPrice = Math.Min(firstPrice, secondPrice);
            double lowestDailyPrice = Math.Min(lowestPrice, thirdPrice);
            Console.WriteLine($"Lowest average daily price of jeeps: {lowestDailyPrice:F2}");
        }
    }
}
