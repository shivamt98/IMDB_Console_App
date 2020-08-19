using IMDBConsoleApp.Domain;
using IMDBConsoleApp.Repository;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace IMDBConsoleApp.Tests
{
    [Binding]
    public class IMDBConsoleAppSteps
    {
        private string _name, _plot;
        private DateTime _yearOfRelease;
        private List<Person> _actors;
        private List<Person> _producer;
        private MovieRepository _movieRepository = new MovieRepository();
        private IList<Movie> _movies;

        [Given(@"I have a movie with name '(.*)'")]
        public void GivenIHaveAMovieWithName(string name)
        {
            _name = name;
        }

        [Given(@"the release date of movie is '(.*)'")]
        public void GivenTheReleaseDateOfMovieIs(DateTime yearOfRelease)
        {
            _yearOfRelease = yearOfRelease;
        }

        [Given(@"the plot of the movie is '(.*)'")]
        public void GivenThePlotOfTheMovieIs(string plot)
        {
            _plot = plot;
        }

        [Given(@"the movie actor is '(.*)' '(.*)'")]
        public void GivenTheMovieActorIs(string actorName, DateTime actorDob)
        {
            _actors = new List<Person> { new Person() { PersonName = actorName, PersonDob = actorDob } };
        }

        [Given(@"the movie producer is '(.*)' '(.*)'")]
        public void GivenTheMovieProducerIs(string producerName, DateTime producerDob)
        {
            _producer = new List<Person> { new Person() { PersonName = producerName, PersonDob = producerDob } };
        }

        [When(@"I add the movie to the movie list")]
        public void WhenIAddTheMovieToTheMovieList()
        {
            var movie = new Movie()
            {
                Name = _name,
                YearOfRelease = _yearOfRelease,
                Plot = _plot,
                Actor = _actors,
                Producer = _producer
            };
            _movieRepository.Add(movie);
        }

        [Then(@"the movie will appear as")]
        public void ThenTheMovieWillAppearAs(Table table)
        {
            var movies = _movieRepository.GetAll();
            table.CompareToSet(movies);
        }

        [Then(@"actor for the movie should be like")]
        public void ThenActorForTheMovieShouldBeLike(Table table)
        {
            table.CompareToSet(_actors);
        }

        [Then(@"producer for the movie should be like")]
        public void ThenProducerForTheMovieShouldBeLike(Table table)
        {
            table.CompareToSet(_producer);
        }
    }
}
