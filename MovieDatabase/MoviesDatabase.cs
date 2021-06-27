using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
{
    public class MoviesDatabase
    {
        private List<Movie> movies = new List<Movie>();
        private const string databasePath = "C://Movies//Movies.json";

        public MoviesDatabase()
        {
            string json = string.Empty;
            try
            {
                json = File.ReadAllText(databasePath);
            }
            catch { }
            movies = JsonConvert.DeserializeObject<List<Movie>>(json) ?? new List<Movie>();
        }

        public IEnumerable<Movie> List()
        {
            return movies;
        }

        public void Add(Movie movie)
        {
            movie.Id = movies.Select(m => m.Id).DefaultIfEmpty().Max() + 1;
            movies.Add(movie);
        }

        public void Save()
        {
            var json = JsonConvert.SerializeObject(movies, Formatting.Indented);
            if (File.Exists(databasePath))
            {
                File.Delete(databasePath);
            }
            File.WriteAllText(databasePath, json);
        }

        //Delate
        //Update
    }
}
