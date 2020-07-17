using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

namespace _3_July_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfClients = int.Parse(Console.ReadLine());

            List<Client> listOfClients = new List<Client>();
            List<Client> listOfClientsWithRatingTwo = new List<Client>();
            List<Client> listOfClientsArrangedByYears = new List<Client>();

            for (int i = 0; i < numberOfClients; i++)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();
                string name = input[0] + " " + input[1];
                DateTime dateOfReg = DateTime.ParseExact(input[2], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                //How to write date without the time --->>>  dateOfReg.ToString("dd.MM.yyyy");
                int purchases = int.Parse(input[3]);
                decimal totalSum = decimal.Parse(input[4]);

                Client client = new Client(name, dateOfReg, purchases, totalSum);

                listOfClients.Add(client);
            }

            foreach (var element in listOfClients)
            {
                Console.WriteLine(element);
            }

            foreach (var client in listOfClients)
            {
                if (client.GetRating() == "**")
                {
                    listOfClientsWithRatingTwo.Add(client);
                }
            }

            Console.WriteLine("------------------------");

            foreach (var client in listOfClientsWithRatingTwo.OrderByDescending(price => price.TotalSumOfPurchases).ThenBy(n => n.Name))
            {
                Console.WriteLine(client);
            }

            Console.Write("Please enter the desired number of rating stars:");
            int stars = int.Parse(Console.ReadLine());

            foreach (var client in listOfClients)
            {
                if (client.GetRating().Length == stars)
                {
                    listOfClientsArrangedByYears.Add(client);
                }
            }

            
        }
    }
}

