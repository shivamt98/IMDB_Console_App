Feature: IMDB Console App
	To list all the movies
	Add a new movie
	And to add new actors and producer for new movies
	
@addingActorAndProducer 
Scenario: Add a new movie
	Given I have a movie with name 'Avenger'
	And the release date of movie is '2020-8-10'
	And the plot of the movie is 'Avengers'
	And the movie actor are 'IronMan,CaptainAmerica'
	And the movie producer is 'Shield'
	When I add the movie to the movie list
	Then the movie will appear as
	| Name    | YearOfRelease | Plot     | 
	| Avenger | 2020-8-10     | Avengers | 
	And actor for the movie should be like
	| Name           | Dob      |
	| IronMan        | 1970-1-1 |
	| CaptainAmerica | 1972-8-2 |
	And producer for the movie should be like
	| Name   | Dob      |
	| Shield | 1960-1-1 |
		
@addingActorAndProducer @list
Scenario: Show list of all the movies on console
	Given I have list of movies 
	When I will fetch the movies
	Then Movies will appear as
	| Name    | Year of release | Plot     | 
	| Avenger | 2020-1-1        | Avengers | 
	And Movie actor will appear as
	| Name           | Dob      |
	| IronMan        | 1970-1-1 |
	| CaptainAmerica | 1972-8-2 |
	And Movies producer will appear as
	| Name   | Dob      |
	| Shield | 1960-1-1 |

