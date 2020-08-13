using IMDBConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDBConsoleApp.Repository
{
    public class MovieRepository
    {
        private IList<Movie> _movies;

        public MovieRepository()
        {
            _movies = new List<Movie>();
        }

        public void Add(Movie movie)
        {
            _movies.Add(movie);
        }

        public Movie Get(string name)
        {
            var movies = _movies;
            return (Movie)movies;
        }
        public IList<Movie> GetAll()
        {
            return _movies.ToList();
        }
    }
}
