using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Score { get; set; }
        public DateTime? RealeseDate { get; set; }
        public List<int> ActorsIds { get; set; }

    }

    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> MoviesIds { get; set; }
    }
}
