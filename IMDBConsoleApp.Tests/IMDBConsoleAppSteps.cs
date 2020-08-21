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
        private int _yearOfRelease;
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
        public void GivenTheReleaseDateOfMovieIs(int yearOfRelease)
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
            table.CompareToInstance(movie);
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

        [Given(@"I have list of movies")]
        public void GivenIHaveListOfMovies()
        {
        }

        [When(@"I will fetch the movies")]
        public void WhenIWillFetchTheMovies()
        {
             _movieHelper.GetMovies();
        }

        [Then(@"Movies will appear as")]
        public void ThenMoviesWillAppearAs(Table table)
        {
            table.CompareToSet(_movies);
        }

        [BeforeScenario("list")]
        public void AddSampleMovie()
        {
            //List<string> actor = new List<string> { "IronMan", "CaptainAmerica" };
            //_movieHelper.AddMovie("Avenger", "Avengers", 2020, actor, "Shield");
            
            var actor = new List<Person>() { new Person { Name = "IronMan", Dob = new DateTime(1970,1,1)},  new Person { Name = "CaptainAmerica", Dob = new DateTime (1980,1,1)} };
            var producer = new Person() { Name = "Shield", Dob = new DateTime(1960, 1, 1) };
            var movie1 = new Movie()
            {
                Name = "Avenger",
                Plot = "Avengers",
                YearOfRelease = new DateTime(2020/1/1),
                Actor = actor,
                Producer = producer
            };
        }
    }
}
