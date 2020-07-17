using System;
using System.Collections.Generic;
using System.Linq;

namespace _6_June_2017
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;

            do
            {
                Console.Write("Enter the number of clients: ");
                number = int.Parse(Console.ReadLine());
            } while (number < 0 || number > 500);

            List<Client> clients = new List<Client>();
            Input(number, clients);

            //Console.WriteLine(String.Join("", clients));

            Console.WriteLine("Sort by name: ");
            List<Client> sortByName = SortByName(clients);
            Output(sortByName);

            Console.WriteLine(Environment.NewLine + "Clients from Plovdiv: ");
            List<Client> clientsFromPlovdiv = ClientsFromPlovdiv(clients);
            Output(clientsFromPlovdiv);

            Console.WriteLine(Environment.NewLine + "Inquiry: ");
            Inquiry(clients);
        }

        public static void Input(int number, List<Client> clients)
        {
            for (int i = 0; i < number; i++)
            {
                string name;
                string city;
                string code;

                do
                {
                    Console.Write("Name: ");
                    name = Console.ReadLine();
                } while (name.Length < 0 || name.Length > 30);

                do
                {
                    Console.Write("City: ");
                    city = Console.ReadLine();
                } while (city.Length < 0 || city.Length > 10);

                do
                {
                    Console.Write("Code of the card (10-digit number): ");
                    code = Console.ReadLine();
                } while (code.Length != 10);

                Client client = new Client(name, city, code);
                clients.Add(client);
            }
        }

        public static void Output(List<Client> clients)
        {
            foreach (var client in clients)
            {
                Console.WriteLine(client);
            }
        }

        public static List<Client> SortByName(List<Client> clients)
        {
            Client temp;

            for (int i = 0; i < clients.Count - 1; i++)
            {
                for (int j = 0; j < clients.Count - 1 - i; j++)
                {
                    if (clients[j].Name.CompareTo(clients[j + 1].Name) > 0)
                    {
                        temp = clients[j];
                        clients[j] = clients[j + 1];
                        clients[j + 1] = temp;
                    }
                }
            }
            return clients;
        }

        public static List<Client> SortByPercent(List<Client> clients)
        {
            Client temp;

            for (int i = 0; i < clients.Count - 1; i++)
            {
                for (int j = 0; j < clients.Count - 1 - i; j++)
                {
                    if (clients[j].GetPercent().CompareTo(clients[j + 1].GetPercent()) < 0 || (
                        clients[j].GetPercent().CompareTo(clients[j + 1].GetPercent()) == 0 &&
                        clients[j].Name.CompareTo(clients[j + 1].Name) > 0))
                    {
                        temp = clients[j];
                        clients[j] = clients[j + 1];
                        clients[j + 1] = temp;
                    }
                }
            }
            return clients;
        }

        public static List<Client> ClientsFromPlovdiv(List<Client> clients)
        {
            List<Client> clientsFromPlovdiv = new List<Client>();
            foreach (var client in clients)
            {
                if (client.City.Equals("Plovdiv") && client.GetProduct().Equals("козметика"))
                {
                    clientsFromPlovdiv.Add(client);
                }
            }
            return SortByPercent(clientsFromPlovdiv);
        }   

        public static void Inquiry(List<Client> clients)
        {
            int category;
            do
            {
                Console.Write("Enter the product's category (e.g. 2): ");
                category = int.Parse(Console.ReadLine());
            }
            while (category < 0 || category > 4);

            double bestPercent = 0;
            double currentPercent = 0;

            foreach (var client in clients)
            {
                if (client.Code.ElementAt(0) == char.Parse(category.ToString()))
                {
                    currentPercent = client.GetPercent();
                    if (currentPercent > bestPercent)
                    {
                        bestPercent = currentPercent;
                    }
                }   
            }
            Console.WriteLine("Category's maximum discount is: " + bestPercent);
        }
    }
}
