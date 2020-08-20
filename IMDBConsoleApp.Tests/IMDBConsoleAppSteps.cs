using IMDBConsoleApp.Domain;
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
        private int _yearOfRelease;
        private List<string> _actors;
        private string _producer;
        private MovieHelper _movieHelper = new MovieHelper();
        //private IList<Movie> _movies;

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

        [Given(@"the movie actor are ""(.*)""")]
        public void GivenTheMovieActorAre(List<string> actors)
        {
            _actors = actors;
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
    }
}
