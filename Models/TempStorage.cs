using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Morris_Isaac_Homework3.Models
{
    public class TempStorage
    {
        private static List<MovieResponse> movies = new List<MovieResponse>();
        public static IEnumerable<MovieResponse> Movies => movies;
        public static void AddMovies(MovieResponse movie)
        {
            movies.Add(movie);
        }
    }
}
