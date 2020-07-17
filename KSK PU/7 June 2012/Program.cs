using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace _7_June_2012
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;

            do
            {
                Console.Write("Enter the number of competitors: ");
                number = int.Parse(Console.ReadLine());
            } while (number < 0 || number > 1000);

            List<Competitor> competitors = new List<Competitor>();

            Input(number, competitors);

            List<Competitor> sortedListByResult = SortByResult(competitors);
            Output(sortedListByResult);

            List<Competitor> inquiry = Inquiry(competitors);
            Output(inquiry);

            List<Competitor> sOUSchools = SOUSchools(competitors);
            Output(sOUSchools);
        }

        private static void Input(int number, List<Competitor> competitors)
        {
            for (int i = 0; i < number; i++)
            {
                string name;
                string city;
                string school;
                int result;

                do
                {
                    Console.Write("Name: ");
                    name = Console.ReadLine();
                } while (name.Length <= 0 || name.Length > 50);

                do
                {
                    Console.Write("City: ");
                    city = Console.ReadLine();
                } while (city.Length <= 0 || city.Length > 20);

                do
                {
                    Console.Write("School: ");
                    school = Console.ReadLine();
                } while (school.Length <= 0 || school.Length > 30);

                Console.Write("Result: ");
                result = int.Parse(Console.ReadLine());

                Competitor competitor = new Competitor(name, city, school, result);
                competitors.Add(competitor);
            }
        }

        private static void Output(List<Competitor> competitors)
        {
            foreach (var competitor in competitors)
            {
                Console.WriteLine(competitor);
            }
        }

        public static List<Competitor> SortByResult(List<Competitor> competitors)
        {
            Competitor temp;

            for (int i = 0; i < competitors.Count - 1; i++)
            {
                for (int j = 0; j < competitors.Count - 1 - i; j++)
                {
                    if (competitors[j].Result.CompareTo(competitors[j+1].Result) < 0)
                    {
                        temp = competitors[j];
                        competitors[j] = competitors[j + 1];
                        competitors[j + 1] = temp;
                    }
                }
            }
            return competitors;
        }

        public static List<Competitor> SortBySchool(List<Competitor> competitors)
        {
            Competitor temp;

            for (int i = 0; i < competitors.Count - 1; i++)
            {
                for (int j = 0; j < competitors.Count - 1 - i; j++)
                {
                    if (competitors[j].School.CompareTo(competitors[j + 1].School) < 0 || (
                        competitors[j].School.CompareTo(competitors[j + 1].School) == 0 &&
                        competitors[j].Result.CompareTo(competitors[j + 1].Result) < 0))
                    {
                        temp = competitors[j];
                        competitors[j] = competitors[j + 1];
                        competitors[j + 1] = temp;
                    }
                }
            }

            return competitors;
        }

        public static List<Competitor> Inquiry(List<Competitor> competitors)
        {
            string city;
            do
            {
                Console.Write("Enter the required city: ");
                city = Console.ReadLine();
            }
            while (city.Length <= 0 || city.Length > 20);

            List < Competitor > competitors1 = new List<Competitor>();

            foreach (var competitor in competitors.Where(c => c.City.Equals(city)))
            {
                competitors1.Add(competitor);
            }

            return SortBySchool(competitors1);
        }

        public static List<Competitor> SOUSchools(List<Competitor> competitors)
        {
            double totalScore = 0;
            int count = 0;
            foreach (var competitor in competitors)
            {
                totalScore += competitor.Result;
                count++;
            }

            double averageScore = totalScore / count;
            List<Competitor> competitors1 = new List<Competitor>();

            foreach (var competitor in competitors)
            {
                if (competitor.School.Contains("СОУ") && competitor.Result > averageScore)
                {
                    competitors1.Add(competitor);
                }
            }

            return competitors1;

        }
    }
}
