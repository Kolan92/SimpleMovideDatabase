using Newtonsoft.Json;
using System;

namespace MovieDatabase
{
    class Program
    {
        private static MoviesDatabase database = new MoviesDatabase();

        static void Main(string[] args)
        {
            string command = string.Empty;
            do
            {
                command = Console.ReadLine();

                switch (command)
                {
                    case "List":
                        List();
                        break;
                    case "Add":
                        Add();
                        break;
                }
            } while (command != "Exit");

            Console.WriteLine("Exiting program");
            database.Save();
        }

        private static void List()
        {
            var movies = database.List();
            var json = JsonConvert.SerializeObject(movies, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static void Add()
        {
            Console.WriteLine("Title:");
            var title = Console.ReadLine();

            Console.WriteLine("Relese Date:");
            var dateInput = Console.ReadLine();
            var date = DateTime.TryParse(dateInput, out var parsedDate)
                ? parsedDate
                : default(DateTime?);

            Console.WriteLine("Score:");
            var scoreInput = Console.ReadLine();
            var score = int.TryParse(scoreInput, out var parsedScore)
                ? parsedScore
                : 0;

            var movie = new Movie
            {
                Title = title,
                RealeseDate = date,
                Score = score
            };

            database.Add(movie);
        }
    }
}
