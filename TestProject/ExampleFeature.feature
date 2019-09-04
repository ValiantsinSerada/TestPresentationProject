Feature: ExampleFeature
	In order to prove a concept
	As a speaker
	I want to parse example table on Plunker 

Scenario: Go to Planker to parse table	
	Given I go to the https://plnkr.co/edit/5B6fS0YkSmlJgOaenY7T
	And Click Run button
	When I resize table frame
	Then I can see example table	
	| Id  | Age | Name          | Address                     |
	| 001 | 32  | John Smith    | 4 Pentonville Rd, London    |
	| 002 | 54  | Martin Fauler | 23, 5th Ave, NY             |	
	| 003 | 78  | Mark Fish     | 81 Aldwych, Holborn, London |	
