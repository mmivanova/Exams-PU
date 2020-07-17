using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace _07_July_2016
{

    class Program
    {
        static void Main(string[] args)
        {
            int number;
            do
            {
                Console.Write("Enter the number of songs: ");
                number = int.Parse(Console.ReadLine());
            } while (number < 0 || number > 5000);

            List<Song> songs = new List<Song>();

            Input(number, songs);

            Console.WriteLine();
            List<Song> sortedListByName = SortByName(songs);
            Output(sortedListByName);

            Console.WriteLine();
            List<Song> rockSongs = RockSongs(songs);
            Output(rockSongs);

            Console.WriteLine();
            Inquiry(songs);
        }

        private static void Input(int number, List<Song> songs)
        {
            for (int i = 0; i < number; i++)
            {
                string name;
                int style;
                string singer;
                int year;
                string album;
                int times;

                do
                {
                    Console.Write("Name: ");
                    name = Console.ReadLine();
                } while (name.Length <= 0 || name.Length > 30);

                do
                {
                    Console.Write("Style: ");
                    style = int.Parse(Console.ReadLine());
                } while (style <= 0 || style > 5);

                do
                {
                    Console.Write("Singer: ");
                    singer = Console.ReadLine();
                } while (singer.Length <= 0 || singer.Length > 15);

                Console.Write("Year: ");
                year = int.Parse(Console.ReadLine());

                do
                {
                    Console.Write("Album: ");
                    album = Console.ReadLine();
                } while (album.Length <= 0 || album.Length > 20);

                Console.Write("Times on air: ");
                times = int.Parse(Console.ReadLine());

                Song song = new Song(name, style, singer, year, album, times);
                songs.Add(song);
            }
        }

        private static void Output(List<Song> songs)
        {
            foreach (var song in songs)
            {
                Console.WriteLine(song);
            }
        }

        public static List<Song> SortByName(List<Song> songs)
        {
            Song temp;

            for (int i = 0; i < songs.Count - 1; i++)
            {
                for (int j = 0; j < songs.Count - 1 - i; j++)
                {
                    if (songs[j].Name.CompareTo(songs[j + 1].Name) > 0)
                    {
                        temp = songs[j];
                        songs[j] = songs[j + 1];
                        songs[j + 1] = songs[j];
                    }
                }
            }
            return songs;
        }

        public static List<Song> SortBySinger(List<Song> songs)
        {
            Song temp;

            for (int i = 0; i < songs.Count - 1; i++)
            {
                for (int j = 0; j < songs.Count - 1 - i; j++)
                {
                    if (songs[j].Singer.CompareTo(songs[j + 1].Singer) > 0 ||
                        (songs[j].Singer.CompareTo(songs[j + 1].Singer) == 0 &&
                        songs[j].Year.CompareTo(songs[j + 1].Year) < 0))
                    {
                        temp = songs[j];
                        songs[j] = songs[j + 1];
                        songs[j + 1] = songs[j];
                    }
                }
            }
            return songs;

        }

        public static List<Song> RockSongs(List<Song> songs)
        {
            List<Song> rockSongs = new List<Song>();

            foreach (var song in songs)
            {
                if (song.Style.Equals(3) && song.Year > 2000)
                {
                    rockSongs.Add(song);
                }
            }
            return SortBySinger(rockSongs);
        }

        public static void Inquiry(List<Song> songs)
        {
            int currentCount = 0;
            int bestCount = 0;
            string singer = null;
            

            foreach (var song in songs)
            {
                currentCount = song.TimesOnAir;
                if (currentCount > bestCount)
                {
                    bestCount = currentCount;
                    singer = song.Singer;
                }
            }
            Console.WriteLine("Singer: " + singer);
            Console.WriteLine(singer + "'s songs: ");
            foreach (var song in songs.Where(s => s.Singer.Equals(singer)))
            {
                Console.WriteLine(song.Name);
            }
        }
    }
}
