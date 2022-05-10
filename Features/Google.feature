Feature: Google
	In order test google search
	I want to do a search in google
	And check the result
	
@mytag
Scenario: Search in google
	Given I fill the input field with Test
	When I click the search button
	Then the result should be displayed
