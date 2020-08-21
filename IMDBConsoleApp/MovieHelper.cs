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
            var actors = new List<Person>();
            foreach (var actor in actorList)
            {
                var actorObj = _actorRepository.GetActor(actor);
                actors.Add(actorObj);
            }

            var movie = new Movie()
            {
                Name = name,
                Plot = plot,
                YearOfRelease = Convert.ToDateTime(yearOfRelease),
                Actor = actors,
                Producer = _producerRepository.GetProducer(producer)
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

        public void AddActor(Person actor)
        {
            _actorRepository.AddActor(actor);
        }

        public void AddProducer(Person producer)
        {
            _producerRepository.AddProducer(producer);
        }
    }
}
