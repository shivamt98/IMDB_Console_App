Feature: IMDB Console App
	To list all the movies
	Add a new movie
	And to add new actors and producer for new movies
	

@mytag
Scenario: Add a new movie
	Given I have a movie with name 'Avenger'
	And the release date of movie is '2020 1 1'
	And the plot of the movie is 'Avengers'
	And the movie actors are 'Iron Man', 'Captain America'
	And the movie producer is 'Shield'
	When I add the movie to the movie list
	Then the movie will appear as
	| Name    | Year of release | Plot     | Actors                    | Producer |
	| Avenger | 2020 1 1        | Avengers | Iron Man, Captain America | Shield   |