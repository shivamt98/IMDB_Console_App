using IMDBConsoleApp.Domain;
using IMDBConsoleApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDBConsoleApp
{
    public class MovieHelper
    {
        private MovieRepository _movieRepository;
        private ActorRepository _actorRepository;
        private ProducerRepository _producerRepository;
        public void AddMovie(string name, string plot, int yearOfRelease, List<string> actorList, string producer)
        {
            string actors = string.Join(",", actorList);
            var actor = new List<Person>() { _actorRepository.GetActor(actors) };
            var prodcuer =new List<Person>() { _producerRepository.GetProducer(producer) };

            var movie = new Movie()
            {
                Name = name,
                Plot = plot,
                YearOfRelease = Convert.ToDateTime(yearOfRelease),
                Actor = actor,
                Producer = prodcuer
            };
            _movieRepository.Add(movie);
        }
        public List<Movie> GetMovies()
        {
            return _movieRepository.GetAll().ToList();
        }

        public Movie GetMovie (string name)
        {
            return _movieRepository.Get(name);
        }
    }
}
