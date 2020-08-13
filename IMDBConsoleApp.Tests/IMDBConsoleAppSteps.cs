using System;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using IMDBConsoleApp.Domain;
using IMDBConsoleApp.Repository;
using TechTalk.SpecFlow.Assist;

namespace IMDBConsoleApp.Tests
{
    [Binding]
    public class IMDBConsoleAppSteps
    {
        private string _name, _plot, _producer;
        private DateTime _yearOfRelease;
        private List<string> _actors;
        private MovieRepository _movieRepository = new MovieRepository();


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
        
        [Given(@"the movie actors are '(.*)', '(.*)'")]
        public void GivenTheMovieActorsAre(List<string> actors)
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
            var movie = new Movie()
            {
                Name = _name,
                YearOfRelease = _yearOfRelease,
                Plot = _plot,                            
            };
            _movieRepository.Add(movie);


        }
        
        [Then(@"the movie will appear as")]
        public void ThenTheMovieWillAppearAs(Table table)
        {
            var movieList = _movieRepository.Get(_name);
            table.CompareToInstance(movieList);
        }
    }
}
