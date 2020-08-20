Feature: IMDB Console App
	To list all the movies
	Add a new movie
	And to add new actors and producer for new movies
	


Scenario: Add a new movie
	Given I have a movie with name 'Avenger'
	And the release date of movie is '2020 1 1'
	And the plot of the movie is 'Avengers'
	And the movie actor are "<Actor>" 
	And the movie producer is 'Shield'
	When I add the movie to the movie list
	Then the movie will appear as
	| Name    | YearOfRelease | Plot     | 
	| Avenger | 1/1/2020      | Avengers | 
	And actor for the movie should be like
	| Actor         |
	| IronMan       |
	| CaptainAmeica |
	And producer for the movie should be like
	| Producer |
	| Shield   |
	
	

#@list
#Scenario: Show list of all the movies on console
#	Given I have list of movies 
#	When I will show the list of the movies on the console
#	Then Movies will appear as
#	| Name      | Year of release | Plot      | Actors                    | Producer |
#	| Avenger   | 2020 1 1        | Avengers  | Iron Man, Captain America | Shield   |
#	| Avenger 2 | 2020 1 2        | Avengers2 | Iron Man, Captain America | Shield   |