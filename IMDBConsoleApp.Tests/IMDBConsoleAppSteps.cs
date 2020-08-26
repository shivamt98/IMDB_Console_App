using IMDBConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace IMDBConsoleApp.Tests
{
    [Binding]
    public class IMDBConsoleAppSteps
    {
        private string _name, _plot;
        private DateTime _yearOfRelease;
        private List<string> _actors;
        private string _producer;
        private MovieHelper _movieHelper = new MovieHelper();
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

        [Given(@"the movie actor are '(.*)'")]
        public void GivenTheMovieActorAre(string actors)
        {
            var actorsList = actors.Split(",").ToList();
            _actors = actorsList;
        }


        [Given(@"the movie producer is '(.*)'")]
        public void GivenTheMovieProducerIs(string producer)
        {
            _producer = producer;
        }



        [When(@"I add the movie to the movie list")]
        public void WhenIAddTheMovieToTheMovieList()
        {
            _movieHelper.AddMovie(_name,_plot,_yearOfRelease,_actors,_producer);
        }

        [Then(@"the movie will appear as")]
        public void ThenTheMovieWillAppearAs(Table table)
        {
            var movie = _movieHelper.GetMovie(_name);
            table.Equals(movie);
        }

        [Then(@"actor for the movie should be like")]
        public void ThenActorForTheMovieShouldBeLike(Table table)
        {
            var movie = _movieHelper.GetMovie(_name);
            table.CompareToSet(movie.Actor);
        }

        [Then(@"producer for the movie should be like")]
        public void ThenProducerForTheMovieShouldBeLike(Table table)
        {
            var movie = _movieHelper.GetMovie(_name);
            table.CompareToInstance(movie.Producer);
        }


        [Given(@"I have list of movies")]
        public void GivenIHaveListOfMovies()
        {
        }

        [When(@"I will fetch the movies")]
        public void WhenIWillFetchTheMovies()
        {
            _movies = _movieHelper.GetMovies();
        }

        [Then(@"Movies will appear as")]
        public void ThenMoviesWillAppearAs(Table table)
        {
            table.CompareToSet(_movies);
        }

        [Then(@"Movie actor will appear as")]
        public void ThenMovieActorWillAppearAs(Table table)
        {
            foreach(var movies in _movies)
            {
                var movie = _movieHelper.GetMovie(movies.Name);
                table.CompareToSet(movie.Actor);
            }            
        }

        [Then(@"Movies producer will appear as")]
        public void ThenMoviesProducerWillAppearAs(Table table)
        {
            foreach(var movies in _movies)
            {
                var movie = _movieHelper.GetMovie(movies.Name);
                table.CompareToInstance(movie.Producer);
            }
        }



        [BeforeScenario("addingActorAndProducer")]

        public void AddActorAndProducer()
        {
            _movieHelper.AddActor("IronMan", new DateTime(1970, 1, 1));
            _movieHelper.AddActor("CaptainAmerica", new DateTime(1972, 8, 2));
            _movieHelper.AddProducer("Shield", new DateTime(1960, 1, 1));
        }


        [BeforeScenario("list")]

        public void AddMovie()
        {
            List<string> actorName = new List<string>() { "IronMan", "CaptainAmerica" };
            _movieHelper.AddMovie("Avenger", "Avengers", new DateTime(2020, 1, 1), actorName, "Shield");
        }
    }
}
