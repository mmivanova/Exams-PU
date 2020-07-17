using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Linq;

namespace _4_June_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of stars: ");
            int numberOfStars;
            do
            {
                numberOfStars = int.Parse(Console.ReadLine());
            } while (numberOfStars < 0 || numberOfStars > 2000);

            List<Star> listOfStars = new List<Star>();

            Input(numberOfStars, listOfStars);

            List<Star> sortedListByDistance = SortByDistance(listOfStars);
            Output(sortedListByDistance);

            List<Star> sortedListByConstellation = SortByConstellation(listOfStars);
            Output(sortedListByConstellation);

            Inquiry(listOfStars);
        }

        public static void Input(int numberOfStars, List<Star> list)
        {
            

            for (int i = 0; i < numberOfStars; i++)
            {
                string[] input = Console.ReadLine().Split(", ").ToArray();

                string name;
                double distance;
                int classification;
                double weight;
                string constellation;

                do
                {
                    name = input[0];
                } while (input[0].Length < 0 || input[0].Length > 20);
                do
                {
                    distance = double.Parse(input[1]);
                } while (double.Parse(input[1]) < 0);
                do
                {
                    classification = int.Parse(input[2]);
                } while (int.Parse(input[2]) < 0 || int.Parse(input[2]) > 9);
                do
                {
                    weight = double.Parse(input[3]);
                } while (double.Parse(input[3]) < 0);
                do
                {
                    constellation = input[4];
                } while (input[4].Length < 0 || input[4].Length > 30);

                Star star = new Star(name, distance, classification, weight, constellation);
                list.Add(star);
            }
        }

        public static void Output(List<Star> list)
        {
            foreach (var star in list)
            {
                Console.WriteLine(star);
            }
        }

        public static List<Star> SortByDistance(List<Star> list)
        {
            Star temp;
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - 1 - i; j++)
                {
                    if (list[j].Distance.CompareTo(list[j + 1].Distance) > 0)
                    {
                        temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
            return list;
        }

        public static List<Star> SortByConstellation(List<Star> list)
        {
            Star temp;
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - 1 - i; j++)
                {
                    if (list[j].NameOfConstellation.CompareTo(list[j + 1].NameOfConstellation) > 0 || (
                        list[j].NameOfConstellation.CompareTo(list[j + 1].NameOfConstellation) == 0 &&
                        list[j].Weight.CompareTo(list[j + 1].Weight) < 0))
                    {
                        temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
            return list;
        }

        public static void Inquiry(List<Star> list)
        {
            double sum = 0;
            int count = 0;
            foreach (var constellation in list.Select(c => c.NameOfConstellation))
            {
                string cons = constellation;
                foreach (var star in list.Where(c => c.NameOfConstellation == cons))
                {
                    sum += star.Weight;
                    count++;
                }
                Console.WriteLine(cons + sum/count);
                
                sum = 0;
                count = 0;
            }
        }
    }
}
