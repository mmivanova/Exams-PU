using System;
using System.Collections.Generic;

namespace _13_July_2010
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
            } while (number <= 0 || number > 500);

            List<Competitor> competitors = new List<Competitor>();
            
            Input(number, competitors);
        }

        private static void Input(int number, List<Competitor> competitors)
        {
            for (int i = 0; i < number; i++)
            {
                string name;
                string code;
                string talant;
                int score;

                do
                {
                    Console.Write("Name: ");
                    name = Console.ReadLine();
                } while (name.Length <= 0 || name.Length > 45);

                do
                {
                    Console.Write("Code: ");
                    code = Console.ReadLine();
                } while (code.Length <= 0 || code.Length > 10);

                do
                {
                    Console.Write("Talant: ");
                    talant = Console.ReadLine();
                } while (talant.Length <= 0 || talant.Length > 20);

                Console.Write("Score: ");
                score = int.Parse(Console.ReadLine());

                Competitor competitor = new Competitor(name, code, talant, score);
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

        public static List<Competitor> SortByName(List<Competitor> competitors)
        {
            Competitor temp;

            for (int i = 0; i < competitors.Count - 1; i++)
            {
                for (int j = 0; j < competitors.Count - 1 - i; j++)
                {
                    if (competitors[j].Name.CompareTo(competitors[j+1].Name) > 0)
                    {
                        temp = competitors[j];
                        competitors[j] = competitors[j + 1];
                        competitors[j + 1] = temp;
                    }
                }
            }
            return competitors;
        }

        public static List<Competitor> SortByTalant(List<Competitor> competitors)
        {
            Competitor temp;

            for (int i = 0; i < competitors.Count-1; i++)
            {
                for (int j = 0; j < competitors.Count-1-i; j++)
                {
                    if (competitors[j].Talant.CompareTo(competitors[j+1].Talant) > 0 || (
                        competitors[j].Talant.CompareTo(competitors[j + 1].Talant) == 0 &&
                        competitors[j].Score.CompareTo(competitors[j + 1].Score) < 0))
                    {
                        temp = competitors[j];
                        competitors[j] = competitors[j + 1];
                        competitors[j + 1] = temp;
                    }
                }
            }
            return competitors;
        }

        public static List<Competitor> CompetitorsFromSofia(List<Competitor> competitors)
        {
            List<Competitor> competitorsFromSofia = new List<Competitor>();

            foreach (var competitor in competitors)
            {
                if (competitor.GetRegion().Equals("Sofia") && competitor.GetBirthYear() > 1990)
                {
                    competitorsFromSofia.Add(competitor);
                }
            }

            return SortByTalant(competitorsFromSofia);
        }


    }
}
