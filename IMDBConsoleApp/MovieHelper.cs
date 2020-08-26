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
        private MovieRepository _movieRepository = new MovieRepository();
        private ActorRepository _actorRepository = new ActorRepository();
        private ProducerRepository _producerRepository  = new ProducerRepository();
        public void AddMovie(string name, string plot, DateTime yearOfRelease, List<string> actorList, string producer)
        {
            var actors = _actorRepository.GetActor(actorList);

            var movie = new Movie()
            {
                Name = name,
                Plot = plot,
                YearOfRelease = yearOfRelease,
                Actor = actors,
                Producer = _producerRepository.GetProducer(producer)
            };
            _movieRepository.Add(movie);
        }
        public List<Movie> GetMovies()
        {
            return _movieRepository.GetAll().ToList();
        }

        public Movie GetMovie(string name)
        {
            return _movieRepository.Get(name);
        }

        public void AddActor(string name, DateTime dob)
        {
            var actor = new Person() { Name = name, Dob = dob };
            _actorRepository.AddActor(actor);
        }

        public List<Person> GetActor(List<string> name)
        {
            return _actorRepository.GetActor(name);
        }

        public void AddProducer(string name, DateTime dob)
        {
            var producer = new Person() { Name = name, Dob = dob };
            _producerRepository.AddProducer(producer);
        }
    }
}
