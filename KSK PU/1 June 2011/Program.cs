using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _1_June_2011
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = ValidateInputNumber();

            List<Movie> movies = new List<Movie>();

            Input(number, movies);

            List<Movie> sortedListByTitle = SortByTitle(movies);
            Output(sortedListByTitle);

            List<Movie> robertDeNiroMovies = GetMoviesWithRobertDeNiro(movies);
            Output(robertDeNiroMovies);

            Inquiry();
        }

        private static int ValidateInputNumber()
        {
            int number;
            do
            {
                Console.Write("Enter the number of movies: ");
                number = int.Parse(Console.ReadLine());
            } while (number <= 0 || number > 10000);
            return number;
        }

        private static void Input(int number, List<Movie> movies)
        {
            for (int i = 0; i < number; i++)
            {
                string title;
                string actors;
                int year;
                double license;

                do
                {
                    Console.Write("Title: ");
                    title = Console.ReadLine();
                } while (title.Length <= 0 || title.Length > 40);

                do
                {
                    Console.Write("Actors: ");
                    actors = Console.ReadLine();
                } while (actors.Length <= 0 || actors.Length > 250);

                Console.Write("Year of release: ");
                year = int.Parse(Console.ReadLine());

                Console.Write("License tax: ");
                license = double.Parse(Console.ReadLine());

                Movie movie = new Movie(title, actors, year, license);
                movies.Add(movie);
            }
        }

        private static void Output(List<Movie> movies)
        {
            foreach (var movie in movies)
            {
                Console.WriteLine(movie);
            }
        }

        public static List<Movie> SortByTitle(List<Movie> movies)
        {
            Movie temp;

            for (int i = 0; i < movies.Count - 1; i++)
            {
                for (int j = 0; j < movies.Count - 1 - i; j++)
                {
                    if (movies[j].Title.CompareTo(movies[j+1].Title) > 0)
                    {
                        temp = movies[j];
                        movies[j] = movies[j + 1];
                        movies[j + 1] = temp;
                    }
                }
            }

            return movies;
        }

        public static List<Movie> SortByYear(List<Movie> movies)
        {
            Movie temp;

            for (int i = 0; i < movies.Count - 1; i++)
            {
                for (int j = 0; j < movies.Count - 1 - i; j++)
                {
                    if (movies[j].YearOfRelease.CompareTo(movies[j + 1].YearOfRelease) < 0 || (
                        movies[j].YearOfRelease.CompareTo(movies[j + 1].YearOfRelease) == 0 &&
                        movies[j].License.CompareTo(movies[j + 1].License) > 0))
                    {
                        temp = movies[j];
                        movies[j] = movies[j + 1];
                        movies[j + 1] = temp;
                    }
                }
            }
            return movies;
        }

        public static List<Movie> GetMoviesWithRobertDeNiro(List<Movie> movies)
        {
            List<Movie> moviesWithRobertDeNiro = new List<Movie>();

            foreach (var movie in movies)
            {
                if (movie.Actors.Contains("Robert de Niro"))
                {
                    moviesWithRobertDeNiro.Add(movie);
                }
            }
            return SortByYear(moviesWithRobertDeNiro);
        }

        public static void Inquiry()
        {
            int numberOfMoviesInTheFirstLibrary = ValidateInputNumber();
            List<Movie> firstMovieLibrary = new List<Movie>();
            Input(numberOfMoviesInTheFirstLibrary, firstMovieLibrary);
            List<Movie> firstSortedListByTitle = SortByTitle(firstMovieLibrary);
            Output(firstSortedListByTitle);
            List<Movie> firstRobertDeNiroMovies = GetMoviesWithRobertDeNiro(firstMovieLibrary);
            Output(firstRobertDeNiroMovies);

            int numberOfMoviesInTheSecondLibrary = ValidateInputNumber();
            List<Movie> secondMovieLibrary = new List<Movie>();
            Input(numberOfMoviesInTheSecondLibrary, secondMovieLibrary);
            List<Movie> secondSortedListByTitle = SortByTitle(secondMovieLibrary);
            Output(secondSortedListByTitle);
            List<Movie> secondRobertDeNiroMovies = GetMoviesWithRobertDeNiro(secondMovieLibrary);
            Output(secondRobertDeNiroMovies);

            int numberOfMoviesInTheThirdLibrary = ValidateInputNumber();
            List<Movie> thirdMovieLibrary = new List<Movie>();
            Input(numberOfMoviesInTheThirdLibrary, thirdMovieLibrary);
            List<Movie> thirdSortedListByTitle = SortByTitle(thirdMovieLibrary);
            Output(thirdSortedListByTitle);
            List<Movie> thirdRobertDeNiroMovies = GetMoviesWithRobertDeNiro(thirdMovieLibrary);
            Output(thirdRobertDeNiroMovies);
        }
    }
}
